using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	private Text _scorePointsText;
	private int _scorePoints = 0;

	private void Start()
	{
		_scorePointsText = GetComponent<Text>();
	}

	public void Reset()
	{
		_scorePoints = 0;
		_scorePointsText.text = _scorePoints.ToString();
	}

	public void ScorePoints(int points)
	{
		_scorePoints += points;
		_scorePointsText.text = _scorePoints.ToString();
	}
}
