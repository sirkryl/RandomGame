using UnityEngine;
using System.Collections;

public class RaycastWeapon : Weapon
{
    


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

            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * 1000f, Color.red);
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                
                IDamageable hitChar = hit.transform.gameObject.GetComponentInChildren<IDamageable>();
                if(hitChar != null)
                {
                    hitChar.TakeDamage(damage);
                }
            }
            currentCooldown = cooldown;
            
        }
    }

}

