using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	//very likely that something like an ItemData struct with attributes will be better to avoid multiple active models
	public Sprite icon;
	protected string type;
	protected string effect;
	public int stackSize = 1;
	public string description;	
	//public bool pickUp = true;
	public bool stackable = false;
	//probably with an extra script for consumables
	public int maxStackSize = 10;
	public int weight = 0;
    public int name;
    public string id_string;


	// Use this for initialization
	protected void Start () {

        //icon = Resources.Load<Sprite>("Textures/"+id_string);
        //if (icon == null)
        //{
        //    icon = Resources.Load<Sprite>("Textures/item_apple");
        //}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string GetItemType()
	{
		return type;
	}

	public string GetItemEffect()
	{
		return effect;
	}

	public void HandleSelection () {
			gameObject.SetActive (false);
	}

	public void Use()
	{
		//use item
	}

	public void PickUp()
	{
		//add to players inventory
	}

	public void Drop()
	{
		//drop item
	}

	public void Place()
	{
		//place item
	}
}
