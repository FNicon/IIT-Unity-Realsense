using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound Container", menuName = "Sound Container/new Container", order = 1)]
public class SFXContainer : ScriptableObject {
	public AudioClip[] soundEffects;
	public string[] identifier;
}
