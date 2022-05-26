using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float JumpForce = 1;
    Rigidbody2D rb2D;
    float horizontal;
    float vertical;
    private bool FacingRight = true;
    public  Animator ani;
    private bool isDead = false;
   
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);
       
        ani.SetFloat("Speed", move.magnitude);


      

    }


    private void FixedUpdate()
    {
        Vector2 position = rb2D.position;
        position.x = position.x + speed * horizontal * Time.deltaTime * 1.5f;
        position.y = position.y + vertical - Time.deltaTime * 5;

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



    private void flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "death")
        {
            isDead = true;
            rb2D.velocity = Vector2.zero;
            GameController.instance.PlayerDied();
        }
        
    }

}
