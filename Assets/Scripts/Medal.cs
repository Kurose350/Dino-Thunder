using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medal : MonoBehaviour
{
    GameController gc;
    void Start()
    {
        gc=FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gc.point();
            Destroy(gameObject);
        }
    }
}
