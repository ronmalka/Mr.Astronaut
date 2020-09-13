using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public static bool gamePause = false;
    public static bool gameEnd = false;
    public GameObject[] MenuUI;
    private bool loadLock;
    public GameObject DialogUI;
    private Dialog dialogScript;
    

    // Start is called before the first frame update
    void Start()
    {
        dialogScript = GameObject.Find("Dialog").GetComponent<Dialog>();
        DialogUI.SetActive(false);
        Time.timeScale = 1f;
        gameEnd = false;
        for (int i = 0; i < 3; i++)
        {
            MenuUI[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameEnd)
            {
                return;
            }
            if (gamePause)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        MenuUI[0].SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
    }

    void Pause()
    {
        MenuUI[0].SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
    }

    public void LoadMenu()
    {
        if (!loadLock)
        {
            loadLock = true;
            SceneManager.LoadScene("SplashScene");
        }
        loadLock = false;
    }
  public void Restart()
    {
        Time.timeScale = 1f;
        ScoreScript.scoreVal = 0 ;
        KeyScript.keysVal = 0;

        if (!loadLock)
        {
            loadLock = true;
            SceneManager.LoadScene("Level");
        }
        loadLock = false;
    }

    public void gameOver()
    {
      StartCoroutine(Over());
    }
    public void gameWin()
    {
        MenuUI[2].SetActive(true);
        Time.timeScale = 0f;
        gameEnd = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator Over()
    {
        yield return new WaitForSeconds(0.7f);
        MenuUI[1].SetActive(true);
        Time.timeScale = 0f;
        gameEnd = true;
    }
    

    public void startDialog(string sentences)
    {
        DialogUI.SetActive(true);
        dialogScript.setSentences(sentences);
        dialogScript.startSentence();
    }
    public void stopDialog()
    {
        DialogUI.SetActive(false);
    }

}
