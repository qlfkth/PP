using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 100f;
    private int jumpCount = 0;
    private bool isGrounded = false;    
    private bool isDead = false;
    private bool isSliding = false;
    private float SlideTime;
    

    private Rigidbody2D playerRigidbdy;
    private Animator animator;
    private AudioSource playerAudio;
    private BoxCollider2D boxcoll;
    void Start()
    {
        playerRigidbdy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        boxcoll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Sliding();
    }
    private void Jump()
    {
        if (isDead)
        {

            return;
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {

            jumpCount++;

            playerRigidbdy.velocity = Vector2.zero;

            playerRigidbdy.AddForce(new Vector2(0, jumpForce));


        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbdy.velocity.y > 0)
        {

            playerRigidbdy.velocity = playerRigidbdy.velocity * 0.5f;

        }

        animator.SetBool("Grounded", isGrounded);

    }

    private void Sliding()
    {
        if (Input.GetMouseButton(1))
        {
            
            animator.SetBool("Sliding", true);
            boxcoll.offset = new Vector2(0, -2.1f);
            boxcoll.size = new Vector2(3.3f, 2);
        }
      
         if (Input.GetMouseButtonUp(1))
        {
                      
            animator.SetBool("Sliding", false);
            boxcoll.offset = new Vector2(-0.5845337f, -2.455041f);
            boxcoll.size = new Vector2(3.39477f, 3.687037f);
           

        }
        
    }

    private void Die()
    {
        
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();
        playerRigidbdy.velocity = Vector2.zero;
        isDead = true;

        GameManager.instanse.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
