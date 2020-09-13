using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene;
    private bool loadLock;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        if (!loadLock)
        {
            loadLock = true;
            SceneManager.LoadScene(scene);
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
