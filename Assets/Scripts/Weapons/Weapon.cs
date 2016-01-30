using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    protected float timer;

    protected int shootableMask;

    protected AudioSource gunAudio;

    protected virtual void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunAudio = GetComponent<AudioSource>();
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;

    }

    public virtual void Shoot()
    {
        
        
    }

    public virtual void DisableEffects()
    {

    }
}
