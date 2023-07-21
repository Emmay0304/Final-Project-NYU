using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndVideoActivation : MonoBehaviour
{
    public RawImage display;

    // Start is called before the first frame update
    void Start()
    {
        display.color = new Color(1,1,1,0);
        display.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Frog")) {
            display.color = new Color(1,1,1,0);
            display.gameObject.SetActive(true);
            StartCoroutine(PlayerFade());
        }
    }

    private IEnumerator PlayerFade() {      
        yield return new WaitForSeconds(0.5f); 
        display.gameObject.SetActive(true);
        for (float i = 0; i <= 2; i += Time.deltaTime)
            {
                // set color with i as alpha
                display.color = new Color(1, 1, 1, i);
                yield return null;
            }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
