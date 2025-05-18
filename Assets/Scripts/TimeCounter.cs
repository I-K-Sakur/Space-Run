using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TimeCounter : MonoBehaviour
{
    [SerializeField] private float timeToDisplay=180f;
    [SerializeField] private TextMeshProUGUI timeText;
    private bool isStopped = false;
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private GameWinOrOver gameWinOrOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopped)
        {
            timeToDisplay -= Time.deltaTime;
            int realTime = (int)timeToDisplay;
            timeText.text = "Time Remained: " + realTime.ToString()+"s";
            Debug.Log(timeToDisplay);
            GameOver();
            GameWinner();
        }
        else
        {
            GameRestart();
        }
    }

    public void GameOver()
    {
        if (timeToDisplay <= 0 && !gameWinOrOver.gameWin )
        {
            Time.timeScale = 0;
            isStopped = true;
            textMesh.text = "Press Enter to Restart";
            Debug.Log("Game Over");
        }
    }

    public void GameWinner()
    {
        if (timeToDisplay >= 0 && gameWinOrOver.gameWin )
        {
            Time.timeScale = 0;
            isStopped = true;
            textMesh.text = "You won!! Press Enter to Restart";
            Debug.Log("Game Winner");
        }
    }

    public void GameRestart()
    {
        if (isStopped)
        {
            Debug.Log("Restart the game");
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
    }
}
