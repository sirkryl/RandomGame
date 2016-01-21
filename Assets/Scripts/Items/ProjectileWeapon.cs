using UnityEngine;
using System.Collections;

public class ProjectileWeapon : Weapon
{
    private float currentCooldown = 0.0f;

    public GameObject projectile;


    
    // Use this for initialization
    protected void Start()
    {
        base.Start();
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            int layerMask = 1 << 8;
            //layerMask = ~layerMask;
            if (Physics.Raycast(ray, out hit, layerMask))
            {

                float h = hit.point.x - transform.position.x;
                float v = hit.point.z - transform.position.z;
                Vector3 direction = new Vector3(h, 0.0f, v);
                direction.Normalize();
                GameObject bullet;

                float angle = Vector3.Angle(transform.forward, direction);

                if (h <= 0)
                    angle = 360 - angle;
                Quaternion rotation = Quaternion.AngleAxis(angle, transform.up);
                bullet = Instantiate(projectile, transform.position + direction * 0.25f, rotation) as GameObject;
                currentCooldown = cooldown;
            }
        }
    }

}

