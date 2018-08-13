using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpavner : MonoBehaviour {
	public Transform[] spawnPoints;	
	public GameObject[] spawnItems; 
	GameObject finalItemToSpawn;	
	bool isspawn;
	
	private void Update()
	{
		if(BlockSpavner.waves % 3 != 0)
		{
			isspawn = false;
		}		
		if(BlockSpavner.waves % 3 == 0 && isspawn == false)
			{
				Spawn();
			}
		

	}

	void Spawn(){
		isspawn = true;				
		int randomIndex = Random.Range(0, spawnPoints.Length);
		int randomItemNumber = Random.Range(0, spawnItems.Length);
		for (int i = 0; i < spawnItems.Length; i++)
		{
			if(i == randomItemNumber)
			{
				finalItemToSpawn = spawnItems[i];				
			}
		}	
		for (int i = 0; i < spawnPoints.Length; i++)
		{
			if(i == randomIndex)
			{
				Instantiate(finalItemToSpawn, spawnPoints[i].position, Quaternion.identity);				
			}
		}	
	}
}
