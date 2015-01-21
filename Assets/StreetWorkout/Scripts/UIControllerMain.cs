using UnityEngine;
using System.Collections;

public class UIControllerMain : MonoBehaviour 
{    
    public Camera UICamera;
    RaycastHit hit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray R = UICamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(R, out hit, 100))
            {
                iTween.ScaleTo(hit.collider.gameObject, iTween.Hash("scale", new Vector3(1.1f, 1.1f, 1.1f), "time", 0.5f, "easetype", iTween.EaseType.easeInOutBounce));
                SoundController.Static.PlayClickSound();
                switch (hit.collider.name)
                {
                    case "start_button":
                        Application.LoadLevel("PullUps");
                        break;
                    case "instructions_button":
                        Application.LoadLevel("Instructions");
                        break;
                    case "exit_button":
                        Application.Quit();
                        break;
                    case "main_menu_button":
                        Application.LoadLevel("MainMenu");
                        break;
                }

            }

        }
    }
}
