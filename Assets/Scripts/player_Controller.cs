using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Controller : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 5f;
    private float movement = 0f;
    private new Rigidbody2D rigidbody;
    public Transform groundCheckpoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Animator playerAnimation;
    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();


    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckpoint.position, groundCheckRadius, groundLayer);


        movement = Input.GetAxis("Horizontal");


        if (movement > 0)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
            transform.localScale = new Vector2(1f, 1f);

        }
        else if (movement < 0)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);

        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            SoundManagerScript.PlaySound("jumpSound");
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
        playerAnimation.SetBool("onGround", isTouchingGround);

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            SoundManagerScript.PlaySound("StabSound");
            gameLevelManager.Respawn();
        }

        if (collision.transform.CompareTag("Michael"))
        {
            SoundManagerScript.PlaySound("Michael");
            gameLevelManager.Respawn();

        }

        if (collision.transform.CompareTag("Trap"))
        {
            SoundManagerScript.PlaySound("death");
            gameLevelManager.Respawn();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {

            respawnPoint = collision.transform.position;
        }
        if (collision.tag == "Trap")
        {
            SoundManagerScript.PlaySound("death");
            gameLevelManager.Respawn();
        }

        if (collision.tag == "Enemy")
        {

            SoundManagerScript.PlaySound("StabSound");
            gameLevelManager.Respawn();
        }

        if (collision.tag == "Freddy")
        {

            SoundManagerScript.PlaySound("Decapitation");
            gameLevelManager.Respawn();
        }

    }
}