using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float JumpHeight;
    public float DistanceToMaxHeight;
    public float SpeedHorizontal;
    public float PressTimeToMaxJump;

    public float WallSlideSpeed = 1;
    public ContactFilter2D filter;

    private Rigidbody2D rigidbody;
    private CollisionDetection collisionDetection;
    private float lastVelocityY;
    private float jumpStartedTime;


    //
    public int MaxJumps = 2;   // nombre de salts permesos
    private int jumpCount = 1; // comptador intern

    private float originalJumpHeight;
    private Coroutine powerUpCoroutine;
    public float PowerUpJumpMultiplier = 1.5f;
    public float PowerUpDuration = 10f;
   
    bool IsWallSliding => collisionDetection.IsTouchingFront;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collisionDetection = GetComponent<CollisionDetection>();

        originalJumpHeight = JumpHeight;
        PowerUp.OnPowerUpCollected += ActivateJumpPowerUp;
    }

    void FixedUpdate()
    {
        if (collisionDetection.IsGrounded) jumpCount = 1; 
        
        if (IsPeakReached()) TweakGravity();

        if (IsWallSliding) SetWallSlide();
    }

    // NOTE: InputSystem: "JumpStarted" action becomes "OnJumpStarted" method
    public void OnJumpStarted() //Es un back de Control en el moment que saltem fem reset gravetat x si la de terra fos major
    {
        if (jumpCount >= MaxJumps) return; // no queden salts disponibles

        jumpCount++; // consumim un salt

        SetGravity();                      //Seteja la gravetat 
        var velocity = new Vector2(rigidbody.linearVelocity.x, GetJumpForce());
        rigidbody.linearVelocity = velocity;
        jumpStartedTime = Time.time;
    }

    // NOTE: InputSystem: "JumpFinished" action becomes "OnJumpFinished" method
    public void OnJumpFinished()
    {
         if (rigidbody.linearVelocity.y > 0)
    {
        rigidbody.linearVelocity = new Vector2(
            rigidbody.linearVelocity.x,
            rigidbody.linearVelocity.y * 0.4f
        );
    }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        float h = -GetDistanceToGround() + JumpHeight;
        Vector3 start = transform.position + new Vector3(-1, h, 0);
        Vector3 end = transform.position + new Vector3(1, h, 0);
        Gizmos.DrawLine(start, end);
        Gizmos.color = Color.white;
    }

    private bool IsPeakReached()
    {
        bool reached = ((lastVelocityY * rigidbody.linearVelocity.y) < 0);
        lastVelocityY = rigidbody.linearVelocity.y;

        return reached;
    }

    private void SetWallSlide()
    {
        // Modify player linear velocity on wall sliding
        //rigidbody.gravityScale = 0.8f;
        rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x,
            Mathf.Max(rigidbody.linearVelocity.y, -WallSlideSpeed));
    }

    private void SetGravity()
    {
        var grav = 2 * JumpHeight * (SpeedHorizontal * SpeedHorizontal) / (DistanceToMaxHeight * DistanceToMaxHeight);
        rigidbody.gravityScale = grav / 9.81f;
    }

    private void TweakGravity()
    {
        rigidbody.gravityScale *= 1.2f; //Canviar velocitat de caiguda dsprs d'arriba a punt m�xim y
    }

    private float GetJumpForce()
    {
        return 2 * JumpHeight * SpeedHorizontal / DistanceToMaxHeight; //Logica de for�a de salt segons distancia
    }

    private float GetDistanceToGround()
    {
        RaycastHit2D[] hit = new RaycastHit2D[3];

        Physics2D.Raycast(transform.position, Vector2.down, filter, hit, 10);

        return hit[0].distance;
    }

    private void ActivateJumpPowerUp(PowerUp powerUp)
    {
        if (powerUpCoroutine != null)
            StopCoroutine(powerUpCoroutine);

        powerUpCoroutine = StartCoroutine(JumpPowerUpCoroutine());
    }

    private IEnumerator JumpPowerUpCoroutine()
    {
        JumpHeight = originalJumpHeight * PowerUpJumpMultiplier;

        yield return new WaitForSeconds(PowerUpDuration);

        JumpHeight = originalJumpHeight;
    }

    private void OnDestroy()
    {
        PowerUp.OnPowerUpCollected -= ActivateJumpPowerUp;
    }

    private void OnExit()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
}
