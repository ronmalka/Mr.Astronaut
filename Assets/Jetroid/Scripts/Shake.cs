using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator camAnim;
    public void CamShake()
    {
        camAnim.SetTrigger("Shake");
    }
    public void StopCamShake()
    {
        camAnim.SetTrigger("Stop");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
