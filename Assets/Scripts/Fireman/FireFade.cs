using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFade : MonoBehaviour {
	private Vector4 newColor;
	private SpriteRenderer fireSprite;
	// Use this for initialization
	private void Awake() {
		fireSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	void Start () {
		fireSprite.color = new Vector4(255,255,255,0);
		newColor = new Vector4(fireSprite.color.r,fireSprite.color.g,fireSprite.color.b,100);
	}
	
	// Update is called once per frame
	void Update () {
		fireSprite.color = Vector4.MoveTowards(fireSprite.color,newColor,Time.deltaTime);
	}
	public void FadeIn() {
		if (fireSprite.color.a < 255) {
			newColor = new Vector4(fireSprite.color.r,fireSprite.color.g,fireSprite.color.b,fireSprite.color.a + 5f);
		}
	}
	public void FadeOut() {
		if (fireSprite.color.a > 0) {
			newColor = new Vector4(fireSprite.color.r,fireSprite.color.g,fireSprite.color.b,fireSprite.color.a - 5f);
		}
	}
	public void StopFade() {
		newColor = new Vector4(fireSprite.color.r,fireSprite.color.g,fireSprite.color.b,fireSprite.color.a);
	}
}
