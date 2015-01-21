using UnityEngine;
using System.Collections;

public class changeRandomBGSOUND : MonoBehaviour {

	public AudioClip[] bgMusics;

	// Use this for initialization
	void Start () {
		audio.clip = bgMusics[Random.Range(0,bgMusics.Length-1)];
		audio.Play();
	}
}
