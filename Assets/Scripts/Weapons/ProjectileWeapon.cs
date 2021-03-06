﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileWeapon : Weapon
{
    public Projectile projectile;
    

    protected Projectile currentBullet;
    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        

        //projectile = Resources.Load("Bullet") as GameObject;

    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Shoot(Vector3 target)
    {
        base.Shoot(target);

        if (timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            timer = 0f;

            gunAudio.Play();

            currentBullet = Instantiate(projectile, transform.position + transform.forward * 0.25f, transform.rotation) as Projectile;
            currentBullet.target = target;
        }
    }
}