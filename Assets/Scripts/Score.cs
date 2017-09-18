using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	private Text _scorePointsText;
	public static int Points = 0;

	private void Start()
	{
		_scorePointsText = GetComponent<Text>();
	}

	public static void Reset()
	{
		Points = 0;
	}

	public void ScorePoints(int points)
	{
		Points += points;
		_scorePointsText.text = Points.ToString();
	}
}
