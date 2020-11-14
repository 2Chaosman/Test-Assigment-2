using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float speed;
    private float bulletSpeed = 25;
    public float jumpHeight;
    private float horizontalInput;
    private bool isGrounded;
    public bool facingRight;

    private Rigidbody2D playerRb;
    public Animator animator;
    


    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        isGrounded = true;
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log(horizontalInput);

        if(horizontalInput < -0.01f || horizontalInput > 0.01f)
        {
            
            playerRb.AddForce(Vector2.right * speed * horizontalInput);
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

            if (horizontalInput > 0.01f && !facingRight)
            {
                Flip();
                //facingRight = true;
            } else if(horizontalInput < -0.01f && facingRight)
            {
                Flip();
                //facingRight = false;
            }
        }

        
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("IsShooting", true);
            Shoot();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("IsShooting", false);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("IsJumping", false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        if (facingRight)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        } else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
        }
        
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
