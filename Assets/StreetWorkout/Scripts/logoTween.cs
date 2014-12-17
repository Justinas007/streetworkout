using UnityEngine;
using System.Collections;

public class logoTween : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.ScaleTo(gameObject,iTween.Hash("scale",new Vector3(1.2f,1.2f,0),"time",0.8f,"easetype",iTween.EaseType.linear,"looptype",iTween.LoopType.pingPong));
	}
	
}
