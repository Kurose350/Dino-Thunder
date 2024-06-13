using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class EnemyController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private Transform playerTransform;
    bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
            if ((direction.x > 0 && facingRight) || (direction.x < 0 && !facingRight))
            {
                flip();
            }
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
