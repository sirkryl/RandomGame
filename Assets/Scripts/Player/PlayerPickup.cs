using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerEquipment))]
public class PlayerPickup : MonoBehaviour {

    PlayerEquipment equipment;
    Transform rightHand;
    GameObject weaponGameObject;
	void Awake () {
        equipment = GetComponent<PlayerEquipment>();
        rightHand = GameObject.FindGameObjectWithTag("ShootingPoint").transform;
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Weapon")
        {
            Weapon weapon = coll.gameObject.GetComponentInChildren<Weapon>();
            if(weapon != null)
            {
                Destroy(weaponGameObject);
                weaponGameObject = Instantiate(Resources.Load(weapon.GetType().ToString()), rightHand.position, rightHand.rotation) as GameObject;
                weaponGameObject.transform.SetParent(rightHand);
                equipment.Weapon = weaponGameObject.GetComponentInChildren<Weapon>();// coll.GetComponentInChildren<Weapon>();
                Destroy(coll.gameObject);
            }
        }
    }
}
