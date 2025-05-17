using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject openUI;
    public GameObject takeUI;
    public GameObject doorClosedUI;
    public GameObject openDoorUI;
    private Chest chest;
    public Key keyRef;
    private Door door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chest = GameObject.FindGameObjectWithTag("Chest").GetComponent<Chest>();
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();
        openUI.SetActive(false);
        takeUI.SetActive(false);
        doorClosedUI.SetActive(false);
        openDoorUI.SetActive(false);

    }





    public void openDoor()
    {
        keyRef.hasKey = false;
        openDoorUI.SetActive(false);
        Destroy(door.gameObject);
    }

   public void openChest() 
    { 
        chest.animator.SetBool("IsOpened", true);
        openUI.SetActive(false);
        chest.isOpened = true;
    }


    public void takeKey() 
    {
        takeUI.SetActive(false);
        chest.isOpened = false;
        keyRef.hasKey = true;
        Destroy(chest.gameObject);
    }

    public void pressNo()
    {
        openUI.SetActive(false);
        takeUI.SetActive(false);
        doorClosedUI.SetActive(false);
        openDoorUI.SetActive(false);
    }
}
