using UnityEngine;
using UnityEngine.InputSystem;

// Moves the player (white capsule) with WASD using a Rigidbody2D.
// Input is read in Update, physics movement is applied in FixedUpdate.
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) direction += Vector2.up;
        if (Keyboard.current.sKey.isPressed) direction += Vector2.down;
        if (Keyboard.current.aKey.isPressed) direction += Vector2.left;
        if (Keyboard.current.dKey.isPressed) direction += Vector2.right;

        direction = direction.normalized; // same speed when moving diagonally
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }
}
