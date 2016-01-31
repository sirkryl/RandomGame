using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlameThrower : Weapon
{
    ParticleSystem gunParticles;
    Quaternion startingAngle = Quaternion.AngleAxis(-20, Vector3.up);
    Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);
    protected override void Awake()
    {
        base.Awake();
        gunParticles = GetComponentInChildren<ParticleSystem>();
    }

    protected override void Update()
    {
        base.Update();
    }

    void OnParticleCollision(GameObject other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth)
        {
            enemyHealth.TakeDamage(damagePerShot);
        }
    }

    public override void Shoot(Vector3 target)
    {
        base.Shoot(target);
        if (timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            timer = 0f;
            //gunAudio.Play();

            gunParticles.Play();
        }
    }
}