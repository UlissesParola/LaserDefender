using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
	public AudioClip Clip;
	
	private static Scene _oldScene;
	private static Scene _activeScene;

	// Use this for initialization
	private void Awake()
	{
		_oldScene = _activeScene;
		_activeScene = SceneManager.GetActiveScene();
		
		Debug.Log(_oldScene.name);
		Debug.Log(_activeScene.name);

		if (_activeScene.name == "Start Menu" && !GameObject.Find("MusicPlayer").GetComponent<AudioSource>().isPlaying)
		{
			GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>().PlayClip(Clip);
		}
		if (_activeScene.name == "Game")
		{
			GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>().PlayClip(Clip);
		}
		if (_activeScene.name == "End Screen")
		{
			GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>().PlayClip(Clip);
		}
	}	
}
