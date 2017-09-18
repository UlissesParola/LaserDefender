using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

	public EnemyFormation[] Formation;

	private int wave = 0;

	private void Start()
	{
		InstantiateEnemies();
	}

	public void InstantiateEnemies()
	{
		if (wave >= Formation.Length)
		{
			wave = 0;
		}
		
		Instantiate(Formation[wave], Formation[wave].transform.position, Quaternion.identity);
		wave++;
	}
}
