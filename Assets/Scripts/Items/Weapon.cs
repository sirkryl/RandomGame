using UnityEngine;
using System.Collections;

public class Weapon : Equipable
{
	public int damage = 0;
    public float cooldown = 0.0f;

    protected float currentCooldown = 0.0f;
		// Use this for initialization
	protected void Start ()
	{
		base.Start ();
	}

	public override void HandleEquip()
	{
		//equip weapon
	}

    public virtual void HandleAttack()
    {

    }

}

