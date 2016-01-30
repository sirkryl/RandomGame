using UnityEngine;
using System.Collections;

public class ProjectileWeapon : Weapon
{
    protected GameObject projectile;

    // Use this for initialization
    protected void Awake()
    {

        base.Awake();

        projectile = Resources.Load("Bullet") as GameObject;

    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Shoot()
    {
        base.Shoot();

        if (timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            timer = 0f;

            gunAudio.Play();

            GameObject bullet;

            bullet = Instantiate(projectile, transform.position + transform.forward * 0.25f, transform.rotation) as GameObject;
        }
    }
}