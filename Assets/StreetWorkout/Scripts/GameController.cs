using UnityEngine;
using System.Collections;
using System;
public class GameController : MonoBehaviour {

	// Use this for initialization
	public Color[] colors;//to be used for changing camera background colors 

	void OnGameStart()
	{
		//to change background color RANDOMLY
		Camera.main.backgroundColor  = colors[ UnityEngine.Random.Range(0,colors.Length-1)];
	}
}
