using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    //Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;

    Renderer renderer;
    Material[] originalMaterials;
    Material flashMaterial;

    bool isDead;
    bool isSinking;
    bool currentlyFlashing = false;

    void Awake ()
    {
        //anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        renderer = GetComponentInChildren<MeshRenderer>();

        currentHealth = startingHealth;

        originalMaterials = renderer.materials;

        flashMaterial = new Material(Shader.Find("Standard"));
        flashMaterial.color = Color.red;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount)
    {
        TakeDamage(amount, transform.position);
    }

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (!currentlyFlashing)
            StartCoroutine(FlashInColor());

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        //anim.SetTrigger ("Dead");
        StartSinking();
        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }

    public IEnumerator FlashInColor()
    {
        currentlyFlashing = true;

        renderer.material = flashMaterial;

        yield return new WaitForSeconds(0.1f);

        renderer.materials = originalMaterials;

        currentlyFlashing = false;
    }
}
