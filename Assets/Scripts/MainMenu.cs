using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public Text bestScore;	
	public GameObject infoPanel;
	public AudioClip click;
	
	private void Start()
	{
		Time.timeScale = 1;	
		bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
	}
	
	public void Play()
	{
		SoundManager.instance.PlaySoundEffect(click);		
	}

	public void Exit()
	{
		SoundManager.instance.PlaySoundEffect(click);
		Application.Quit();
	}

	public void Info()
	{
		SoundManager.instance.PlaySoundEffect(click);
		infoPanel.SetActive(!infoPanel.activeSelf);		
	}
	
}
