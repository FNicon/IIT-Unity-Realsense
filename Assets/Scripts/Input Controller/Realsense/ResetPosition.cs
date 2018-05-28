using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour {
	private void OnEnable() {
		transform.position = new Vector3(0,0,0);
	}
	private void OnDisable() {
		
	}
}
