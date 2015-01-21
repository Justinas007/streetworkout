using UnityEngine;
using System.Collections;
using System;
public class playerController : MonoBehaviour {

	// Use this for initialization
    public TextMesh scoreTextMesh, ScoreShadowTextMesh, finalScoreTextMesh, infoText, infoTextShadow;
    public GameObject MainMenuContainer, ScoreBoard, Tapper, ChangeLevel, Information;
	public static EventHandler IncreaseScore, PlayerDead;
	public float playerUpwardsForce;
    public Camera MainCamera;
    RaycastHit hit;
    public float minSwipeDistY = 200;
    public float minSwipeDistX = 200;
    private Vector2 startPos;
    private int touches;

    void Start() {
        if (PlayerPrefs.GetInt("bmi") < 18.5)
            transform.localScale = new Vector3(transform.localScale.x / 1.2f, 1, 0);
        else if (PlayerPrefs.GetInt("bmi") > 18.5 && PlayerPrefs.GetInt("bmi") < 24.9)
            transform.localScale = new Vector3(1, 1, 0);
        else if (PlayerPrefs.GetInt("bmi") > 24.9 && PlayerPrefs.GetInt("bmi") < 29.9)
            transform.localScale = new Vector3(transform.localScale.x * 1.2f, 1, 0);
        else if (PlayerPrefs.GetInt("bmi") > 29.9)
            transform.localScale = new Vector3(transform.localScale.x * 1.7f, 1, 0);
    }

