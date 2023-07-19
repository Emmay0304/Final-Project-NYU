using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerActivated : MonoBehaviour
{
    public bool litUp;
    public float waitTime = 1f;
    public float boostingForce = 30f;

    // Start is called before the first frame update
    void Start()
    {
        litUp = false;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(!litUp) {
            litUp = true;
            StartCoroutine(Activate(other));
        }
    }

    private IEnumerator Activate(Collider2D other) {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(waitTime);
        other.attachedRigidbody.AddForce(Vector2.up * boostingForce, ForceMode2D.Impulse);
        litUp = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
