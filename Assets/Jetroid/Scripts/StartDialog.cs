using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartDialog : MonoBehaviour
{
    public Text textDisplay;
    public string[] sentences;
    public float typeSpeed;
    public GameObject continueBtn;
    public string scene;
    private bool loadLock;
    private int index;


    IEnumerator Type(){
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
       if (textDisplay.text == sentences[index])
       {
           continueBtn.SetActive(true);
       } 
    }
    public void NextSentence(){
        continueBtn.SetActive(false);
        if(index < sentences.Length -1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueBtn.SetActive(false);
            NextScene();
        }
    }

    public void NextScene()
    {
        if (!loadLock)
        {
            loadLock = true;
            SceneManager.LoadScene(scene);
        }
    }
}
