using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogThrower : MonoBehaviour
{
    public GameObject frog;

    public float cooldown = 2f;

    public float nextFireTime = 0;

    public float throwPositionOffset = 1f;

    public Animator animator;

    public UnityEngine.Rendering.Universal.Light2D playerLight;

    public ParticleSystem frogEffect;

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
                animator.SetBool("HasFrog", false);
                
                Vector2 throwPosition = new Vector2(transform.position.x, transform.position.y + throwPositionOffset);
                Instantiate(frogEffect, gameObject.transform);
                if(playerLight !=null)
                    playerLight.gameObject.SetActive(false);
                if (transform.localScale.x >= 0)
                {
                    Instantiate(frog, throwPosition, frog.transform.rotation).GetComponent<FrogFall>().SetDirectionCooldown(true, cooldown);                    
                }
                else
                {
                    Instantiate(frog, throwPosition, frog.transform.rotation).GetComponent<FrogFall>().SetDirectionCooldown(false, cooldown);
                } 
            }
            else {
                animator.SetBool("HasFrog", true);
                if (playerLight != null)
                    playerLight.gameObject.SetActive(true);
            }
            
        } else
        {
            animator.SetBool("HasFrog", false);
            if (playerLight != null)
                playerLight.gameObject.SetActive(false);
        }

        
    }
}
