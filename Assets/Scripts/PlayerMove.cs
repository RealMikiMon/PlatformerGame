using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5.0f;

    Rigidbody2D rigidbody;
    private float horizontalDir; // Horizontal move direction value [-1, 1]

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

    // NOTE: InputSystem: "move" action becomes "OnMove" method
    void OnMove(InputValue value)                                   //VE de move(Mapeig fet input System de Player)
    {
        // Read value from control, the type depends on what
        // type of controls the action is bound to
        var inputVal = value.Get<Vector2>();
        horizontalDir = inputVal.x;
    }
}
