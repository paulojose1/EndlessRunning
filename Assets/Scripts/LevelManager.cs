using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay;
    public player_Controller gamePlayer;
    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<player_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        gamePlayer.gameObject.SetActive(false);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }
}
