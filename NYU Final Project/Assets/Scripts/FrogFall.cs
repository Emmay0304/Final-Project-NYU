using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FrogFall : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool forwardDirection;
    public float speed = 20f;
    public float throwUpwardsAngle = 0.5f;
    public float throwForwardsDistance = 0.5f;
    public bool push;
    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetDirectionCooldown(bool direction, float wait) {
        forwardDirection = direction;
        cooldown = wait;
        push = true;
    }

    public void OnCollisionEnter2D(Collision2D collision){
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Vector3 hitPosition = Vector3.zero;
        if (collision.gameObject.CompareTag("Vines"))
        {
            Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.1f;
                hitPosition.y = hit.point.y - 0.1f;
                Vector3Int cell = new Vector3Int((int)hitPosition.x, (int)hitPosition.y, 0);
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }
        }
    }

    private IEnumerator RetrieveFrog() {
        yield return new WaitForSeconds(cooldown);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(push) {
            Vector2 direction = Vector2.up * throwUpwardsAngle;
            if(forwardDirection) {
                direction += Vector2.right * throwForwardsDistance;
            }
            else {
                direction += Vector2.left * throwForwardsDistance;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        
            rb.AddForce(direction * speed, ForceMode2D.Impulse);
            push = false;
            StartCoroutine(RetrieveFrog());
        }
    }
}
