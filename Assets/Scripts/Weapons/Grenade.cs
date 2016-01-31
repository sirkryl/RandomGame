using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Grenade : Projectile
{

    ParticleSystem explosion;
    public float radius = 5.0f;
    public float speed = 3.0f;
    bool exploding = false;

    protected void Awake()
    {
        explosion = GetComponentInChildren<ParticleSystem>();
    }

    protected override void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);

        if(Vector3.Distance(transform.position, target) < 0.1f && !exploding)
        {
            exploding = true;
            Explode();
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider collider in colliders)
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
        explosion.Play();
        Destroy(gameObject, explosion.duration);
    }

}
