using UnityEngine;
using System.Collections;

public class Bullet : Projectile {


    protected override void Update()
    {
        transform.position = transform.position + transform.forward.normalized * 0.25f;
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            EnemyHealth enemyHealth = collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }
}
