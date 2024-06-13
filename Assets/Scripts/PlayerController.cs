using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float moveJump;

    Rigidbody2D rb;
    Animator anim;
    public AudioSource aus;
    public AudioClip hit;

    float xDir;
    bool facing;
    bool groundCheck;

    public Transform gunTip;
    public GameObject bullet;
    float timerate = 0.5f;
    float nextrate = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facing = true;
        groundCheck = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        if (xDir!=0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        rb.velocity = new Vector2(xDir*moveSpeed, rb.velocity.y);
        if (xDir > 0 && !facing)
        {
            flip();
        }
        else if(xDir < 0 && facing)
        {
            flip();
        }
        if (Input.GetKey(KeyCode.W) && groundCheck)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveJump);
            groundCheck = false;
            if(aus && hit)
            {
                aus.PlayOneShot(hit);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            shoot();
        }
        anim.SetBool("Jump", !groundCheck);
    }
    public void shoot()
    {
        if (Time.time > nextrate)
        {
            nextrate = Time.time+ timerate;
            if (facing)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facing)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
  
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            groundCheck = true;
        }
    }
    void flip()
    {
        facing=!facing;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
