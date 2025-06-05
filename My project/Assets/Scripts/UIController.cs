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
    
    [SerializeField] private ChestSpawn spawner;
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private Camera mainMenuCam;
    [SerializeField] private Camera gameCam;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private AudioManager audioManager;



    public static UIController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

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
    }
    public void setDoorRefference(Door doorRef)
    {
        door = doorRef;
    }

    public void openDoor()
    {
        keyRef.hasKey = false;
        openDoorUI.SetActive(false);
        Destroy(door.gameObject);
        canClick = true;
        keyRef.keyImageDisplay();


        // Reset gameloop
        if (keyRef.howManyKeysFound == keyRef.howManyKeys)
        {
            keyRef.howManyKeysFound = 0;
            mainMenu.gameLoop += 1;
            lastTime = timer.currTime;
            mainMenuCam.enabled = true;
            gameCam.enabled = false;
            gameCam.transform.position = camPosition;
            gameCam.transform.rotation = camRotation;
            mainMenu.gameObject.SetActive(true);
            makeButtonsInteractable(mainMenu.gameObject);
            mainMenu.updateScore();
            mainMenu.score.enabled = true;
            mainMenu.lastScore.enabled = true;
        }
        else {
            spawner.spawn(spawner.chest);
            spawner.spawn(spawner.door);
        }
        
    }

   public void openChest() 
    {
        chest.animator.SetTrigger("IsOpen");
        openUI.SetActive(false);
        makeButtonsInteractable(openUI);
        chest.isOpened = true;
        canClick = true;
        audioManager.playSFX(audioManager.chestOpening);
    }


    public void takeKey() 
    {
        takeUI.SetActive(false);
        makeButtonsInteractable(takeUI);
        chest.isOpened = false;
        keyRef.howManyKeysFound++;
        keyRef.hasKey = true;
        keyRef.keyImageDisplay();
        audioManager.playSFX(audioManager.keySound);
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

       // Dezaktywuj wszystkie przyciski
        makeButtonsInteractable(takeUI);
        makeButtonsInteractable(openUI);
        makeButtonsInteractable(openDoorUI);
        makeButtonsInteractable(doorClosedUI);
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
