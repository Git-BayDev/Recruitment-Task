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
    public Key keyRef;
    public bool canClick = true;
    public float lastTime;

    private Chest chest;
    private Door door;
    private Vector3 camPosition;
    private Quaternion camRotation;

    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private Camera mainMenuCam;
    [SerializeField] private Camera gameCam;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private AudioManager audioManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camPosition = gameCam.transform.position;
        camRotation = gameCam.transform.rotation;
        
        openUI.SetActive(false);
        takeUI.SetActive(false);
        doorClosedUI.SetActive(false);
        openDoorUI.SetActive(false);

    }




    public void setChestRefference(Chest chestRef) 
    {
        chest = chestRef;
    } public void setDoorRefference(Door doorRef) 
    {
        door = doorRef;
    }


    private void Update()
    {
        makeButtonsInteractable(takeUI);
        makeButtonsInteractable(openUI);
        makeButtonsInteractable(openDoorUI);
        makeButtonsInteractable(doorClosedUI);
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
        gameCam.transform.position = camPosition;
        gameCam.transform.rotation = camRotation;
        mainMenu.gameObject.SetActive(true);
        
    }

   public void openChest() 
    { 
        chest.animator.SetBool("IsOpened", true);
        openUI.SetActive(false);
        chest.isOpened = true;
        canClick = true;
        audioManager.playSFX(audioManager.chestOpening);
    }


    public void takeKey() 
    {
        takeUI.SetActive(false);
        chest.isOpened = false;
        keyRef.hasKey = true;
        audioManager.playSFX(audioManager.keySound);
        Destroy(chest.gameObject);
        canClick = true;
        chest.isOpened = false;
    }

    public void pressNo()
    {
        openUI.SetActive(false);
        takeUI.SetActive(false);
        doorClosedUI.SetActive(false);
        openDoorUI.SetActive(false);
        canClick = true;
    }

    public void makeButtonsInteractable(GameObject button) 
    {
        foreach(Button bt in button.GetComponentsInChildren<Button>())
        {
            if (button.activeInHierarchy == false)
            {
                bt.interactable = false;
            }
            else
            {
                bt.interactable = true;
            }
        }
    }
}
