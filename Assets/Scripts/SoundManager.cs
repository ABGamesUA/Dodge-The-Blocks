using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource musicBG;
	public AudioSource paralelAS;
	public AudioSource soundEffect;
	public AudioSource timeEffect;
	public static SoundManager instance = null;
	
	private void Awake()
	{
		if(instance == null) instance = this;
		else if(instance != this) Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
	}

	public void PlaySingle(AudioClip clip)
	{		
		musicBG.clip = clip;
		musicBG.Play();
		
	}
	public void ParalelChanel (AudioClip clip)
	{		
		paralelAS.clip = clip;
		paralelAS.Play();
	}

	public void PlaySoundEffect(AudioClip clip)
	{		
		if(soundEffect.clip != null) ParalelChanel(clip);
		else{
		soundEffect.clip = clip;
		soundEffect.Play();
		}
	}

	public void PlayTimeEffect()
	{		
		timeEffect.Play();
	}
	public void StopTimeEffect()
	{		
		timeEffect.Stop();
	}

}
