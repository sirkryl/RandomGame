using UnityEngine;
using System.Collections;

public class ThrowableItem : Item
{
	protected void Start()
	{
		base.Start ();
	}
	public void HandlePickUp()
	{
        //gameObject.transform.parent = GameObject.FindWithTag("PlayerHand").transform;
        //gameObject.transform.localPosition = new Vector3(0,0,0);
        //gameObject.transform.localRotation = Quaternion.identity;
        //gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //gameObject.GetComponent<Collider>().enabled = false;
	}

	public void HandleDrop()
	{
        //gameObject.transform.SetParent (GameObject.FindWithTag ("Items").transform, true);
        //gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //gameObject.GetComponent<Collider>().enabled = true;
	}

	public void HandleThrow()
	{
        //Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        ////Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        //gameObject.transform.SetParent (GameObject.FindWithTag ("Items").transform, true);
        //gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //gameObject.GetComponent<Collider>().enabled = true;
        //gameObject.GetComponent<Rigidbody>().AddForce(ray.direction*100);
		//gameObject.rigidbody.AddForce(ray.direction*20);
	}
}

