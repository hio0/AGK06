using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    InputManager input;

    // Start is called before the first frame update
    void Start()
    {
        input = InputManager.Inputing;
        rb = GetComponent<Rigidbody2D>();

        SetInput();
    }

    void FixedUpdate()
    {
        if(rb.velocity.sqrMagnitude <= 1f)
        {
            rb.velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        PlayerFly plf = gameObject.GetComponent<Player>().me;
        rb.velocity = new Vector2(input.MovePath.x * plf.movespeed, input.MovePath.y * plf.movespeed);
    }

    void SetInput()
    {
        input.Moved = Move;
    }
}
