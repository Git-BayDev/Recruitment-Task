using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Camera mainMenuCam;
    public Camera gameCam;
    public Timer timer;
    private float bestTime;
    private float lastTime;
    public TextMeshProUGUI score;

    private void Start()
    {
        lastTime = timer.currTime;
    }

    public void updateScore() 
    {
        if (lastTime > bestTime) 
        {
         bestTime = lastTime;
            int min = (int)(bestTime / 60f);
            int sec = (int)(bestTime % 60f);
            int msec = (int)((bestTime - Mathf.FloorToInt(bestTime)) * 100);

            string time = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);

            score.text = "Your best score: " + time;
        }
    }

    public void startGame() 
    {
        mainMenuCam.enabled = false;
        gameCam.enabled = true;
        timer.currTime = 0;
    }


    public void quitGame()
    { 
        Application.Quit();
    }


}
