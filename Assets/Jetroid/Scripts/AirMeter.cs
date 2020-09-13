using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirMeter : MonoBehaviour
{
    public float air = 10f;
    public float maxAir = 10f;
    public float lastAir = 2f;
    public float airBunrnRate = .5f;

    private Player player;
    private Slider slider;

    private Shake camShake;

    private GameManage gameManage;
    // Start is called before the first frame update
    void Start()
    {
        
        camShake = GameObject.Find("ShakeScreen").GetComponent<Shake>();
        player =GameObject.FindObjectOfType<Player>();
        slider = GetComponent<Slider>();
        gameManage = GameObject.Find("GameManager").GetComponent<GameManage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
           return; 
        }

        if (air > 0)
        {
            if (slider.value < lastAir/maxAir)
            {
                camShake.CamShake();
                string sentences = "Hurry Up Mr. Astronaut \n Your Air Is Over";
                gameManage.startDialog(sentences);   
                air-=Time.deltaTime * airBunrnRate;
                slider.value = air / maxAir;     
            }
            else
            {
                camShake.StopCamShake();
                air-=Time.deltaTime * airBunrnRate;
                slider.value = air / maxAir;
            }
            
        }

    }
    public float getAir()
    {
        return air;
    }

    public void setAir(float airAmount)
    {
        air = air + airAmount;
        if(air > maxAir)
            air = maxAir;
        if (air < 0)
            air = 0;
    }
}
