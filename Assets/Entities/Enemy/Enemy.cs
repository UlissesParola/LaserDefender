using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float Hitpoints = 30;
	public GameObject Laser;
	public float Speed = 4f;

	private float _wait;

	void Start()
	{
		InvokeRepeating("Fire", Random.Range(0.1f, 2f), Random.Range(1f, 4f));
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Laser missile = other.gameObject.GetComponent<Laser>(); // Actually getting the script component, not the class itself
		if (missile)
		{
			Hitpoints -= missile.Hit();

			if (Hitpoints <=0 )
			{
				Destroy(gameObject);
			}
		}
		
	}
	
	private void Fire()
	{
		GameObject laser = Instantiate(Laser, transform.position, Quaternion.identity);
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -Speed);
	}
}
