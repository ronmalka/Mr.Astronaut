using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Explode : MonoBehaviour
{
    public Debris debris;
    public float airAmount;
    public int totalDebris = 10;
    private bool needToDestroy;
    private GameManage gameManage;
    private AirMeter airMeter;    

    

    // Start is called before the first frame update
    void Start()
    {
        gameManage = GameObject.Find("GameManager").GetComponent<GameManage>();
        airMeter = GameObject.Find("Canvas-Info").transform.GetChild(0).gameObject.GetComponent<AirMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (needToDestroy)
        {
            gameManage.gameOver();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Obstacle")
        {
           OnExplode(); 
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Obstacle")
        {
           OnExplode(); 
        }
    }


    public void OnExplode()
    {
       airMeter.setAir(airAmount);
       Debug.Log(airMeter.getAir().ToString()); 
       if (airMeter.getAir() <= 0)
       {
           DoExplode();
       }
       
    }

    private void DoExplode()
    {
        SoundManager.PlaySound("explode");
        var tf = transform;
        for (int i = 0; i < totalDebris; i++)
        {
           tf.TransformPoint (0,-100,0);
           var clone = Instantiate(debris, tf.position, Quaternion.identity) as Debris;
           var body2D = clone.GetComponent<Rigidbody2D>();
           body2D.AddForce(Vector3.right*Random.Range(-1000,1000));
           body2D.AddForce(Vector3.up*Random.Range(-500,2000));

        }
        needToDestroy = true;
    }
}
