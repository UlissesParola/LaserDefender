using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float Hitpoints = 30;
	
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
}
