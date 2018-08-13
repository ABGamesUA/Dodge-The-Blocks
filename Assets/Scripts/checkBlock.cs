using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkBlock : MonoBehaviour {		
	void Start () {
		GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 40f;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -0.5f)
		{
			FindObjectOfType<BlockSpavner>().UpdateWaves();
			Destroy(gameObject);				
		}
	}	
}
