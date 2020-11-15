using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public GameObject bulletPrefab;
    public Animator animator;

    private Vector3 movementForce;
    private float speed = 3500;
    private float bulletSpeed = 25;
    private float jumpHeight = 40;
    private float horizontalInput;
    private bool isGrounded;
    private bool facingRight;
    private bool isJumped;
    private bool isShooting;

    void Start()
    {
        facingRight = true;
        isGrounded = true;
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        //Get input from buttons
        horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log(horizontalInput);
        movementForce = new Vector3(horizontalInput, 0, 0);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumped = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
            animator.SetBool("IsShooting", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
            animator.SetBool("IsShooting", false);
        }
    }

    void FixedUpdate()
    {
        Move();
        Shoot();
        Jump();
    }

    private void Move()
    {
        playerRb.AddForce(movementForce * speed);

        if (horizontalInput > 0.01f && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < -0.01f && facingRight)
        {
            Flip();
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
    }

    private void Jump()
    {
        if (isJumped)
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
            isJumped = false;
        }

    }

    private void Shoot()
    {
        if (isShooting)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            if (facingRight)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
            }
            else
            {
                bullet.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
            }

            isShooting = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
}
