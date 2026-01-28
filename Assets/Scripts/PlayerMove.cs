using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5.0f;
    Rigidbody2D rigidbody;
    private float horizontalDir;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = rigidbody.linearVelocity;
        velocity.x = horizontalDir * Speed;
        rigidbody.linearVelocity = velocity;
    }

    void OnMove(InputValue value)                                   
    {
        var inputVal = value.Get<Vector2>();
        horizontalDir = inputVal.x;
    }
}
