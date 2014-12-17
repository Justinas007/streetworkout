using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	// Use this for initialization
    public TextMesh staminaTextMesh, staminaShadowTextMesh, scoreTextMesh, ScoreShadowTextMesh, finalScoreTextMesh, BestScoreTextMesh;
	int inGameScore = 0;
	public GameObject Player, InGameUIContainer, staminaInputField, staminaText, scoreText, newScoreObj, ScoreBoard, MainMenuContainer, Tutorial, QuitButton, Inputs;
    string staminastring;
    int staminaInt = 0;
 
    public Camera UICamera;
	public static bool isRestartPressed  = false;
	bool readyToPlay  = false;

	void OnEnable(){
		playerController.IncreaseScore += OnScoreIncrease;
		playerController.PlayerDead += OnPlayerDead;
		MainMenuContainer.SetActive(true);
		ScoreBoard.SetActive(false);

		//on game end scoreboard menu ,if user presses on restart ,
		//we need to disable the mainmenu and changing player to readyto play.
		if(isRestartPressed)
		{ MainMenuContainer.SetActive(false);
			isRestartPressed = false;
			readyToPlay = true;
		} 
		else {
			playerController.currentState = playerController.playerStates.idle;

		}

 
		#if UNITY_IOS
		//apple won't like quit button
		Destroy(QuitButton);
		#endif
        //to display messsage to developers


	}
	 
	// Update is called once per frame
	RaycastHit hit ;
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0) )
		{

//			Debug.Log(playerController.currentState);
			Ray R = UICamera.ScreenPointToRay(Input.mousePosition);
			if( readyToPlay && playerController.currentState == playerController.playerStates.idle)
			{
				playerController.currentState = playerController.playerStates.alive;
				readyToPlay = false;
				iTween.ScaleTo(Tutorial,iTween.Hash("scale",Vector3.zero,"time",0.5f,"easetype",iTween.EaseType.linear));
				iTween.FadeTo(Tutorial,iTween.Hash("alpha",0,"time",0.2f,"easetype",iTween.EaseType.linear));
			}
			if(Physics.Raycast(R,out hit,100))
			{
				iTween.ScaleTo(hit.collider.gameObject,iTween.Hash("scale",new Vector3(0.45f,0.45f,0.45f),"time",0.5f,"easetype",iTween.EaseType.easeInOutBounce));
				SoundController.Static.PlayClickSound();
				switch(hit.collider.name)
				{
					
				 
				case "Play":
                    Text text = staminaInputField.GetComponent<Text>();
                    staminastring = text.text;
                    staminaInt = int.Parse(staminastring);
					MainMenuContainer.SetActive(false);
                    InGameUIContainer.SetActive(true);
                    Player.SetActive(true);
					Tutorial.SetActive(true);
                    Inputs.SetActive(false);
                    readyToPlay = true;
				 
					break;
				}
			 
			}





		}

		if(Input.GetKeyUp(KeyCode.Mouse0) )
		{
			 
			Ray R = UICamera.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(R,out hit,100))
			{

				switch(hit.collider.name)
				{		
	
				case "Home":
					
					restart();
					break;
					
				case "PullUps_Text":
                    Application.LoadLevel("SplashScreen");
					break;

				case "Review":
					#if UNITY_ANDROID
					Application.OpenURL("https://www.facebook.com/AceGamesHyderabad?ref=hl");
					#endif
					#if UNITY_IOS
					Application.OpenURL("https://www.facebook.com/AceGamesHyderabad?ref=hl");
					#endif
					#if UNITY_WEBPLAYER
					Application.OpenURL("https://www.facebook.com/AceGamesHyderabad?ref=hl");
					#endif
					#if UNITY_EDITOR
					Application.OpenURL("https://www.facebook.com/AceGamesHyderabad?ref=hl");
					#endif

					break;

				case "Quit":

					Application.Quit();

					break;

               case "Tricks":
                    Debug.Log("eina");
                    break;

				}
			}
			
		}

	
		//to handle escape key
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			if( playerController.currentState ==playerController.playerStates.idle)
			{
				
				Application.Quit();
			}
			else {
				
				restart();
			}
			
		}
	}


	public void restart()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}

	void OnScoreIncrease(System.Object obj,EventArgs args) 
	{
		inGameScore++;
        staminaInt--;
        staminaTextMesh.text = "Stamina: " + staminaInt;
        staminaShadowTextMesh.text = "Stamina: " + staminastring;
        scoreTextMesh.text ="Times: "+ inGameScore;
		ScoreShadowTextMesh.text="Times: "+inGameScore;
		SoundController.Static.PlayScoreIncrease();
	}
	void OnPlayerDead(System.Object obj,EventArgs args)
	{
		ScoreBoard.transform.localScale = Vector3.zero;
		ScoreBoard.SetActive(true);

      
	 	iTween.ScaleTo(ScoreBoard,iTween.Hash("scale",Vector3.one,"time",1.5f,"easetype",iTween.EaseType.easeOutSine,"delay",1.0f));
		scoreTextMesh.renderer.enabled = false;
		ScoreShadowTextMesh.renderer.enabled= false;
		finalScoreTextMesh.text = "Score : "+inGameScore;

		if(PlayerPrefs.GetInt("BestScore",0) < inGameScore ){
			PlayerPrefs.SetInt("BestScore",inGameScore);
			newScoreObj.SetActive(true);
		}

		BestScoreTextMesh.text = "Best : " + PlayerPrefs.GetInt("BestScore",inGameScore);

	}
	void OnDisable()
	{

		playerController.IncreaseScore -= OnScoreIncrease;
		playerController.PlayerDead -= OnPlayerDead;

		 
	}
}
