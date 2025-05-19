using System.Threading.Tasks;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public MeshRenderer render;
    public MeshRenderer lidRender;
    private Material orgMaterial;
    private Material newMaterial;
    public Animator animator;
    private UIController controller;
    public bool isOpened = false;

    private void Start()
    {
 
        controller = GameObject.FindGameObjectWithTag("DisplayUI").GetComponent<UIController>();

        orgMaterial = render.material;
        newMaterial = new Material(orgMaterial);
        newMaterial.color = orgMaterial.color * 2;
    }

    private void OnMouseDown()
    {
        if (controller.canClick)
        {
            if (!isOpened)
            {
                controller.openUI.SetActive(true);
                controller.canClick = false;
            }
            if (isOpened)
            {
                controller.takeUI.SetActive(true);
                controller.canClick = false;
            }
        }
    }

    private void OnMouseEnter()
    {
        render.material = newMaterial;
        lidRender.material = newMaterial;
        
    }

    private void OnMouseExit()
    {
        render.material = orgMaterial;
        lidRender.material = orgMaterial;
    }

}
