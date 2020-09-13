using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{
   public GameObject target;
    public float scale = 4f;

    private Transform tf;
    
    private void Awake() 
    {
        var cam = gameObject.transform.GetChild(0).GetComponent<Camera>(); 
        cam.orthographicSize  = (Screen.height / 2f ) / scale;   
    }

    // Start is called before the first frame update
    void Start()
    {
        tf = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3 (tf.position.x, tf.position.y , transform.position.z);
        }
    }
}