	// Update is called once per frame
	void Update () {
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, -Vector2.up);
        double disY = transform.position.y - hit2.transform.position.y;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray R = MainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(R, out hit, 100))
            {
                if (hit.collider.name == "PlayerMover")
                {
                    if (PlayerPrefs.GetInt("energy") > 0)
                    {
                        infoText.text = "";
                        infoTextShadow.text = infoText.text;
                        // Decrease Player energy
                        switch (PlayerPrefs.GetInt("level"))
                        {
                            case 1:
                               if (PlayerPrefs.GetInt("bmi") < 18.5)
                                    playerUpwardsForce = 0.14f;
                               else if (PlayerPrefs.GetInt("bmi") > 18.5)
                                   playerUpwardsForce = 0.34f;
                               else if (PlayerPrefs.GetInt("bmi") > 24.9)
                                   playerUpwardsForce = 0.29f;
                               else if (PlayerPrefs.GetInt("bmi") > 29.9)
                                   playerUpwardsForce = 0.14f;
                               switch (Application.loadedLevelName) { 
                                    case "PullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 55);
                                        PlayerPrefs.Save();
                                        break;
                                    case "ClappingPullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 60);
                                        PlayerPrefs.Save();
                                        break;
                                    case "MuscleUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 105);
                                        PlayerPrefs.Save();
                                        break;
                                    case "StraightBarDibs":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 85);
                                        PlayerPrefs.Save();
                                        break;
                                    case "PullOvers":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 95);
                                        PlayerPrefs.Save();
                                        break;
                                }
                                break;
                            case 2:
                                if (PlayerPrefs.GetInt("bmi") < 18.5)
                                    playerUpwardsForce = 0.16f;
                                else if (PlayerPrefs.GetInt("bmi") > 18.5)
                                    playerUpwardsForce = 0.36f;
                                else if (PlayerPrefs.GetInt("bmi") > 24.9)
                                    playerUpwardsForce = 0.31f;
                                else if (PlayerPrefs.GetInt("bmi") > 29.9)
                                    playerUpwardsForce = 0.16f;
                               switch (Application.loadedLevelName) { 
                                    case "PullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 50);
                                        PlayerPrefs.Save();
                                        break;
                                    case "ClappingPullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 55);
                                        PlayerPrefs.Save();
                                        break;
                                    case "MuscleUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 100);
                                        PlayerPrefs.Save();
                                        break;
                                    case "StraightBarDibs":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 80);
                                        PlayerPrefs.Save();
                                        break;
                                    case "PullOvers":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 90);
                                        PlayerPrefs.Save();
                                        break;
                                }
                                break;
                            case 3:
                                if (PlayerPrefs.GetInt("bmi") < 18.5)
                                    playerUpwardsForce = 0.18f;
                                else if (PlayerPrefs.GetInt("bmi") > 18.5)
                                    playerUpwardsForce = 0.38f;
                                else if (PlayerPrefs.GetInt("bmi") > 24.9)
                                    playerUpwardsForce = 0.33f;
                                else if (PlayerPrefs.GetInt("bmi") > 29.9)
                                    playerUpwardsForce = 0.18f;
                               switch (Application.loadedLevelName) { 
                                    case "PullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 45);
                                        PlayerPrefs.Save();
                                        break;
                                    case "ClappingPullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 50);
                                        PlayerPrefs.Save();
                                        break;
                                    case "MuscleUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 95);
                                        PlayerPrefs.Save();
                                        break;
                                    case "StraightBarDibs":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 75);
                                        PlayerPrefs.Save();
                                        break;
                                    case "PullOvers":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 85);
                                        PlayerPrefs.Save();
                                        break;
                                }
                                break;
                            case 4:
                                if (PlayerPrefs.GetInt("bmi") < 18.5)
                                    playerUpwardsForce = 0.20f;
                                else if (PlayerPrefs.GetInt("bmi") > 18.5)
                                    playerUpwardsForce = 0.4f;
                                else if (PlayerPrefs.GetInt("bmi") > 24.9)
                                    playerUpwardsForce = 0.35f;
                                else if (PlayerPrefs.GetInt("bmi") > 29.9)
                                    playerUpwardsForce = 0.2f;
                               switch (Application.loadedLevelName) { 
                                    case "PullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 40);
                                        PlayerPrefs.Save();
                                        break;
                                    case "ClappingPullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 45);
                                        PlayerPrefs.Save();
                                        break;
                                    case "MuscleUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 90);
                                        PlayerPrefs.Save();
                                        break;
                                    case "StraightBarDibs":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 70);
                                        PlayerPrefs.Save();
                                        break;
                                    case "PullOvers":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 80);
                                        PlayerPrefs.Save();
                                        break;
                                }
                                break;
                            case 5:
                                if (PlayerPrefs.GetInt("bmi") < 18.5)
                                    playerUpwardsForce = 0.22f;
                                else if (PlayerPrefs.GetInt("bmi") > 18.5)
                                    playerUpwardsForce = 0.42f;
                                else if (PlayerPrefs.GetInt("bmi") > 24.9)
                                    playerUpwardsForce = 0.37f;
                                else if (PlayerPrefs.GetInt("bmi") > 29.9)
                                    playerUpwardsForce = 0.22f;
                               switch (Application.loadedLevelName) { 
                                    case "PullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 35);
                                        PlayerPrefs.Save();
                                        break;
                                    case "ClappingPullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 75);
                                        PlayerPrefs.Save();
                                        break;
                                    case "MuscleUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 85);
                                        PlayerPrefs.Save();
                                        break;
                                    case "StraightBarDibs":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 65);
                                        PlayerPrefs.Save();
                                        break;
                                    case "PullOvers":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 75);
                                        PlayerPrefs.Save();
                                        break;
                                }
                                break;
                            case 6:
                                if (PlayerPrefs.GetInt("bmi") < 18.5)
                                    playerUpwardsForce = 0.24f;
                                else if (PlayerPrefs.GetInt("bmi") > 18.5)
                                    playerUpwardsForce = 0.44f;
                                else if (PlayerPrefs.GetInt("bmi") > 24.9)
                                    playerUpwardsForce = 0.39f;
                                else if (PlayerPrefs.GetInt("bmi") > 29.9)
                                    playerUpwardsForce = 0.24f;
                               switch (Application.loadedLevelName) { 
                                    case "PullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 30);
                                        PlayerPrefs.Save();
                                        break;
                                    case "ClappingPullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 70);
                                        PlayerPrefs.Save();
                                        break;
                                    case "MuscleUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 80);
                                        PlayerPrefs.Save();
                                        break;
                                    case "StraightBarDibs":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 60);
                                        PlayerPrefs.Save();
                                        break;
                                    case "PullOvers":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 70);
                                        PlayerPrefs.Save();
                                        break;
                                }
                                break;
                            case 7:
                                if (PlayerPrefs.GetInt("bmi") < 18.5)
                                    playerUpwardsForce = 0.24f;
                                else if (PlayerPrefs.GetInt("bmi") > 18.5)
                                    playerUpwardsForce = 0.46f;
                                else if (PlayerPrefs.GetInt("bmi") > 24.9)
                                    playerUpwardsForce = 0.41f;
                                else if (PlayerPrefs.GetInt("bmi") > 29.9)
                                    playerUpwardsForce = 0.26f;
                               switch (Application.loadedLevelName) { 
                                    case "PullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 25);
                                        PlayerPrefs.Save();
                                        break;
                                    case "ClappingPullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 65);
                                        PlayerPrefs.Save();
                                        break;
                                    case "MuscleUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 75);
                                        PlayerPrefs.Save();
                                        break;
                                    case "StraightBarDibs":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 55);
                                        PlayerPrefs.Save();
                                        break;
                                    case "PullOvers":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 65);
                                        PlayerPrefs.Save();
                                        break;
                                }
                                break;
                            case 8:
                                if (PlayerPrefs.GetInt("bmi") < 18.5)
                                    playerUpwardsForce = 0.28f;
                                else if (PlayerPrefs.GetInt("bmi") > 18.5)
                                    playerUpwardsForce = 0.48f;
                                else if (PlayerPrefs.GetInt("bmi") > 24.9)
                                    playerUpwardsForce = 0.43f;
                                else if (PlayerPrefs.GetInt("bmi") > 29.9)
                                    playerUpwardsForce = 0.28f;
                               switch (Application.loadedLevelName) { 
                                    case "PullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 20);
                                        PlayerPrefs.Save();
                                        break;
                                    case "ClappingPullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 60);
                                        PlayerPrefs.Save();
                                        break;
                                    case "MuscleUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 70);
                                        PlayerPrefs.Save();
                                        break;
                                    case "StraightBarDibs":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 50);
                                        PlayerPrefs.Save();
                                        break;
                                    case "PullOvers":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 60);
                                        PlayerPrefs.Save();
                                        break;
                                }
                                break;
                            case 9:
                                if (PlayerPrefs.GetInt("bmi") < 18.5)
                                    playerUpwardsForce = 0.30f;
                                else if (PlayerPrefs.GetInt("bmi") > 18.5)
                                    playerUpwardsForce = 0.50f;
                                else if (PlayerPrefs.GetInt("bmi") > 24.9)
                                    playerUpwardsForce = 0.45f;
                                else if (PlayerPrefs.GetInt("bmi") > 29.9)
                                    playerUpwardsForce = 0.30f;
                               switch (Application.loadedLevelName) { 
                                    case "PullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 15);
                                        PlayerPrefs.Save();
                                        break;
                                    case "ClappingPullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 55);
                                        PlayerPrefs.Save();
                                        break;
                                    case "MuscleUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 65);
                                        PlayerPrefs.Save();
                                        break;
                                    case "StraightBarDibs":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 45);
                                        PlayerPrefs.Save();
                                        break;
                                    case "PullOvers":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 55);
                                        PlayerPrefs.Save();
                                        break;
                                }
                                break;
                            case 10:
                                if (PlayerPrefs.GetInt("bmi") < 18.5)
                                    playerUpwardsForce = 0.32f;
                                else if (PlayerPrefs.GetInt("bmi") > 18.5)
                                    playerUpwardsForce = 0.52f;
                                else if (PlayerPrefs.GetInt("bmi") > 24.9)
                                    playerUpwardsForce = 0.47f;
                                else if (PlayerPrefs.GetInt("bmi") > 29.9)
                                    playerUpwardsForce = 0.32f;
                                switch (Application.loadedLevelName) { 
                                    case "PullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 10);
                                        PlayerPrefs.Save();
                                        break;
                                    case "ClappingPullUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 50);
                                        PlayerPrefs.Save();
                                        break;
                                    case "MuscleUps":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 60);
                                        PlayerPrefs.Save();
                                        break;
                                    case "StraightBarDibs":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 40);
                                        PlayerPrefs.Save();
                                        break;
                                    case "PullOvers":
                                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") - 50);
                                        PlayerPrefs.Save();
                                        break;
                                }
                                break;
                        }
                        
                        Tapper.SetActive(false);
                        switch (Application.loadedLevelName){
                            case "PullUps":
                                if (disY > 1.5 && disY < 3.2)
                                {
                                    rigidbody2D.AddForce(new Vector2(0, playerUpwardsForce * 100));
                                }
                                break;
                            case "ClappingPullUps":
                                if (disY > 1.5 && disY < 3.2)
                                {
                                    rigidbody2D.AddForce(new Vector2(0, playerUpwardsForce * 100));
                                }
                                break;
                            case "MuscleUps":
                                if (disY > 2.5 && disY < 4.2)
                                {
                                    rigidbody2D.AddForce(new Vector2(0, playerUpwardsForce * 100));
                                }
                                break;
                            case "StraightBarDibs":
                                if (disY > 3.3)
                                {
                                    rigidbody2D.AddForce(new Vector2(0, -playerUpwardsForce * 100));
                                }
                                break;
                            case "PullOvers":
                                if (disY > 1.5 && disY < 4.2)
                                {
                                    rigidbody2D.AddForce(new Vector2(0, playerUpwardsForce * 100));
                                }
                                break;
                        
                        }
                        //to give punch scale effect 
                        //iTween.PunchScale(gameObject, iTween.Hash("amount", new Vector3(0.06f, 0.06f, 0), "time", 1.7f, "easetype", iTween.EaseType.linear));
                        SoundController.Static.PlayBallUp(); //to play ball tap sound.
                    }
                    else
                    {
                        infoText.text = "Your energy too low\n Eat or Pass 1 day";
                        infoTextShadow.text = infoText.text;
                    }

                }
                else if (hit.collider.name == "main_menu_button") {
                    Application.LoadLevel("MainMenu");
                }
                else if (hit.collider.name == "pass_day_button")
                {
                    PlayerPrefs.SetInt("day", PlayerPrefs.GetInt("day") + 1);
                    PlayerPrefs.SetInt("energy", 3000);
                    PlayerPrefs.Save();
                }
                else if (hit.collider.name == "eat_button")
                {
                    if (PlayerPrefs.GetInt("dayLimit") == PlayerPrefs.GetInt("day"))
                    {
                        infoText.text = "Your already ate today";
                        infoTextShadow.text = infoText.text;
                    }
                    else
                    { 
                        PlayerPrefs.SetInt("energy", PlayerPrefs.GetInt("energy") + 300);
                        PlayerPrefs.SetInt("dayLimit", PlayerPrefs.GetInt("day"));
                        PlayerPrefs.Save();
                    }
                }
                else if (hit.collider.name == "change_level_button")
                {
                    Tapper.SetActive(false);
                    Information.SetActive(false);
                    ChangeLevel.transform.localScale = Vector3.zero;
                    ChangeLevel.SetActive(true);
                    iTween.ScaleTo(ChangeLevel, iTween.Hash("scale", Vector3.one, "time", 1.5f, "easetype", iTween.EaseType.easeOutSine, "delay", 0.0f));
                    //scoreTextMesh.renderer.enabled = true;
                    //ScoreShadowTextMesh.renderer.enabled = false;
                }
                else if (hit.collider.name == "tricks_list_button")
                {
                    Tapper.SetActive(false);
                    Information.SetActive(false);
                    ScoreBoard.transform.localScale = Vector3.zero;
                    ScoreBoard.SetActive(true);
                    iTween.ScaleTo(ScoreBoard, iTween.Hash("scale", Vector3.one, "time", 1.5f, "easetype", iTween.EaseType.easeOutSine, "delay", 0.0f));
                    //scoreTextMesh.renderer.enabled = true;
                    //ScoreShadowTextMesh.renderer.enabled = false;
                }
            }
        }

        if (PlayerPrefs.GetInt("energy") > 0)
        {
            switch (Application.loadedLevelName)
            {
                case "PullUps":
                    if (hit2.collider != null)
                    {
                        if (disY > 3)
                        {
                            if (Input.touchCount > 0)
                            {
                                Touch touch = Input.touches[0];

                                switch (touch.phase)
                                {
                                    case TouchPhase.Began:
                                        startPos = touch.position;
                                        break;

                                    case TouchPhase.Ended:
                                        float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                                        if (swipeDistVertical > 100)
                                        {
                                            float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                                            //up swipe
                                            if (swipeValue > 0)
                                            {
                                                rigidbody2D.AddForce(new Vector2(0, playerUpwardsForce * 400));
                                            }
                                            //down swipe
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    break;
                case "ClappingPullUps":
                    if (hit2.collider != null)
                    {
                        if (disY > 1.5)
                        {
                            if (Input.touchCount > 0)
                            {
                                Touch touch = Input.touches[0];

                                switch (touch.phase)
                                {
                                    case TouchPhase.Began:
                                        startPos = touch.position;
                                        break;

                                    case TouchPhase.Ended:
                                        float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                                        if (swipeDistHorizontal > 50)
                                        {
                                            float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                                            //right swipe
                                            if (swipeValue > 0)
                                            {
                                                rigidbody2D.AddForce(new Vector2(0, playerUpwardsForce * 400));
                                            }
                                        }
                                        break;
                                }
                            }
                        }

                    }
                    break;
                case "MuscleUps":
                    if (hit2.collider != null)
                    {
                        if (disY > 3)
                        {
                            if (Input.touchCount > 0)
                            {
                                Touch touch = Input.touches[0];

                                switch (touch.phase)
                                {
                                    case TouchPhase.Began:
                                        startPos = touch.position;
                                        break;

                                    case TouchPhase.Ended:
                                        float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                                        if (swipeDistVertical > 100)
                                        {
                                            float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                                            //up swipe
                                            if (swipeValue > 0)
                                            {
                                                rigidbody2D.AddForce(new Vector2(0, playerUpwardsForce * 400));
                                            }
                                            //down swipe
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    break;
                case "StraightBarDibs":
                    if (hit2.collider != null)
                    {
                        if (disY < 3.4)
                        {
                            if (Input.touchCount > 0)
                            {
                                Touch touch = Input.touches[0];

                                switch (touch.phase)
                                {
                                    case TouchPhase.Began:
                                        startPos = touch.position;
                                        break;

                                    case TouchPhase.Ended:
                                        float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                                        if (swipeDistVertical > 50)
                                        {
                                            float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                                            //down swipe
                                            if (swipeValue < 0)
                                            {
                                                rigidbody2D.AddForce(new Vector2(0, -playerUpwardsForce * 400));
                                            }
                                        }
                                        break;
                                }
                            }
                        }

                    }
                    break;
                case "PullOvers":
                    if (hit2.collider != null)
                    {
                        if (disY > 4.4)
                        {
                            if (Input.touchCount > 0)
                            {
                                Touch touch = Input.touches[0];

                                switch (touch.phase)
                                {
                                    case TouchPhase.Began:
                                        startPos = touch.position;
                                        break;

                                    case TouchPhase.Ended:
                                        float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                                        if (swipeDistVertical > 100)
                                        {
                                            float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                                            //up swipe
                                            if (swipeValue > 0)
                                            {
                                                rigidbody2D.AddForce(new Vector2(0, playerUpwardsForce * 400));
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    break;

            }
        }


	}

	void OnTriggerEnter2D(Collider2D coll)
    {
		//if player collides with score trigger we will increment score
		if (coll.name.Contains("Score")){
			 if(IncreaseScore != null)
             IncreaseScore(null,null);//to fire the score increment event,uicontroller will uses this event
		 }
	}
}
