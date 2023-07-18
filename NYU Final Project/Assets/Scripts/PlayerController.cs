using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 9f;
    public float walkAcceleration = 75f;
    public float airAcceleration = 30f;
    public float groundDeceleration = 70f;
    public float jumpHeight = 4f;
    private BoxCollider2D boxCollider;
    private Vector2 velocity;
    private bool grounded;
    private bool jumped;

    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Use GetAxisRaw to ensure our input is either 0, 1 or -1.
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (grounded)
        {
            velocity.y = 0;
            jumped = false;
            if(Input.GetAxisRaw("Vertical") > 0) {
                jumped = true;
            }
            else if(Input.GetAxisRaw("Vertical") < 0) {
                jumped = false;
            }
            
        }
        if (jumped)
        {
            // Calculate the velocity required to achieve the target jump height.
            velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
        }
        

        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        velocity.y += Physics2D.gravity.y * Time.deltaTime;

        transform.Translate(velocity * Time.deltaTime);

        // Retrieve all colliders we have intersected after velocity has been applied.
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        grounded = false;
        foreach (Collider2D hit in hits)
        {
            // Ignore our own collider.
            if (hit == boxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

            // Ensure that we are still overlapping this collider.
            // The overlap may no longer exist due to another intersected collider
            // pushing us out of this one.
            if (colliderDistance.isOverlapped)
            {
                //transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                // If we intersect an object beneath us, set grounded to true.  && velocity.y < 0
                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 || Physics2D.IsTouching(boxCollider, ground.GetComponent<Collider2D>()))
                {
                    grounded = true;
                }
            }
            
        }
    }
}
