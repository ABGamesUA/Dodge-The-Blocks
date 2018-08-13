using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
	private const float BLOCK_SCALE = 10f;
	private const float BLOCK_LENGTH = 1.6f;	
	public static BuildManager instance;
	public GameObject rubble;
	private float leftEdgePoint;
	private float rightEdgePoint;
	// Use this for initialization
	void Start () {
		if(instance == null) instance = this;
		else if(instance != this) Destroy(gameObject);
	}
	
	public void CreateLeftRubble(Vector3 contactPoint, Vector3 blockPosition, float gvScale)
	{
		leftEdgePoint = blockPosition.x - BLOCK_LENGTH/2;
		Vector3 inst = new Vector3((leftEdgePoint+contactPoint.x)/2, blockPosition.y, blockPosition.z);
		float scl = (Mathf.Abs(leftEdgePoint-contactPoint.x)*BLOCK_SCALE)/BLOCK_LENGTH;
		FinalInstance(inst, scl, gvScale);
	}

	public void CreateRightRubble(Vector3 contactPoint, Vector3 blockPosition, float gvScale)
	{
		rightEdgePoint = blockPosition.x + BLOCK_LENGTH/2;
		Vector3 inst2 = new Vector3((rightEdgePoint+contactPoint.x)/2 , blockPosition.y, blockPosition.z);
		float scl2 = (Mathf.Abs(rightEdgePoint-contactPoint.x)*BLOCK_SCALE)/BLOCK_LENGTH;
		FinalInstance(inst2, scl2, gvScale);
	}

	public void FinalInstance(Vector3 instPosition, float scale, float _grScale)
	{
		Instantiate(rubble, instPosition, Quaternion.identity);
		rubble.transform.localScale = new Vector3(scale, 4 , 1);
		rubble.GetComponent<Rigidbody2D>().gravityScale = _grScale;
	}
	
}
