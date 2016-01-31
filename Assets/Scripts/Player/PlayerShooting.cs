using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    Weapon weapon;
    PlayerMovement movement;

    void Awake ()
    {
        weapon = GetComponentInChildren<Weapon>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }


    void Update ()
    {
		if(Input.GetButton ("Fire1"))
        {
            if (movement.FloorHitPoint != Vector3.zero)
                weapon.Shoot (movement.FloorHitPoint);
        }

        
    }


    public void DisableEffects ()
    {
        weapon.DisableEffects();
    }
}
