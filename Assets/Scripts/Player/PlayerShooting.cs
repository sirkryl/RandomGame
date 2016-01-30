using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    Weapon weapon;

    void Awake ()
    {
        weapon = GetComponentInChildren<Weapon>();
    }


    void Update ()
    {
		if(Input.GetButton ("Fire1"))
        {
            weapon.Shoot ();
        }

        
    }


    public void DisableEffects ()
    {
        weapon.DisableEffects();
    }
}
