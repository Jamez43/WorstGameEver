using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Transform tr;
    private SpriteRenderer sr;


    [SerializeField] private AudioSource deathSoundEffect;

    Vector3 startPosition;


     private void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }


    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

   private void restartLevel()
    {
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        anim.SetInteger("state", 0);
        anim.SetInteger("state", 1);
        rb.bodyType = RigidbodyType2D.Dynamic;

    }
}
