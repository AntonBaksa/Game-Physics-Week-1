using UnityEditor.ShaderGraph;
using UnityEngine;
using static Unity.U2D.Physics.PhysicsShape;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bounciness = 1.0f;
    private Vector2 preCollisionVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        preCollisionVelocity = rb.linearVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("PurpleBall")) return;
        
        if (rb != null)
        {
            Vector2 normal = other.GetContact(0).normal;

            float speedMagnitude = Vector2.Dot(preCollisionVelocity, normal);

            Vector2 speedIntoSurface = speedMagnitude * normal;

            Vector2 slideSpeed = preCollisionVelocity - speedIntoSurface;

            if (speedMagnitude >= 0f) return;
       
            rb.linearVelocity = slideSpeed - bounciness * speedIntoSurface;
            
        }
        
    }
}
