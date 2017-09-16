using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

	private AudioSource _shieldImpact;
	// Use this for initialization
	void Start ()
	{
		_shieldImpact = GetComponent<AudioSource>();
	}

	public void PlaySound()
	{
		_shieldImpact.Play();
	}
}
