using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D rb2D;
    float horizontal;
    float vertical;
    private bool FacingRight = true;
    public  Animator ani;
    public float jumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal, vertical);
       
        ani.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Jump();
        }
        
    }


    private void FixedUpdate()
    {
        Vector2 position = rb2D.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;

        rb2D.MovePosition(position);

        if (horizontal < 0 && FacingRight)
        {
            flip();
        }
        if (horizontal > 0 && !FacingRight)
        {
            flip();
        }

    }

    void Jump()
    {
        rb2D.velocity = Vector2.up * jumpHeight; 
    }

    private void flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
