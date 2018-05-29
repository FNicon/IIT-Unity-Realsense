using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultipleSceneLoader : MonoBehaviour {
	public List<AsyncOperation> operation;
	public List<string> sceneToLoad;
	// Use this for initialization
	void Start () {
		int i;
		for (i = 0; i<sceneToLoad.Count; i++) {
			operation.Add(SceneManager.LoadSceneAsync(sceneToLoad[i]));
			operation[i].allowSceneActivation = false;
			//StartCoroutine(AsyncLoad(sceneToLoad[i],i));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator AsyncLoad(string scene, int index) {
		operation.Add(SceneManager.LoadSceneAsync(scene));
		//operation[index] = SceneManager.LoadSceneAsync(scene);
		operation[index].allowSceneActivation = false;
		while (!operation[index].isDone) {
			yield return null;
		}
		//yield return new WaitUntil(()=>operation.isDone);
		//Debug.Log(operation.progress);
	}
}
