using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {
	public SceneLoader sceneLoader;
	public RectTransform selectedObject;
	public RectTransform[] childObjects;

	public List<Button> uiButtons;
	// Use this for initialization
	private void Awake() {
		GameObject temp = GameObject.Find("Scene Loader");
		if(temp != null)
			sceneLoader = temp.GetComponent<SceneLoader>();
		UpdateChildObjects();
	} 
	// Update is called once per frame
	void Update () {
		
	}

	public void SwipeRight() {
		Transform tempObject;
		tempObject = childObjects[childObjects.Length - 1];
		for (int i = 0; i<childObjects.Length - 1;i++) {
			childObjects[i].SetSiblingIndex(i + 1);
		}
		childObjects[childObjects.Length - 1].SetSiblingIndex(0);
		//ResetChildObject(3);
		UpdateChildObjects();
	}
	void ResetChildObject(int previouslyChoosenChild) {
		Vector3 currentChildScale = childObjects[previouslyChoosenChild].transform.localScale;
		childObjects[previouslyChoosenChild].transform.localScale = new Vector3(
			currentChildScale.x - 0.2f,currentChildScale.y - 0.2f,currentChildScale.z - 0.2f);
	}
	void UpdateChildObjects() {
		int childCount = transform.childCount;
		for (int i = 0; i < childCount; i++) {
			childObjects[i] = transform.GetChild(i).GetComponent<RectTransform>();
			childObjects[i].gameObject.SetActive(true);
			childObjects[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.7f);
			childObjects[i].GetComponent<Button>().interactable = false;
		}
		childObjects[0].gameObject.SetActive(false);
		childObjects[4].gameObject.SetActive(false);

		childObjects[1].GetComponent<BoxCollider2D>().enabled = false;
		childObjects[2].GetComponent<BoxCollider2D>().enabled = true;
		childObjects[3].GetComponent<BoxCollider2D>().enabled = false;

		if(selectedObject != null){
			selectedObject.GetChild(0).gameObject.SetActive(false);
			selectedObject.transform.localScale = Vector3.one;
		}
		selectedObject = childObjects[2];
		//Vector3 currentScale = selectedObject.transform.localScale;
		selectedObject.GetChild(0).gameObject.SetActive(true);
		selectedObject.GetChild(0).transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
		selectedObject.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
		selectedObject.GetComponent<Button>().interactable = true;
		/*selectedObject.transform.localScale = new Vector3(
			currentScale.x + 0.2f, currentScale.y + 0.2f, currentScale.z + 0.2f);*/
		selectedObject.GetComponent<Image>().color = Color.white;
	}
	public void SwipeLeft() {
		Transform tempObject;
		tempObject = childObjects[0];
		for (int i = childObjects.Length - 1; i>0;i--) {
			childObjects[i].SetSiblingIndex(i - 1);
		}
		childObjects[0].SetSiblingIndex(childObjects.Length - 1);
		//ResetChildObject(1);
		UpdateChildObjects();
	}

	public void OnSelectLoadScene(string scene){
		StartCoroutine("LoadScene", scene);
	}

	IEnumerator LoadScene(string scene){
		Animator anim = selectedObject.GetComponent<Animator>();
		anim.SetTrigger("Pressed");
		selectedObject.GetComponent<Button>().enabled = false;
		foreach(Button btn in uiButtons){
			btn.enabled = false;
			btn.gameObject.GetComponent<Image>().raycastTarget = false;
		}
		yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Pressed"));
		yield return new WaitForSeconds(anim.GetNextAnimatorClipInfo(0)[0].clip.length);
		sceneLoader.loadSpecificScene(scene);
	}
}
