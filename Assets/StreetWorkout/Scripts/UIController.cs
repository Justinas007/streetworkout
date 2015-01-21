using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Use this for initialization
    public TextMesh bmiText, bmiTextShadow, energyText, energyTextShadow, timesText, timesTextShadow, levelText, levelTextShadow, dayText, dayTextShadow, infoText, infoTextShadow;
    public GameObject Player, InGameUIContainer, scoreText, newScoreObj, ScoreBoard, ChangeLevel;
    string staminastring;
    int inGameScore = 0;

    public Camera UICamera;

    void OnEnable()
    {
        playerController.IncreaseScore += OnScoreIncrease;
        double index = (double)PlayerPrefs.GetInt("weightPref") / (((double)PlayerPrefs.GetInt("heightPref") / 100) * ((double)PlayerPrefs.GetInt("heightPref") / 100));
        PlayerPrefs.SetInt("bmi", (int)index);
        PlayerPrefs.Save();
        bmiText.text = "BMI: " + Math.Round(index, 1).ToString();
        bmiTextShadow.text = bmiText.text;
    }

    RaycastHit hit;
    void Update()
    {
        // Update Players energy
        energyText.text = PlayerPrefs.GetInt("energy").ToString() + " kcal";
        energyTextShadow.text = energyText.text;

        dayText.text = "Day: " + PlayerPrefs.GetInt("day").ToString();
        dayTextShadow.text = dayText.text;

        levelText.text = "Level: " + PlayerPrefs.GetInt("level").ToString();
        levelTextShadow.text = levelText.text;


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray R = UICamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(R, out hit, 100))
            {
                SoundController.Static.PlayClickSound();
                switch (hit.collider.name)
                {
                    case "level1_text":
                        PlayerPrefs.SetInt("level", 1);
                        PlayerPrefs.Save();
                        ChangeLevel.SetActive(false);
                        infoText.text = "Level changed to " + PlayerPrefs.GetInt("level");
                        infoTextShadow.text = infoText.text;
                        break;
                    case "level2_text":
                        PlayerPrefs.SetInt("level", 2);
                        PlayerPrefs.Save();
                        ChangeLevel.SetActive(false);
                        infoText.text = "Level changed to " + PlayerPrefs.GetInt("level");
                        infoTextShadow.text = infoText.text;
                        break;
                    case "level3_text":
                        PlayerPrefs.SetInt("level", 3);
                        PlayerPrefs.Save();
                        ChangeLevel.SetActive(false);
                        infoText.text = "Level changed to " + PlayerPrefs.GetInt("level");
                        break;
                    case "level4_text":
                        PlayerPrefs.SetInt("level", 4);
                        PlayerPrefs.Save();
                        ChangeLevel.SetActive(false);
                        infoText.text = "Level changed to " + PlayerPrefs.GetInt("level");
                        break;
                    case "level5_text":
                        PlayerPrefs.SetInt("level", 5);
                        PlayerPrefs.Save();
                        ChangeLevel.SetActive(false);
                        infoText.text = "Level changed to " + PlayerPrefs.GetInt("level");
                        break;
                    case "level6_text":
                        PlayerPrefs.SetInt("level", 6);
                        PlayerPrefs.Save();
                        ChangeLevel.SetActive(false);
                        infoText.text = "Level changed to " + PlayerPrefs.GetInt("level");
                        break;
                    case "level7_text":
                        PlayerPrefs.SetInt("level", 7);
                        PlayerPrefs.Save();
                        ChangeLevel.SetActive(false);
                        infoText.text = "Level changed to " + PlayerPrefs.GetInt("level");
                        break;
                    case "level8_text":
                        PlayerPrefs.SetInt("level", 8);
                        PlayerPrefs.Save();
                        ChangeLevel.SetActive(false);
                        infoText.text = "Level changed to " + PlayerPrefs.GetInt("level");
                        break;
                    case "level9_text":
                        PlayerPrefs.SetInt("level", 9);
                        PlayerPrefs.Save();
                        ChangeLevel.SetActive(false);
                        infoText.text = "Level changed to " + PlayerPrefs.GetInt("level");
                        break;
                    case "level10_text":
                        PlayerPrefs.SetInt("level", 10);
                        PlayerPrefs.Save();
                        ChangeLevel.SetActive(false);
                        infoText.text = "Level changed to " + PlayerPrefs.GetInt("level");
                        break;
                    case "pullups_text":
                        ScoreBoard.SetActive(false);
                        Application.LoadLevel("PullUps");
                        break;
                    case "clappingpullups_text":
                        if (PlayerPrefs.GetInt("level") < 9)
                        {
                            ScoreBoard.SetActive(false);
                            infoText.text = "Your Level " + PlayerPrefs.GetInt("level").ToString() + " is too low";
                            infoTextShadow.text = infoText.text;
                        }
                        else
	                    {
	                        ScoreBoard.SetActive(false);
                            Application.LoadLevel("ClappingPullUps");
	                    }
                        break;
                    case "muscleups_text":
                        if (PlayerPrefs.GetInt("level") < 6)
                        {
                            ScoreBoard.SetActive(false);
                            infoText.text = "Your Level " + PlayerPrefs.GetInt("level").ToString() + " is too low";
                            infoTextShadow.text = infoText.text;
                        }
                        else
                        {
                            ScoreBoard.SetActive(false);
                            Application.LoadLevel("MuscleUps");
                        }
                        break;
                    case "straightbardibs_text":
                        if (PlayerPrefs.GetInt("level") < 4)
                        {
                            ScoreBoard.SetActive(false);
                            infoText.text = "Your Level " + PlayerPrefs.GetInt("level").ToString() + " is too low";
                            infoTextShadow.text = infoText.text;
                        }
                        else
                        {
                            ScoreBoard.SetActive(false);
                            Application.LoadLevel("StraightBarDibs");
                        }
                        break;
                    case "pullovers_text":
                        if (PlayerPrefs.GetInt("level") < 3)
                        {
                            ScoreBoard.SetActive(false);
                            infoText.text = "Your Level " + PlayerPrefs.GetInt("level").ToString() + " is too low";
                            infoTextShadow.text = infoText.text;
                        }
                        else
                        {
                            ScoreBoard.SetActive(false);
                            Application.LoadLevel("PullOvers");
                        }
                        break;
                }
            }

        }
    }


    void OnScoreIncrease(System.Object obj, EventArgs args)
    {
        inGameScore++;
        timesText.text = "Times: " + inGameScore;
        timesTextShadow.text = timesText.text;
        switch (Application.loadedLevelName)
        {
            case "PullUps":
                if (PlayerPrefs.GetInt("pullupscount") > 35 && PlayerPrefs.GetInt("day") > 7)
                {
                    infoText.text = "Your new Level " + PlayerPrefs.GetInt("level").ToString();
                    infoTextShadow.text = infoText.text;
                    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
                    PlayerPrefs.SetInt("pullupscount", 0);
                    inGameScore = 0;
                }
                else {
                    PlayerPrefs.SetInt("pullupscount", inGameScore);
                }
                break;
            case "ClappingPullUps":
                if (PlayerPrefs.GetInt("clappingpullupscount") > 20 && PlayerPrefs.GetInt("day") > 30)
                {
                    infoText.text = "Your new Level " + PlayerPrefs.GetInt("level").ToString();
                    infoTextShadow.text = infoText.text;
                    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
                    PlayerPrefs.SetInt("clappingpullupscount", 0);
                    inGameScore = 0;
                }
                else
                {
                    PlayerPrefs.SetInt("clappingpullupscount", inGameScore);
                }
                break;
            case "MuscleUps":
                if (PlayerPrefs.GetInt("muscleupscount") > 15 && PlayerPrefs.GetInt("day") > 14)
                {
                    infoText.text = "Your new Level " + PlayerPrefs.GetInt("level").ToString();
                    infoTextShadow.text = infoText.text;
                    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
                    PlayerPrefs.SetInt("muscleupscount", 0);
                    inGameScore = 0;
                }
                else
                {
                    PlayerPrefs.SetInt("muscleupscount", inGameScore);
                }
                break;
            case "StraightBarDibs":
                if (PlayerPrefs.GetInt("straightbardibcount") > 30 && PlayerPrefs.GetInt("day") > 20)
                {
                    infoText.text = "Your new Level " + PlayerPrefs.GetInt("level").ToString();
                    infoTextShadow.text = infoText.text;
                    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
                    PlayerPrefs.SetInt("straightbardibcount", 0);
                    inGameScore = 0;
                }
                else
                {
                    PlayerPrefs.SetInt("straightbardibcount", inGameScore);
                }
                break;
            case "PullOvers":
                if (PlayerPrefs.GetInt("pullovercount") > 40 && PlayerPrefs.GetInt("day") > 30)
                {
                    infoText.text = "Your new Level " + PlayerPrefs.GetInt("level").ToString();
                    infoTextShadow.text = infoText.text;
                    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
                    PlayerPrefs.SetInt("pullovercount", 0);
                    inGameScore = 0;
                }
                else
                {
                    PlayerPrefs.SetInt("pullovercount", inGameScore);
                }
                break;
        }
        SoundController.Static.PlayScoreIncrease();
    }

    void OnDisable()
    {
        playerController.IncreaseScore -= OnScoreIncrease;
    }
}
