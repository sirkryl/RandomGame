using UnityEngine;
using System.Collections;

public class GrenadeLauncher : ProjectileWeapon {

    public float explosionDelay = 2.0f;

	// Use this for initialization
	void Start () {
	
	}

    public override void Shoot(Vector3 target)
    {
        base.Shoot(target);

        ((Grenade)projectile).explosionDelay = explosionDelay;
    }
}
