using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Timer timer;
    public GameObject openUI;
    public GameObject takeUI;
    public GameObject doorClosedUI;
    public GameObject openDoorUI;
    private Chest chest;
    public Key keyRef;
    private Door door;
    public float lastTime;
    public bool canClick = true;
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private Camera mainMenuCam;
    [SerializeField] private Camera gameCam;
    [SerializeField] private TextMeshProUGUI timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        findObjects();
        
        openUI.SetActive(false);
        takeUI.SetActive(false);
        doorClosedUI.SetActive(false);
        openDoorUI.SetActive(false);

    }


    public void findObjects()
    {
        chest = GameObject.FindGameObjectWithTag("Chest").GetComponent<Chest>();
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();
    }




    public void openDoor()
    {
        keyRef.hasKey = false;
        openDoorUI.SetActive(false);
        Destroy(door.gameObject);
        lastTime = timer.currTime;
        mainMenu.gameLoop += 1;
        canClick = true;


        // Reset gameloop
        mainMenuCam.enabled = true;
        gameCam.enabled = false;
        chest.isOpened = false;
        chest.animator.SetBool("IsOpened", false);
    }

   public void openChest() 
    { 
        chest.animator.SetBool("IsOpened", true);
        openUI.SetActive(false);
        chest.isOpened = true;
        canClick = true;
    }


    public void takeKey() 
    {
        takeUI.SetActive(false);
        chest.isOpened = false;
        keyRef.hasKey = true;
        Destroy(chest.gameObject);
        canClick = true;
    }

    public void pressNo()
    {
        openUI.SetActive(false);
        takeUI.SetActive(false);
        doorClosedUI.SetActive(false);
        openDoorUI.SetActive(false);
        canClick = true;
    }
}
