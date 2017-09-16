using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.Experimental.Director;

public class PlayerController : MonoBehaviour
{
	public float ShipPadding = 0.5f;
	public float Speed = 150f;
	public GameObject Laser;
	public float LaserSpeed = 10f;
	public float LaserFireRating = 0.5f;
	public float PlayerHitpoint = 50f;
	
	
	private Animator _shieldAnimator;
	private Rigidbody2D _playerRigidbody2D;
	private float _xMin;
	private float _xMax;
	private float _yMin;
	private float _yMax;
	
	// Use this for initialization
	void Start ()
	{
		GetScreenLimits();

		_shieldAnimator = GetComponentInChildren<Animator>();
		_playerRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update ()
	{
		//MovimentByPosition();
		
		//Clamping the axis
		float x = Mathf.Clamp(gameObject.transform.position.x, _xMin, _xMax);
		float y = Mathf.Clamp(gameObject.transform.position.y, _yMin, _yMax);
		
		//Vector3 positionLimits
		gameObject.transform.position = new Vector3(x, y, 0);

		//Laser fire behavior
		if (Input.GetButtonDown("Fire"))
		{
			InvokeRepeating("Fire", 0.0001f, LaserFireRating);
		}
		if (Input.GetButtonUp("Fire"))
		{
			CancelInvoke("Fire");
		}
		
	}

	void FixedUpdate()
	{
		MovimentByForce();
		//MovimentByVelocity();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		EnemyLaser laser = other.GetComponent<EnemyLaser>();
		if (laser)
		{
			_shieldAnimator.Play("Idle");
			_shieldAnimator.Play("Shield");
			GetComponentInChildren<Shield>().PlaySound();
			PlayerHitpoint -= laser.Hit();
			/*if (PlayerHitpoint == 10)
			{
				GetComponent<Animator>().Play("RedAlert");
			*/
			if (PlayerHitpoint <= 0)
			{
				Destroy(gameObject);
			}
		}	
	}

	private void MovimentByForce()
	{
		float directionX = Input.GetAxis("Horizontal");
		
		if (_playerRigidbody2D.velocity.x > -15f && _playerRigidbody2D.velocity.x < 15f)
		{
			_playerRigidbody2D.AddForce(new Vector3(Speed * directionX, 0f, 0f));
		}
		
		/*float directionY = Input.GetAxis("Vertical");
		if (_playerRigidbody2D.velocity.y > -15f && _playerRigidbody2D.velocity.y < 15f)
		{
			_playerRigidbody2D.AddForce(new Vector3(0f, Speed * directionY, 0f));
		}*/
		
	}
	
	/*private void MovimentByPosition()
	{
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			transform.position += Vector3.left * Speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			transform.position += Vector3.right * Speed * Time.deltaTime;
		}
	}*/
	
	/*private void MovimentByVelocity()
	{
		float directionX = Input.GetAxis("Horizontal");
		float directionY = Input.GetAxis("Vertical");
		_playerRigidbody2D.velocity = new Vector3(Speed * directionX, Speed * directionY, 0f);
	}*/
	
	private void GetScreenLimits()
	{
		float distance = Camera.main.transform.position.z - gameObject.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
		Vector3 bottomMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
		Vector3 topMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, distance));

		_xMin = leftMost.x + ShipPadding;
		_xMax = rightMost.x - ShipPadding;
		_yMin = bottomMost.y + ShipPadding;
		_yMax = topMost.y - ShipPadding;
	}

	private void Fire()
	{
		GameObject projectile = Instantiate(Laser, transform.position, Quaternion.identity);
		projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, LaserSpeed, 0);
		projectile.GetComponent<AudioSource>().Play();
		//Destroy(projectile, 1f); using the collider alternative for destroy the lasers
	}
}
