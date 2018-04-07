using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFade : MonoBehaviour {
	private int countPhase = 1;
	private int explodePhase;
	private Vector4 newColor;
	private SpriteRenderer fireSprite;
	public Vector4[] colorsPhase;
	public float fadeTime;
	private bool isFading;
	// Use this for initialization
	private void Awake() {
		explodePhase = colorsPhase.Length;
		fireSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	void Start () {
		fireSprite.color = new Vector4(255,255,255,0);
		newColor = new Vector4(fireSprite.color.r,fireSprite.color.g,fireSprite.color.b,100);
	}
	
	// Update is called once per frame
	void Update () {
		fireSprite.color = Vector4.MoveTowards(fireSprite.color,newColor,Time.deltaTime * fadeTime);
	}
	public bool IsOnExplodePhase() {
		return (countPhase >= explodePhase -1);
	}
	public int GetCurrentPhase() {
		return (countPhase);
	}
	public bool IsOnZeroPhase() {
		return (countPhase <= 0);
	}
	public bool IsStillFadeOut() {
		return (fireSprite.color.a < colorsPhase[countPhase].w);
	}
	public bool IsStillFadeIn() {
		return (fireSprite.color.a > colorsPhase[countPhase].w);
	}
	public void FadeIn() {
		if (!IsOnExplodePhase()) {
			if (!isFading) {
				countPhase = countPhase + 1;
				isFading = true;
				ChangeFade(countPhase);
			}
			if (!IsStillFadeIn()) {
				isFading = false;
			}
		}
	}
	public void FadeOut() {
		if (!IsOnZeroPhase()) {
			if (!isFading) {
				countPhase = countPhase - 1;
				isFading = true;
				ChangeFade(countPhase);	
			}
			if (!IsStillFadeOut()) {
				isFading = false;
			}
		}
	}
	public void ChangeFade(int countPhase) {
		newColor = new Vector4(colorsPhase[countPhase].x,colorsPhase[countPhase].y,colorsPhase[countPhase].z,colorsPhase[countPhase].w);
	}
	/*public void FadeIn() {
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
	}*/
}
