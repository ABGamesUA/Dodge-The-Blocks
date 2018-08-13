using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	public static PlayerMovement instance = null;
	Rigidbody2D rb;
	RocketMovement rm;
	public Sprite unToch;
	public Sprite normal;
	float mapWidth = 5.25f;
	float slowMoCount = 10f;
	float speed = 15f;
	public GameObject rocketGO;
	Vector3 offcet;
	public static bool haverocket = false;
	public static bool isUT;
	bool isSM;
	private float countDown;
	private float countDownSm;
	public GameObject TimerSM;
	public GameObject TimerUT;
	public Text TextSM;
	public Text TextUT;	
	[Header("Sound Effects")]
	public AudioClip unTouch;
	public AudioClip endUnTouch;	
	public AudioClip startSlowMO;
	public AudioClip endSlowMO;
	public AudioClip ShootTheRocket;
	public AudioClip TakeItem;
	public AudioClip destrouEff;
	public AudioClip getReady;	

	private void Awake()
	{
		if(instance == null) instance = this;
		else if(instance != this) Destroy(gameObject);
	}
	
	void Start () {		
		PlayerMovement.instance.enabled = true;
		SoundManager.instance.PlaySoundEffect(getReady);
		SoundManager.instance.StopTimeEffect();	
		rb = GetComponent<Rigidbody2D>();
		offcet = new Vector3(0, 0.1f, 0);
		haverocket = false;	
	}	

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.T))	UseTime();
		if(Input.GetKeyDown(KeyCode.U))UseUnToduch();		
	}	  

	 void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.Space))UseRocket();
		if(PlayerStats.haveRockets > 0 && !haverocket)	InstantiateRocket();		
		float translation_x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;	
		Vector2 newPosition = rb.position + Vector2.right * translation_x;
		newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth); 		
		rb.MovePosition(newPosition);		
		
		if (isSM)
		{
			if(countDownSm >= 0)
			{
				TimerSM.SetActive(true);
				TextSM.text = string.Format("{0:00.00}", countDownSm);			
				countDownSm -=Time.deltaTime*slowMoCount;				
				Time.timeScale = 1/slowMoCount;
				Time.fixedDeltaTime /= slowMoCount;
				speed = 120f;				
			} 
			else 
			{					
				TimerSM.SetActive(false);
				SoundManager.instance.PlaySoundEffect(endSlowMO);
				SoundManager.instance.StopTimeEffect();		
				Time.timeScale = 1f;
				Time.fixedDeltaTime *= slowMoCount;
				speed = 15f;
				isSM = false; 				
			}
		}
		if(isUT)
		{
			if(countDown >= 0)
			{
				TimerUT.SetActive(true);
				TextUT.text = string.Format("{0:00.00}", countDown);	
				if(isSM) countDown -=Time.deltaTime*slowMoCount;
				else countDown -=Time.deltaTime;
				gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
				gameObject.GetComponent<SpriteRenderer>().sprite = unToch;	
			} 
			else 
			{					
				TimerUT.SetActive(false);
				SoundManager.instance.PlaySoundEffect(endUnTouch);			
				gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
				gameObject.GetComponent<SpriteRenderer>().sprite = normal;
				isUT = false; 				
			}	
		}
							
	}	

	void InstantiateRocket()
	{
		haverocket = true;
		Instantiate(rocketGO, transform.position + offcet, Quaternion.identity);
	}

	public void PlayItemEff()
	{
		SoundManager.instance.PlaySoundEffect(TakeItem);
	}

	public void PlayDestroyEff()
	{
		SoundManager.instance.PlaySoundEffect(destrouEff);
	}	

	public void UseTime()
	{
		if(PlayerStats.haveSlowMo > 0) {					
			SoundManager.instance.PlaySoundEffect(startSlowMO);
			SoundManager.instance.PlayTimeEffect();
			isSM = true;			
			countDownSm = 5f;						
			PlayerStats.haveSlowMo -= 1;								
		}
	}

	public void UseUnToduch()
	{
		if(PlayerStats.haveUnTouch > 0){
			SoundManager.instance.PlaySoundEffect(unTouch);
			isUT = true;
			countDown = 5f;
			PlayerStats.haveUnTouch--;}	
	}
	public void UseRocket()
	{
		if(PlayerStats.haveRockets > 0) SoundManager.instance.PlaySoundEffect(ShootTheRocket);
	}		

}
