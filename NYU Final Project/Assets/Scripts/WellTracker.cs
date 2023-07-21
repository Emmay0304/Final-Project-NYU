using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WellTracker : MonoBehaviour
{
    public static bool hasTop = false;
    public static bool hasBottom = false;

    public SpriteRenderer sr;
    public Sprite ifNone;
    public Sprite ifTop;
    public Sprite ifBottom;
    public Sprite ifBoth;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            if(CompareTag("Top")) {
                hasTop = true;
            }
            if(CompareTag("Bottom")) {
                hasBottom = true;
            }
            if(CompareTag("Main") && hasTop && hasBottom) {
                SceneManager.LoadScene("EndScene");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hasTop && hasBottom) {
            sr.sprite = ifBoth;
        }
        else if(hasTop) {
            sr.sprite = ifTop;
        }
        else if(hasBottom) {
            sr.sprite = ifBottom;
        }
        else {
            sr.sprite = ifNone;
        }
    }
}
