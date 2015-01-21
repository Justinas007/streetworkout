using UnityEngine;
using System.Collections;

public class playerAnimation : MonoBehaviour {

    private SpriteRenderer sr;
    public Sprite pullupstill, pullup1, pullup2, pullup3, pullup4, clappingpullstill, clappingpull1, clappingpull2,
        clappingpull3, clappingpull4, muscleupstill, muscleup1, muscleup2, muscleup3, muscleup4, pulloverstill,
        pullover1, pullover2, pullover3, pullover4, straightbarstill, straightbar1, straightbar2, straightbar3,
        straightbar4, keeper;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        switch (Application.loadedLevelName)
        {
            case "PullUps":
                if (hit.collider != null)
                {
                    double disY = transform.position.y - hit.transform.position.y;
                    if (disY < 3)
                        keeper = pullupstill;
                    if (disY > 3.15)
                    {
                        keeper = pullup1;
                        if (disY > 3.25)
                        {
                            keeper = pullup2;
                            if (disY > 3.875)
                            {
                                keeper = pullup3;
                            }
                            if (disY > 4.5)
                            {
                                keeper = pullup4;
                            }
                        }
                    }
                    sr.sprite = keeper;
                }
                break;
            case "ClappingPullUps":
                if (hit.collider != null)
                {
                    double disY = transform.position.y - hit.transform.position.y;
                    if (disY < 3)
                        keeper = pullupstill;
                    if (disY > 3.15)
                    {
                        keeper = pullup1;
                        if (disY > 3.25)
                        {
                            keeper = pullup2;
                            if (disY > 3.875)
                            {
                                keeper = pullup3;
                            }
                            if (disY > 4.5)
                            {
                                keeper = pullup4;
                            }
                        }
                    }
                    sr.sprite = keeper;
                }
                break;
            case "MuscleUps":
                if (hit.collider != null)
                {
                    double disY = transform.position.y - hit.transform.position.y;
                    Debug.Log(disY);
                    if (disY < 3.75)
                        keeper = muscleupstill;
                    if (disY > 4.6)
                    {
                        keeper = muscleup1;
                        if (disY > 4.8)
                        {
                            keeper = muscleup2;
                            if (disY > 5)
                            {
                                keeper = muscleup3;
                            }
                        }
                    }
                    sr.sprite = keeper;
                }
                break;
            case "PullOvers":
                if (hit.collider != null)
                {
                    double disY = transform.position.y - hit.transform.position.y;
                    Debug.Log(disY);
                    if (disY < 3.75)
                        keeper = pulloverstill;
                    if (disY > 3.75)
                    {
                        keeper = pullover1;
                        if (disY > 4.5)
                        {
                            keeper = pullover2;
                            if (disY > 4.9)
                            {
                                keeper = pullover3;
                            }
                            if (disY > 5.5)
                            {
                                keeper = pullover4;
                            }
                        }
                    }
                    sr.sprite = keeper;
                }
                break;
            case "StraightBarDibs":
                if (hit.collider != null)
                {      
                    double disY = transform.position.y - hit.transform.position.y;
                    if (disY > 2.5)
                        keeper = straightbar2;
                    if (disY > 2.8)
                    {
                        keeper = straightbar1;
                        if (disY > 3.35)
                        {
                            keeper = straightbarstill;
                        }
                    }
                    sr.sprite = keeper;
                }
                break;
        }
	}
}
