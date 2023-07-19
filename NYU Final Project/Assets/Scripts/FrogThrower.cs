using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogThrower : MonoBehaviour
{
    public GameObject frog;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            
            if(transform.localScale.x >= 0) {
                Instantiate(frog, transform.position, frog.transform.rotation).GetComponent<FrogFall>().SetDirection(true);
            }
            else {
                Instantiate(frog, transform.position, frog.transform.rotation).GetComponent<FrogFall>().SetDirection(false);
            }
        }
    }
}
