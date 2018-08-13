using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpavner : MonoBehaviour {
	public Transform[] spawnPoints;	
	public Transform checkPoint;
	public GameObject block;
	public GameObject checkBlock;
	public float TimebwWaves = 1f;
	private float TimeToSpawn = 2f;	
	public static int waves;
	public Text waveText;
	public Text timer;
	
	private void Start()
	{
		waves = 0;
	}
	// Update is called once per frame
	void Update () {
		if(Time.time >= TimeToSpawn)
		{
			Spawn();
			TimeToSpawn = TimebwWaves + Time.time;
		}
		waveText.text = waves.ToString()+ " WAWES";
		timer.text = string.Format("{0:00.00}", Time.timeSinceLevelLoad);		
	}

	void Spawn(){			
		int randomIndex = Random.Range(0, spawnPoints.Length);
		for (int i = 0; i < spawnPoints.Length; i++)
		{
			if(i != randomIndex)
			{
				Instantiate(block, spawnPoints[i].position, Quaternion.identity);
			}
		}
		Instantiate(checkBlock, checkPoint.position, Quaternion.identity);
	}

	public void UpdateWaves()
	{	
		if(!GameManager.isOver)
		{
			waves++;	
			if(PlayerPrefs.GetInt("BestScore") < waves) PlayerPrefs.SetInt("BestScore", waves);	
		}
		else return;
			
	}
}
