using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class properties : MonoBehaviour {

    public static int weight, height;
    public Text weightFieldPlace, heightFieldPlace, weightField, heightField;

	// Use this for initialization
	void Start () 
    {
        if (PlayerPrefs.GetInt("weightPref") == 0)
        {
            PlayerPrefs.SetInt("energy", 3000);
            PlayerPrefs.Save();
        }
        weight = PlayerPrefs.GetInt("weightPref");

        weight = PlayerPrefs.GetInt("weightPref");
        weightFieldPlace.text = weight.ToString();
        height = PlayerPrefs.GetInt("heightPref");
        heightFieldPlace.text = height.ToString();
	}

    void OnDestroy ()
    {
        PlayerPrefs.SetInt("weightPref", weight);   
        PlayerPrefs.SetInt("heightPref", height);
        PlayerPrefs.Save();
    }

	// Update is called once per frame
	void Update () {
        if (!String.IsNullOrEmpty(weightField.text))
        {
            weight = int.Parse(weightField.text);
        }
        if (!String.IsNullOrEmpty(heightField.text))
        {
            height = int.Parse(heightField.text);
        }
	}
}
