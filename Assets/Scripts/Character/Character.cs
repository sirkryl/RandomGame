using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour, IDamageable {

    public int health = 100;
    private Renderer rend;
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
        StartCoroutine(CollideFlash());
    }

    IEnumerator CollideFlash()
    {
        Material m = rend.material;
        Color32 c = rend.material.color;
        rend.material = null;
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        rend.material = m;
        rend.material.color = c;
    }

	// Use this for initialization
	void Awake () {
        rend = gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
