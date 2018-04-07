using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialManager : MonoBehaviour {
	public SceneLoader scene;
	public VideoPlayer tutorialVideo;
	public long endFrame;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(tutorialVideo.frame);
		if (IsVideoEnd()) {
			scene.nextScene();
		}
	}
	bool IsVideoEnd() {
		return (tutorialVideo.frame >= endFrame);
		//return ((tutorialVideo.frame >= endFrame) || (tutorialVideo.frame >= (long)tutorialVideo.frameCount));
	}
}
