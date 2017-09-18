using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR.WSA.WebCam;

public class MusicPlayer : MonoBehaviour {

	private MusicPlayer _instance;
	private AudioSource _audioSource;

	void Awake()
	{
		if (_instance != null && _instance == this)
		{
			Destroy(gameObject);
		}
		else
		{	
			_instance = this;
			_audioSource = GetComponent<AudioSource>();
			DontDestroyOnLoad(gameObject);
		}

	}

	public void PlayClip(AudioClip clip)
	{
		_audioSource.clip = clip;
		_audioSource.Play();
	}
}
