using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PhotoManager : MonoBehaviour {
	public VideoPlayer photoVideo;
	public long endFrame;
	public GameObject[] currentObjects;
	public GameObject[] nextObjects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(photoVideo.frame);
		if (IsVideoEnd()) {
			PlayNext();
		}
	}
	void PlayNext() {
		EnableObjects(nextObjects);
		DisableObjects(currentObjects);
		GetComponent<PhotoManager>().enabled = false;
	}
	bool IsVideoEnd() {
		return (photoVideo.frame >= endFrame);
	}
	void EnableObjects(GameObject[] inputObjects) {
		for (int i = 0; i < inputObjects.Length; i++) {
			inputObjects[i].SetActive(true);
		}
	}
	void DisableObjects(GameObject[] inputObjects) {
		for (int i = 0; i < inputObjects.Length; i++) {
			inputObjects[i].SetActive(false);
		}
	}
}
