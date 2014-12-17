using UnityEngine;
using System.Collections;

public class playerAnimation : MonoBehaviour {

    private SpriteRenderer sr;
    public Sprite sprite1, sprite2, sprite3, sprite4, sprite5, sprite6, sprite7, sprite8, sprite9, keeper;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null)
        {
            Debug.Log(hit.transform.gameObject.name);
            double disY = transform.position.y - hit.transform.position.y;


            if (disY < 5.8)
                keeper = sprite1;
            if (disY > 6)
            {
                keeper = sprite2;
                if (disY > 7.1)
                {
                    keeper = sprite4;
                    if (disY > 7.3)
                    {
                        keeper = sprite5;
                    }
                }
            }
            sr.sprite = keeper;
        }
        else
            Debug.Log("no raycast");
	
	}
}
