using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public Sprite checkpoint;
    public Sprite greenCheckpoint;
    private SpriteRenderer checkpointSpriteRender;
    public bool checkpointReached;

    // Start is called before the first frame update
    void Start()
    {
        checkpointSpriteRender = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            checkpointSpriteRender.sprite = greenCheckpoint;
            checkpointReached = true;
        }
    }
}
