using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RSUnityToolkit;

public class RealsenseClick : MonoBehaviour {
	pxcmStatus sts;
	PXCMHandModule handAnalyzer;
	PXCMHandConfiguration config;
	// Use this for initialization
	void Start () {
		//handAnalyzer = FindObjectOfType<SenseToolkitManager>().SenseManager.QueryHand();
		//InitializeSenseManager();
		//InitializeHandModule();
		//SetHandConfig();
	}
	// Update is called once per frame
	void Update () {
		/* Make sure PXCMSenseManager Instance is Initialized */
		if (SenseToolkitManager.Instance.SenseManager == null) {
			return;
		}
		/* Wait until any frame data is available true(aligned) false(unaligned) */
		if (SenseToolkitManager.Instance.SenseManager.AcquireFrame(false,0) != pxcmStatus.PXCM_STATUS_NO_ERROR) {
			return;
		}
		/* Retrieve am instance of hand tracking Module */
		handAnalyzer = SenseToolkitManager.Instance.SenseManager.QueryHand();
		if (handAnalyzer != null) {
			/* Retrieve an instance of hand tracking Data */
			PXCMHandData _outputData = handAnalyzer.CreateOutput();
			if (_outputData != null) {
				_outputData.Update();
				//Retrieve joint data, gesture recognition data and alert notification data
				//refer to next section

				//AcquireFrame
				/* Retrieve Gesture Data */
				PXCMHandData.GestureData _gestureData;
				for(int i = 0; i < _outputData.QueryFiredGesturesNumber(); i++) {
					if (_outputData.QueryFiredGestureData(i, out _gestureData) == pxcmStatus.PXCM_STATUS_NO_ERROR) {
						//Display the gestures:  explained in rendering the frame section
						//Debug.Log(_gestureData.name);
						if (_gestureData.name == "fist") {
							CursorController.isHandClicked = true;
						} else if (_gestureData.name == "v_sign") {
							transform.position = new Vector3(0,0,0);
						} else {
							CursorController.isHandClicked = false;
						}
					}
				}
			}
		}
		/* Realease the frame to process the next frame */
		//SenseToolkitManager.Instance.SenseManager.ReleaseFrame();	
	}
	private void OnDisable() {
		handAnalyzer.Dispose();
		if (SenseToolkitManager.Instance.SenseManager == null) {
			return;
		}
		SenseToolkitManager.Instance.SenseManager.Dispose();
	}
	/*void InitializeSenseManager() {
		 Initialize a PXCMSenseManager instance 
		psm = PXCMSenseManager.CreateInstance();
		if (psm == null) {
			Debug.LogError("SenseManager Initialization Failed");
			return;
		}
	}*/
	void InitializeHandModule() {
		/* Enable the hand tracking module*/
		sts = SenseToolkitManager.Instance.SenseManager.EnableHand();
		if (sts != pxcmStatus.PXCM_STATUS_NO_ERROR) {
			Debug.LogError("PXCSenseManager.EnableHand: "+ sts);
		}
		/* Retrieve an instance of hand to configure */
		handAnalyzer = SenseToolkitManager.Instance.SenseManager.QueryHand();
		if (handAnalyzer == null) {
			Debug.LogError("PXCSenseManager.QueryHand");
		}
		/* Initialize the execution pipeline */
		sts = SenseToolkitManager.Instance.SenseManager.Init();
		if (sts != pxcmStatus.PXCM_STATUS_NO_ERROR) {
			Debug.LogError("PXCMSenseManager.Init Failed");
			OnDisable();
			// Clean-up
			return;
		}
	}
	void SetHandConfig() {
		config = handAnalyzer.CreateActiveConfiguration();
		config.EnableAllGestures();
		config.EnableAllAlerts();
		config.ApplyChanges();
		config.Dispose();
	}
}
