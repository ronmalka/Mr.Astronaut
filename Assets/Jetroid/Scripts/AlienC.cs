using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienC : MonoBehaviour
{
    public float attackDelay = 3f;
    public GameObject projectile;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
        if (attackDelay !=0)
        {
            StartCoroutine(OnAttack());
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("State",0);
    }
    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        Fire();
        StartCoroutine(OnAttack());
    }

    void Fire()
    {
      animator.SetInteger("State",1);
    }

    void OnFire()
    {
        if (projectile != null)
        {
           var clone = Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }


}
