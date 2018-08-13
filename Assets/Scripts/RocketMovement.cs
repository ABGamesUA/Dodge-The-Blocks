using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RocketMovement : MonoBehaviour {
	GameObject player;
	private Vector3 offcet;		
	float speed = 5f;
	public bool isShoot;
	public AudioClip shootRocket;
	public UnityEvent playDestroyEff;		
	
	private void Start()
	{		
		gameObject.tag = "OnPlayer";
		isShoot = false;
		player = GameObject.FindGameObjectWithTag("Player");		
		offcet = new Vector3(0, 0.15f, 0);
	}
	void FixedUpdate () {
		if(PlayerMovement.isUT == true && isShoot == false) gameObject.GetComponent<EdgeCollider2D>().isTrigger = true;
		else if(PlayerMovement.isUT == false)  gameObject.GetComponent<EdgeCollider2D>().isTrigger = false;
		if(transform.position.y > 12f)Destroy(gameObject);		// Shooting the rocket
		if(Input.GetKeyDown(KeyCode.Space))Shoot();			
		if(isShoot) transform.position = transform.position + (Vector3.up * Time.fixedDeltaTime * speed); 
		else if(!isShoot)transform.position = player.transform.position + offcet;
		else return;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(isShoot)
		{	
			playDestroyEff.Invoke();
			if(other.gameObject.tag == "Block")
			{
				//Debug.Log(other.contacts[0].point.ToString());
				//BuildManager.instance.CreateLeftRubble(transform.localPosition, other.gameObject.transform.localPosition, other.gameObject.GetComponent<Rigidbody2D>().gravityScale);
				//BuildManager.instance.CreateRightRubble(transform.localPosition, other.gameObject.transform.localPosition, other.gameObject.GetComponent<Rigidbody2D>().gravityScale);
				Destroy(other.gameObject);	
			}						
					
		}
		else if(other.gameObject.tag == "Block" || other.gameObject.tag == "Rubble" )FindObjectOfType<GameManager>().EndGame();
		else return; 
	}	

	IEnumerator UnTCH()
	{	
		gameObject.GetComponent<EdgeCollider2D>().isTrigger = true;
		yield return new WaitForSeconds(5f);
		gameObject.GetComponent<EdgeCollider2D>().isTrigger = false;
	}

	public void Shoot()
	{
		if(isShoot == false){
				isShoot = true;
				gameObject.tag = "Rocket";
				PlayerStats.haveRockets--;
				PlayerMovement.haverocket = false;
				gameObject.GetComponent<EdgeCollider2D>().isTrigger = false;
		}
	}
	
}
