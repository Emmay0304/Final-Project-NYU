using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerActivated : MonoBehaviour
{
    public bool litUp;
    public bool shoot;
    public float waitTime = 1f;
    public float boostingForce = 10f;
    public float boostingTime = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        litUp = false;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(!litUp) {
            litUp = true;
            StartCoroutine(Activate());
        }
    }

    public void OnTriggerStay2D(Collider2D other) {
        if(shoot) {
            other.attachedRigidbody.AddForce(Vector2.up * boostingForce, ForceMode2D.Impulse);
        }
    }

    private IEnumerator Activate() {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(waitTime);
        litUp = false;
        shoot = true;
        yield return new WaitForSeconds(boostingTime);
        shoot = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
