using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienB : MonoBehaviour
{
    Animator animator;
    private bool readyToAttack;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerStay2D(Collider2D other) {
       if (other.gameObject.tag == "Player")
       {
           if (other != null && readyToAttack)
           {
               var explode = other.GetComponent<Explode>();
               explode.OnExplode();
           }
           else
           {
               animator.SetInteger("State",1);
           }
           
       }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
       readyToAttack = false;
        if (other.gameObject.tag == "Player")
       {
           animator.SetInteger("State",0);
       }
   }

   private void Attack()
   {
       readyToAttack = true;
   }
}
