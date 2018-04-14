using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencuriController : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("End")){
			PolisiGameManager.instance.PencuriDead();
			Destroy(transform.parent.gameObject);
		}

	}
}
