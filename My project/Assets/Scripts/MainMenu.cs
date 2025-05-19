using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject chest;
    public GameObject door;
    public ChestSpawn Spawner;
    public Camera mainMenuCam;
    public Camera gameCam;
    public Timer timer;
    private float bestTime = 1000f;
    private float lastTime;
    public TextMeshProUGUI score;
    public TextMeshProUGUI lastScore;
    [SerializeField] private UIController ui;
    public int gameLoop = 0;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (gameLoop != 0)
        {
            score.enabled = true;
            lastScore.enabled = true;
        }
        else 
        {
            score.enabled = false;
            lastScore.enabled = false;
        }
        updateScore();
    }

    public void updateScore() 
    {
        if (gameLoop != 0)
        {
            lastTime = ui.lastTime;
            if (lastTime < bestTime)
            {
                bestTime = lastTime;
                int min = (int)(bestTime / 60f);
                int sec = (int)(bestTime % 60f);
                int msec = (int)((bestTime - Mathf.FloorToInt(bestTime)) * 100);

                string time = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);
                score.text = "Your best score: " + time;
            }
            int min2 = (int)(lastTime / 60f);
            int sec2 = (int)(lastTime % 60f);
            int msec2 = (int)((lastTime - Mathf.FloorToInt(lastTime)) * 100);
            string time2 = string.Format("{0:00}:{1:00}:{2:00}", min2, sec2, msec2);
            lastScore.text = "Your last score: " + time2;
        }
    }

    public void startGame() 
    {
        mainMenuCam.enabled = false;
        gameCam.enabled = true;
        timer.currTime = 0;
        if (gameLoop != 0)
        {
            Spawner.spawn(chest);
            Spawner.spawn(door);
            ui.findObjects();
        }
        
    }


    public void quitGame()
    { 
        Application.Quit();
    }


}
