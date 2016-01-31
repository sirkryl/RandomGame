using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Projectile : MonoBehaviour {

    public int damage = 1;
    public Vector3 target;

	
	// Update is called once per frame
	protected virtual void Update () {
	}

    protected virtual void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    


}
