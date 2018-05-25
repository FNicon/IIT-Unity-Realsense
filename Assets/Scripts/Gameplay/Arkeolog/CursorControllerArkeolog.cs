using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControllerArkeolog : MonoBehaviour {
	public static CursorControllerArkeolog instance = null;
	public delegate void HandCursor();
	public static event HandCursor OnMouseDown;
	public static event HandCursor OnMouseUp;

	[SerializeField]
	private float cursorOffsetX;
	[SerializeField]
	private float cursorOffsetY;
	[SerializeField]
	private Animator mouseAnim;
	[SerializeField]
	private GameObject[] gameObjTag;

	private SpriteRenderer cursorSprite;
	List<GameObject> gameObjList;
	List<string> objTags;
	public bool isRealsenseActive;
	public bool isHandClicked;
	public bool isAlreadyCalledDown;
	// Use this for initialization
	void Awake () {
		if(instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
		objTags = new List<string>();
		for(int i = 0;i<gameObjTag.Length;i++){
			if(!objTags.Contains(gameObjTag[i].tag))
				objTags.Add(gameObjTag[i].tag);
		}

		mouseAnim = GetComponent<Animator>();
		cursorSprite = GetComponent<SpriteRenderer>();
		gameObjList = new List<GameObject>();
	}

	void Update () {
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.x += cursorOffsetX;
		mousePos.y += cursorOffsetY;

		if(InsideScreen())
			transform.position = mousePos;

		if(Input.GetMouseButtonDown(0)){
			mouseAnim.SetBool("MouseDown", true);
			OnCursorDown();
		} else if(Input.GetMouseButtonUp(0)){
			mouseAnim.SetBool("MouseDown", false);
			OnCursorUp();
		}

		if (isRealsenseActive) {
			if (isHandClicked) {
				mouseAnim.SetBool("MouseDown", true);
				//cursorSprite.sprite = mouseDownImage;
				OnCursorDown();
				isHandClicked = true;
				//isMouseDown = true;
			} else if (!isHandClicked) {
				mouseAnim.SetBool("MouseDown", false);
				//cursorSprite.sprite = mouseUpImage;
				OnCursorUp();
				isHandClicked = false;
				//isMouseDown = false;
			}	
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(objTags.Contains(col.tag)){
			gameObjList.Add(col.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(objTags.Contains(col.tag)){
			gameObjList.Remove(col.gameObject);
		}
	}

	void OnCursorDown(){
		if (!isAlreadyCalledDown) {
			isAlreadyCalledDown = true;
			if(OnMouseDown != null)
				OnMouseDown();
		}
	}

	void OnCursorUp(){
		isAlreadyCalledDown = false;
		if(OnMouseUp != null)
			OnMouseUp();
	}

	bool InsideScreen(){
		Vector2 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float xStart = mousePosWorld.x-(cursorSprite.bounds.size.x/2f);
		float xEnd = mousePosWorld.x+(cursorSprite.bounds.size.x/2f);
		float yStart = mousePosWorld.y-(cursorSprite.bounds.size.y/2f);
		float yEnd = mousePosWorld.y+(cursorSprite.bounds.size.y/2f);
		Vector2 mousePosStart = Camera.main.WorldToScreenPoint(new Vector2(xStart,yStart));
		Vector2 mousePosEnd = Camera.main.WorldToScreenPoint(new Vector2(xEnd, yEnd));
		bool insideScreenH = mousePosStart.x >= 0 && mousePosEnd.x <= Screen.width;
		bool insideScreenV = mousePosStart.y >= 0 && mousePosEnd.y <= Screen.height;
		return insideScreenH && insideScreenV;
	}

	public GameObject GetFirstClickedObj(){
		return gameObjList.Count > 0 ? gameObjList[0] : null;
	}

	public Vector2 GetCursorSize(){
		return new Vector2(cursorSprite.bounds.size.x, cursorSprite.bounds.size.y);
	}

	public Vector2 GetPosition(){
		return (Vector2)transform.position;
	}
}
