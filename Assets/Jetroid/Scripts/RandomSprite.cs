using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public int currentSprite = -1;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite =(currentSprite == -1)? sprites[Random.Range(0,sprites.Length)] : (currentSprite > sprites.Length || currentSprite < -1) ? sprites[sprites.Length - 1] : sprites[currentSprite];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
