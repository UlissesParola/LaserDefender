using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float Damage = 10f;

    public float Hit()
    {
        Destroy(gameObject);
        return Damage;
    }
}
