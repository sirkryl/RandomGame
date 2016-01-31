using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    PlayerEquipment equipment;
    PlayerMovement movement;

    void Awake ()
    {
        equipment = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEquipment>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }


    void Update ()
    {
		if(Input.GetButton ("Fire1"))
        {
            if (movement.FloorHitPoint != Vector3.zero
                && equipment.Weapon != null)
                equipment.Weapon.Shoot (movement.FloorHitPoint);
        }

        
    }


    public void DisableEffects ()
    {
        equipment.Weapon.DisableEffects();
    }
}
