using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    private float movement;
    private new Rigidbody2D rigidBody;
    private bool isTouchingTrap;
    private Animator playerAnimation;
    public LayerMask groundLayer;
    public float trapCheckRadius;
    public Transform trapCheckpoint;

    [SerializeField] Transform spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trap")
        {
            speed *= -1;

            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);

        }

    }

}
