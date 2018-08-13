using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {			
	void Start () {
		GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 40f;		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -0.5f)
		{			
			Destroy(gameObject);				
		}
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{		
		if(other.gameObject.tag == "Player")	FindObjectOfType<GameManager>().EndGame();
	}	
}
