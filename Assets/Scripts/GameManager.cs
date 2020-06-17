using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public enum GameState { GameStart, GameOver ,GamePause}

    public Text txt_Score;
  //  public Text txt_TryAgain;

    private GameState CurrentState = GameState.GameOver;

    public Text HighScore1;
    public Text HighScore2;
    public Text HighScore3;
    public Text HighScore4;
    public Text HighScore5;

    private float rotation = 0;


    public float Score = 0;

    public GameObject ScorePage;
    public GameObject PlayerDuck;

    public GameObject Gameovertxt;
    public GameObject tryagain;
    public GameObject newHigh;

    public Animator enter2playermove;

    public Animator tryagainanim;
    public Animator Gameoveranim;
    public Animator HightAnim;



    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        txt_Score.text = "Score: " + Score.ToString("000");
        GameOver();

        HighScore1.text = "Score: " + PlayerPrefs.GetFloat("HighScore1", 0).ToString("000");
        HighScore2.text = "Score: " + PlayerPrefs.GetFloat("HighScore2", 0).ToString("000");
        HighScore3.text = "Score: " + PlayerPrefs.GetFloat("HighScore3", 0).ToString("000");
        HighScore4.text = "Score: " + PlayerPrefs.GetFloat("HighScore4", 0).ToString("000");
        HighScore5.text = "Score: " + PlayerPrefs.GetFloat("HighScore5", 0).ToString("000");

        tryagain.SetActive(false);
        newHigh.SetActive(false);
        Gameovertxt.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentState == GameState.GameOver)
        {
            rotation++;
            PlayerDuck.transform.rotation = Quaternion.Euler(0, rotation, 0);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameStart();
                CurrentState = GameState.GameStart;

            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PlayerPrefs.DeleteAll();

            }

        }

        if (CurrentState == GameState.GamePause && Input.GetKeyDown(KeyCode.Return))
        {
            GameOver();
            SceneManager.LoadScene(0);
        }



    }

    public void AddScore(int pointsToAdd)
    {
        Score += pointsToAdd;
        txt_Score.text = "Score: " + Score.ToString("000");

        if(Score>PlayerPrefs.GetFloat("HighScore1",0))
        {
            PlayerPrefs.SetFloat("HighScore1", Score);
        }

        else if (Score > PlayerPrefs.GetFloat("HighScore2", 0))
        {
            PlayerPrefs.SetFloat("HighScore2", Score);
        }

        else if (Score > PlayerPrefs.GetFloat("HighScore3", 0))
        {
            PlayerPrefs.SetFloat("HighScore3", Score);
        }

        else if (Score > PlayerPrefs.GetFloat("HighScore4", 0))
        {
            PlayerPrefs.SetFloat("HighScore4", Score);
        }

        else if (Score > PlayerPrefs.GetFloat("HighScore5", 0))
        {
            PlayerPrefs.SetFloat("HighScore5", Score);
        }



    }

    public void GameOver()
    {
        CurrentState = GameState.GameOver;
        Time.timeScale = 0;
        ScorePage.SetActive(true);
        enter2playermove.updateMode = AnimatorUpdateMode.UnscaledTime;


    }

    public void GamePause()
    {
        CurrentState = GameState.GamePause;
        Time.timeScale = 0;
        tryagain.SetActive(true);

        tryagainanim.updateMode = AnimatorUpdateMode.UnscaledTime;

        if (Score > PlayerPrefs.GetFloat("HighScore1", 0))
        {
            newHigh.SetActive(true);
            HightAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
        }

        else if (Score > PlayerPrefs.GetFloat("HighScore2", 0))
        {
            newHigh.SetActive(true);
            HightAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
        }

        else if (Score > PlayerPrefs.GetFloat("HighScore3", 0))
        {
            newHigh.SetActive(true);
            HightAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
        }

        else if (Score > PlayerPrefs.GetFloat("HighScore4", 0))
        {
            newHigh.SetActive(true);
            HightAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
        }

        else if (Score > PlayerPrefs.GetFloat("HighScore5", 0))
        {
            newHigh.SetActive(true);
            HightAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
        }

        else
        {
            Gameovertxt.SetActive(true);
            Gameoveranim.updateMode = AnimatorUpdateMode.UnscaledTime;
        }

    }

    public void GameStart()
    {
        Time.timeScale = 1;
        ScorePage.SetActive(false);
        PlayerDuck.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        // PlayerDuck.transform.Rotate(0,90,0);
        PlayerDuck.transform.rotation = Quaternion.Euler(0, 90, 0);

    }

}
