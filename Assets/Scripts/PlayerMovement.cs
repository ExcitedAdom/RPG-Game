using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        rb.linearVelocity = movement * moveSpeed;

    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
