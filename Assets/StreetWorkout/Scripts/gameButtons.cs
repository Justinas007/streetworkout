using UnityEngine;
using System.Collections;

public class gameButtons : MonoBehaviour {

    public GameObject button;
    public Camera GPCamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    RaycastHit hit;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            Ray R = GPCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(R, out hit, 100))
            {
                switch (hit.collider.name)
                {
                    case "Replay":
                        Debug.Log("fasfasfasfa");
                        button.SetActive(false);
                        break;
                }
            }
        }

    }
}
