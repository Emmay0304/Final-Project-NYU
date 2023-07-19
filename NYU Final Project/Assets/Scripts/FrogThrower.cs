using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogThrower : MonoBehaviour
{
    public GameObject frog;

    public float cooldown = 2f;

    private float nextFireTime = 0;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                nextFireTime = Time.time + cooldown;
                if (transform.localScale.x >= 0)
                {
                    Instantiate(frog, transform.position, frog.transform.rotation).GetComponent<FrogFall>().SetDirection(true);
                }
                else
                {
                    Instantiate(frog, transform.position, frog.transform.rotation).GetComponent<FrogFall>().SetDirection(false);
                }
                animator.SetBool("HasFrog", false);
            }
            else {
                animator.SetBool("HasFrog", true);
            }
        }

        
    }
}
