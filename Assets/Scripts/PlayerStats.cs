using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	public static int haveRockets;
	public static int haveSlowMo;
	public static int haveUnTouch;

	private void Start()
	{
		haveRockets = 0;
		haveSlowMo = 0;
		haveUnTouch = 0;
	}	
}
