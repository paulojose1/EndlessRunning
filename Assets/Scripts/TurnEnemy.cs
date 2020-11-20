using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnemy : MonoBehaviour
{
    [SerializeField] Transform turnEnemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.position = turnEnemy.position;
        }
    }
}
