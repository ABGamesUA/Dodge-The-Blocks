using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {	
	public GameObject pauseMenu;	

	float slowMoCount = 10f;
	public static bool isOver;
	public AudioClip fail;
	public AudioClip click;
			
	private void Start()
	{
		isOver = false;
	}
	public void EndGame()
	{	
		PlayerMovement.instance.enabled = false;	
		isOver = true;
		SoundManager.instance.PlaySoundEffect(fail);
		SoundManager.instance.StopTimeEffect();	
		StartCoroutine(RestartLevel());	
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) )
		{
			Toggle();
		}
	}

	IEnumerator RestartLevel()
	{
		Time.timeScale = 1/slowMoCount;
		Time.fixedDeltaTime /= slowMoCount;
		yield return new WaitForSeconds(1f/slowMoCount);
		Time.timeScale = 1f;
		Time.fixedDeltaTime *= slowMoCount;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public static void BuildRubble(Vector2 pos,  Vector2 contactPoint)
	{
		Debug.Log(contactPoint.ToString());
	}

	public void Toggle()
	{		
		SoundManager.instance.timeEffect.mute = !SoundManager.instance.timeEffect.mute;
		PlayerMovement.instance.enabled = !PlayerMovement.instance.enabled;
		SoundManager.instance.PlaySoundEffect(click);
		pauseMenu.SetActive(!pauseMenu.activeSelf);
		if(pauseMenu.activeSelf){
			Time.timeScale = 0f;
		}else
		{
			Time.timeScale = 1f;
		}

	}

	public void Menu()
	{
		SoundManager.instance.PlaySoundEffect(click);		
	}

}
