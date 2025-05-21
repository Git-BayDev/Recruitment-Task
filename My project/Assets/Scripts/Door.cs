using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Door : MonoBehaviour
{
    public Renderer wallRender;
    public Renderer doorRender;

    private Material orgMaterial;
    private Material newMaterial;
    private UIController controller;
    private Key keyRef;
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        keyRef = GameObject.FindGameObjectWithTag("DisplayUI").GetComponent<Key>();
        controller = GameObject.FindGameObjectWithTag("DisplayUI").GetComponent<UIController>();
        controller.setDoorRefference(this);
        orgMaterial = wallRender.material;
        newMaterial = new Material(orgMaterial);
        newMaterial.color = orgMaterial.color * 2f;
    }



    public void OnMouseDown()
    {
        if (controller.canClick)
        {
        audioManager.playSFX(audioManager.popUI);
            if (!keyRef.hasKey)
            {
                controller.doorClosedUI.SetActive(true);
                controller.canClick = false;
            }
            else
            {
                controller.openDoorUI.SetActive(true);
                controller.canClick = false;
            }
        }
    }

    private void OnMouseEnter()
    {
        wallRender.material = newMaterial;
        doorRender.material = newMaterial;
    }

    private void OnMouseExit()
    {
        wallRender.material = orgMaterial;
        doorRender.material = orgMaterial;
    }
}
