using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalLightUp : MonoBehaviour
{

    public UnityEngine.Rendering.Universal.Light2D crystalLight;
    public bool litup;
    public float waitTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        litup = false;
        crystalLight.gameObject.SetActive(litup);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Frog")) {
            if(!litup) {
                litup = true;
                
                StartCoroutine(GlowingTimer());
            }
        }
    }

    private IEnumerator GlowingTimer() {
        crystalLight.gameObject.SetActive(litup);
        yield return new WaitForSeconds(waitTime);
        crystalLight.gameObject.SetActive(false);
        litup = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
