using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogFall : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool forwardDirection;
    public float speed = 5f;
    public bool push;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(bool direction) {
        forwardDirection = direction;
        push = true;
    }

    public void OnCollisionEnter2D(Collision2D collision){
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        if(push) {
            Vector2 direction = Vector2.left;
            if(forwardDirection) {
                direction = Vector2.right;
            }
        
            rb.AddForce(direction * speed, ForceMode2D.Impulse);
            push = false;
        }
        Destroy(gameObject, 0.5f);
    }
}
