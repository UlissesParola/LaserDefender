using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class PlayerController : MonoBehaviour
{

	public float SpaceShipVelocity = 15f;

	private Rigidbody2D _playerRigidbody2D;
	private float _minX = -6.5f;
	private float _maxX = 6.5f;
	
	// Use this for initialization
	void Start ()
	{
		_playerRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			//transform.position += new Vector3(-SpaceShipVelocity, 0f, 0f);
			_playerRigidbody2D.velocity =  new Vector3(-SpaceShipVelocity, 0f, 0f);
		}
		
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			//transform.position += new Vector3(SpaceShipVelocity, 0f, 0f);
			_playerRigidbody2D.velocity =  new Vector3(SpaceShipVelocity, 0f, 0f);
		}
		
		Vector3 positionLimits = new Vector3(Mathf.Clamp(gameObject.transform.position.x, _minX, _maxX), gameObject.transform.position.y, 0);
		gameObject.transform.position = positionLimits ;
	}
}
