using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

	public GameObject EnemyPrefab;
	
	// Use this for initialization
	void Start ()
	{
		GameObject enemy = Instantiate(EnemyPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
		enemy.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
