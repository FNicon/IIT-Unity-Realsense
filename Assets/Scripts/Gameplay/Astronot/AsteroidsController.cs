using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsController : MonoBehaviour {

	[System.Serializable]
	struct RandomRange {
		public float start;
		public float end;
	}
	[SerializeField]
	RandomRange rangeStart;

	// Use this for initialization
	void Awake () {
		foreach(Transform obj in transform){
			Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
			body.velocity = new Vector2(Random.Range(rangeStart.start,rangeStart.end), Random.Range(rangeStart.start,rangeStart.end));
			body.angularVelocity = Random.Range(rangeStart.start,rangeStart.end)*90;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
