using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour
{

	public GameObject EnemyPrefab;
	public float GizmoWidth = 6.74f;
	public float GizmoHeight = 4.42f;
	public float Speed = 5f;

	private float _xMax;
	private float _xMin;
	private bool _movingRight = true;

	
	// Use this for initialization
	void Start ()
	{
		GetScreenLimits();
		
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = this.transform.GetChild(i);
			GameObject enemy = Instantiate(EnemyPrefab, child.position, Quaternion.identity);
			enemy.transform.parent = child.transform;
		}
		
		/*foreach (Transform child in this.transform)
		{
			GameObject enemy = Instantiate(EnemyPrefab, child.position, Quaternion.identity);
			enemy.transform.parent = child.transform;
		}*/

	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(GizmoWidth, GizmoHeight));
	}

	// Update is called once per frame
	void Update ()
	{
		if (_movingRight)
		{
			transform.position += Vector3.right * Speed * Time.deltaTime;
		}
		else
		{
			transform.position += Vector3.left * Speed * Time.deltaTime;
		}
		
		
		float widthPadding = GizmoWidth * 0.5f;


		if ((transform.position.x + widthPadding) > _xMax)
		{
			_movingRight = false;
		}
		else if((transform.position.x - widthPadding) < _xMin )
		{
			_movingRight = true;

		}
		
	}

	private void GetScreenLimits()
	{
		float distance = Camera.main.transform.position.z - gameObject.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));

		_xMin = leftMost.x;
		_xMax = rightMost.x;
	}
}
