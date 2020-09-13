using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;
    public bool ignoreTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ignoreTrigger)
        {
            return;
        }
        if (other.gameObject.tag == "Player")
        {
            door.Open();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (ignoreTrigger)
        {
            return;
        }
        if (other.gameObject.tag == "Player")
        {
            door.Close();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle(bool value)
    {
        if (value)
        {
            door.Open();
        }
        else
        {
            door.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = ignoreTrigger? Color.gray : Color.green;
        var bc2d = GetComponent<BoxCollider2D>();
        var pos = bc2d.transform.position;
        var newPos = new Vector2(pos.x + bc2d.offset.x, pos.y + bc2d.offset.y);
        Gizmos.DrawWireCube(newPos, new Vector2(bc2d.size.x,bc2d.size.y));
    }
}
