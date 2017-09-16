using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float Hitpoints = 30;
	public GameObject Torpedo;
	public float Speed = 4f;
	public AudioClip Explosion;
	private Score _score;
	
	void Start()
	{
		_score = GameObject.Find("Score").GetComponent<Score>();
		InvokeRepeating("Fire", Random.Range(0.1f, 2f), Random.Range(1f, 4f));
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Laser torpedo = other.gameObject.GetComponent<Laser>(); // Actually getting the script component, not the class itself
		if (torpedo)
		{
			Hitpoints -= torpedo.Hit();

			if (Hitpoints <=0 )
			{
				AudioSource.PlayClipAtPoint(Explosion, Camera.main.transform.position, 1.5f);
				_score.ScorePoints(100);
				Destroy(gameObject);
			}
		}
		
	}
	
	private void Fire()
	{
		GameObject torpedo = Instantiate(Torpedo, transform.position, Quaternion.identity);
		torpedo.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -Speed);
		torpedo.GetComponent<AudioSource>().Play();
	}
}
