using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour, IDamageable {

    public int health = 100;
    private Renderer renderer;

    private bool currentlyFlashing = false;

    public bool GainHealth(int amount)
    {
        if (health < 100)
        {
            health = Mathf.Min(health + amount, 100);
            return true;
        }
        return false;
    }

    public void TakeDamage(int amount)
    {
        health = Mathf.Max(health - amount, 0);

        if(health == 0)
        {
            Debug.Log("dead");
        }
        DamageVisible();
        
    }

    protected void DamageVisible()
    {
        if (!currentlyFlashing)
        {
            currentlyFlashing = true;
            StartCoroutine(renderer.FlashInColor());
            currentlyFlashing = false;
        }
    }

	// Use this for initialization
	void Awake () {
        renderer = gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
