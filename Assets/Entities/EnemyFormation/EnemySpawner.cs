using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

	public GameObject EnemyPrefab;
	
	// Use this for initialization
	void Start ()
	{
		foreach (Transform child in this.transform)
		{
			GameObject enemy = Instantiate(EnemyPrefab, child.position, Quaternion.identity);
			enemy.transform.parent = child.transform;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
