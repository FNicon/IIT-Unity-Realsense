using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{

    public float brushStrength;
    private SpriteRenderer dustSpriteRenderer;
    [SerializeField]
    private Sprite normalSprite;
    [SerializeField]
    private Sprite selectedSprite;
    private bool isSelected = false;
    private bool isClicked = false;
    private Vector3 lastCursorPos;
    private Vector3 distance;
    public SFXManager geserSound;
    // Use this for initialization	
    void Start()
    {
        dustSpriteRenderer = GetComponent<SpriteRenderer>();
        CursorController.OnMouseDown += OnCursorDown;
		CursorController.OnMouseUp += OnCursorUp;
		CursorController.OnMouseHover += OnCursorHover;
    }

    // Update is called once per frame
    void Update()
    {
		if (dustSpriteRenderer.color.a <= 0)
        {
			gameObject.SetActive(false);
        }

		if (isSelected)
        {
            if (isClicked)
            {
                distance = Input.mousePosition - lastCursorPos;
                //ReduceAlpha(distance.magnitude);
                ReduceAlpha(1f + distance.magnitude);
            }
            lastCursorPos = Input.mousePosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            dustSpriteRenderer.sprite = selectedSprite;
            isSelected = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            dustSpriteRenderer.sprite = normalSprite;
            isSelected = false;
        }
    }

    void OnCursorHover() {
        dustSpriteRenderer.sprite = selectedSprite;
        isSelected = true;
    }

    void OnCursorDown() {
        isClicked = true;
    }

    void OnCursorUp() {
        isClicked = false;
    }

    void OnMouseOver()
    {
        dustSpriteRenderer.sprite = selectedSprite;
        isSelected = true;
    }

    void OnMouseExit()
    {
        dustSpriteRenderer.sprite = normalSprite;
        isSelected = false;
    }

    void OnMouseDown()
    {
        isClicked = true;
    }

    void OnMouseUp()
    {
        isClicked = false;
    }

    void ReduceAlpha(float f)
    {
        if (TimeManager.instance.isGameStart) {
            Color newColor = dustSpriteRenderer.color;
            float reduceAmount = (f * brushStrength) / 1000;
            newColor.a -= reduceAmount;
            dustSpriteRenderer.color = newColor;
            geserSound.PlayFromString("gerak");
        }
    }
    private void OnDestroy() {
        CursorController.OnMouseDown -= OnCursorDown;
		CursorController.OnMouseUp -= OnCursorUp;
		CursorController.OnMouseHover -= OnCursorHover;
    }
}
