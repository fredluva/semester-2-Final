using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D rb2D;
    float horizontal;
    

    Animator ani;
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

        

    }

    private void FixedUpdate()
    {
        Vector2 position = rb2D.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;

        rb2D.MovePosition(position);
    }
}
