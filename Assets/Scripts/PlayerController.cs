using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class PlayerController : MonoBehaviour
{
	public float ShipPadding = 0.5f;
	public float Speed = 150f;

	private Rigidbody2D _playerRigidbody2D;
	private float _xMin;
	private float _xMax;
	
	// Use this for initialization
	void Start ()
	{
		float distance = Camera.main.transform.position.z - gameObject.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));

		_xMin = leftMost.x + ShipPadding; 
		Debug.Log(_xMin);
		_xMax = rightMost.x - ShipPadding;
		Debug.Log(_xMax);
		_playerRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//MovimentByPosition();

		//Vector3 positionLimits
		gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, _xMin, _xMax), gameObject.transform.position.y, 0);
		//gameObject.transform.position = positionLimits ;	
	}

	void FixedUpdate()
	{
		MovimentByForce();
	}

	private void MovimentByForce()
	{
		float directionX = Input.GetAxis("Horizontal");
		_playerRigidbody2D.AddForce(new Vector3(Speed * directionX, 0f, 0f));
	}
	
	private void MovimentByPosition()
	{
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			transform.position += Vector3.left * Speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			transform.position += Vector3.right * Speed * Time.deltaTime;
		}
	}

}
