using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Camera mainMenuCam;
    public Camera gameCam;



    public void startGame() 
    {
        mainMenuCam.enabled = false;
        gameCam.enabled = true;
    }

}
