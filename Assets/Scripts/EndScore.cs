using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		GetComponent<Text>().text = Score.Points.ToString();
		Score.Reset();
	}

}