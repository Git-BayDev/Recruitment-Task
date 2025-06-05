using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Door : Interact
{
    private UIController controller;
    private Key keyRef;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        keyRef = Key.Instance;
        controller = UIController.Instance;
        controller.setDoorRefference(this);
    }



    public void OnMouseDown()
    {
        if (controller.canClick)
        {
        audioManager.playSFX(audioManager.popUI);
            if (!keyRef.hasKey)
            {
                controller.doorClosedUI.SetActive(true);
                controller.makeButtonsInteractable(controller.doorClosedUI);
                controller.canClick = false;
            }
            else
            {
                controller.openDoorUI.SetActive(true);
                controller.makeButtonsInteractable(controller.openDoorUI);
                controller.canClick = false;
            }
        }
    }

}
