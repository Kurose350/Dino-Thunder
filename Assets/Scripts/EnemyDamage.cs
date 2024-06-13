using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    int damage = 1; 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();
            if (ph)
            {
                ph.LoseLife(damage);
            }
        }
    }
}
