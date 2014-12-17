using UnityEngine;
using System.Collections;
using System;
public class playerController : MonoBehaviour {

	// Use this for initialization
    public TextMesh scoreTextMesh, ScoreShadowTextMesh, finalScoreTextMesh;
    public GameObject MainMenuContainer, ScoreBoard, Tapper;
	public static EventHandler IncreaseScore, PlayerDead;
	public float playerUpwardsForce;
    public Camera MainCamera;
    RaycastHit hit;

	//these player states will give us ,current state .wheather game starts or player is dead etc.
	public enum playerStates{

		idle,alive,dead
	}
	public static playerStates currentState ;

	void Start () {
	
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray R = MainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(R, out hit, 100))
            {
                if (hit.collider.name == "PlayerMover")
                {
                    Tapper.SetActive(false);
                    //when user taps ,add force to the ball
                    rigidbody2D.AddForce(new Vector2(0, playerUpwardsForce * 100));
                    //to give punch scale effect 
                    iTween.PunchScale(gameObject, iTween.Hash("amount", new Vector3(0.06f, 0.06f, 0), "time", 1.7f, "easetype", iTween.EaseType.linear));
                    currentState = playerStates.alive; //changing ball/player state to alive 
                    SoundController.Static.PlayBallUp(); //to play ball tap sound.
                }
                else if (hit.collider.name == "MainMenuButton") {
                    Application.LoadLevel(Application.loadedLevelName);
                }
                else if (hit.collider.name == "Replay")
                {
                    Application.LoadLevel("SplashScreen");
                }
                else if (hit.collider.name == "TricksButton")
                {
                    ScoreBoard.transform.localScale = Vector3.zero;
                    ScoreBoard.SetActive(true);
                    iTween.ScaleTo(ScoreBoard, iTween.Hash("scale", Vector3.one, "time", 1.5f, "easetype", iTween.EaseType.easeOutSine, "delay", 0.0f));
                    //scoreTextMesh.renderer.enabled = true;
                    //ScoreShadowTextMesh.renderer.enabled = false;


                }

            }
        }


	}


	void OnCollisionEnter2D(Collision2D coll) {
		//if player collides with enemy , ie left or right white bar .
		if (coll.gameObject.tag == "Enemy"){
			currentState = playerStates.dead;//changing state to dead, so the camera will also track the ball falldown 
			iTween.PunchPosition(gameObject,iTween.Hash("amount",new Vector3(0.4f,0.0f,0),"time",0.6f,"easetype",iTween.EaseType.easeInOutBounce));
			if(PlayerDead != null) PlayerDead(null,null);//to say every script that player is dead.those who every register to this event will fire their statements ,for ex uicontroller or Admanager
			SoundController.Static.PlayGameOver(); //to play sound
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {

		//if player collides with score trigger we will increment score
		if (coll.name.Contains("Score")){
			 if(IncreaseScore != null)
             IncreaseScore(null,null);//to fire the score increment event,uicontroller will uses this event
			 //coll.name ="USED"; //to avoid repeated trigger enter events
		 }
	}
}
