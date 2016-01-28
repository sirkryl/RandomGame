using UnityEngine;
using System.Collections;

public class ProjectileWeapon : Weapon
{
    protected GameObject projectile;
    
    // Use this for initialization
    protected void Start()
    {
       
        base.Start();

        projectile = Resources.Load("Bullet") as GameObject;

        effect = damage + " Damage";
    }

    public override void HandleAttack()
    {

        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        else
        {
            GameObject bullet;

            bullet = Instantiate(projectile, transform.position + transform.forward * 0.25f, transform.rotation) as GameObject;
            bullet.GetComponent<Projectile>().owner = gameObject.GetComponent<Character>();
            currentCooldown = cooldown;
        }
    }

}

