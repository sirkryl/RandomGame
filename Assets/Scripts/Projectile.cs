﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public int damage = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + transform.forward.normalized * 0.25f;
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        foreach (IDamageable damageable in collider.GetComponentsInChildren<IDamageable>())
        {
            damageable.TakeDamage(damage);
        }
    }
}