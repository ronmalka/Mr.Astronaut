using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlick : MonoBehaviour
{
    Animator animator;
    private AirMeter airMeter; 
    public int scoreAir;
    public int airAmount;
    bool isFirst;
    bool canInc;
    // Start is called before the first frame update
    void Start()
    {
        isFirst =true;
        canInc = false;
        airMeter = GameObject.Find("Canvas-Info").transform.GetChild(0).gameObject.GetComponent<AirMeter>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFirst && ScoreScript.scoreVal > scoreAir)
        {
            isFirst = false;
            canInc = true;
            AirFlickOn();
           
        }
        if (ScoreScript.scoreVal <= scoreAir)
        {
            canInc =false;
        }

        if (canInc && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("AirFlickOff",false);
            increaseAir();
        }
        
    }

    public void AirFlickOn()
    {
        animator.SetInteger("state" , 1) ;
        StartCoroutine("AirFlickOff",true);
    }

    public IEnumerator AirFlickOff(bool wait)
    {
        if(wait)
            yield return new WaitForSeconds(5f);
        isFirst = true;
        animator.SetInteger("state" , 0) ;
    }

    private void increaseAir()
    {
        ScoreScript.scoreVal = ScoreScript.scoreVal - scoreAir;
        airMeter.setAir(airAmount); 
    }
}
