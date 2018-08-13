using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTochItem : MonoBehaviour {	
	public UnityEvent playSoundEffect;
	public UnityEvent destroyEffect;

	private void OnTriggerEnter2D(Collider2D other)	
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "OnPlayer")
		{
			PlayerStats.haveUnTouch++;
			playSoundEffect.Invoke();			
			Destroy(gameObject);
		}		
		else if(other.gameObject.tag == "Rocket")
		{ 
			destroyEffect.Invoke();
			Destroy(gameObject);
		}		
	}

	private void Update()
	{
		if(transform.position.y < -2f) Destroy(gameObject);
	}
}
