using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

	public Animator animator;
	int _index;
	// Update is called once per frame
	void Update () {
		
	}

	public void FadeToLevel (int Index)
	{
		_index = Index;
		animator.SetTrigger("FadeOut");
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene(_index);
	}
}
