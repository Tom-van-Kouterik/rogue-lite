using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementDirection;
    private float movementSpeed = 3.5f;
    private Rigidbody2D rb;
    [SerializeField] private InputActionReference move;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movementDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementDirection.x * movementSpeed, movementDirection.y * movementSpeed);
    }
}
