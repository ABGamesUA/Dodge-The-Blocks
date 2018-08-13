using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottonUI : MonoBehaviour {
	public Text rocketCount;
	public Text slowmoCount;
	public Text untouchCount;		
	
	// Update is called once per frame
	void Update () {
		rocketCount.text = PlayerStats.haveRockets.ToString();
		slowmoCount.text = PlayerStats.haveSlowMo.ToString();
		untouchCount.text = PlayerStats.haveUnTouch.ToString();	
	}

}
