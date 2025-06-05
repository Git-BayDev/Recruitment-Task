using System.Threading.Tasks;
using UnityEngine;

public class Chest : Interact
{
    public Animator animator;
    private UIController controller;
    public bool isOpened = false;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = AudioManager.Instance;
        controller = UIController.Instance;
        controller.setChestRefference(this);
    }

    private void OnMouseDown()
    {
        if (controller.canClick)
        {
        audioManager.playSFX(audioManager.popUI);
            if (!isOpened)
            {
                controller.openUI.SetActive(true);
                controller.makeButtonsInteractable(controller.openUI);
                controller.canClick = false;
            }
            if (isOpened)
            {
                controller.takeUI.SetActive(true);
                controller.makeButtonsInteractable(controller.takeUI);
                controller.canClick = false;
            }
        }
    }


}
