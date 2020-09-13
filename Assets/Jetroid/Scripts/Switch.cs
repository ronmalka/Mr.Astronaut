using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public DoorTrigger[] doorTriggers;
    Animator animator;
    public bool sticky;
    private bool down = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            return;
        }
        down =true;
        animator.SetInteger("State",1);
        foreach (var trigger in doorTriggers)
        {
            if (trigger !=null)
            {
                trigger.Toggle(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (sticky && down)
        {
            return;
        }

        down = false;
        animator.SetInteger("State",2);
        foreach (var trigger in doorTriggers)
        {
            if (trigger !=null)
            {
                trigger.Toggle(false);
            }
        }
    }
    void OnDrawGizmos()
    {
      Gizmos.color = sticky? Color.red : Color.green;
       foreach (var trigger in doorTriggers)
        {
            if (trigger !=null)
            {
                Gizmos.DrawLine(transform.position, trigger.door.transform.position);
            }
        }  
    }
    
}
