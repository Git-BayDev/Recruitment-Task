using System.Threading.Tasks;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public MeshRenderer render;
    public MeshRenderer lidRender;
    private Material orgMaterial;
    private Material newMaterial;
    public Animator animator;

    public ChestSpawn ChestSpawn;
    private UIController controller;
    public bool isOpened = false;

    private void Start()
    {
        ChestSpawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ChestSpawn>();
        controller = GameObject.FindGameObjectWithTag("DisplayUI").GetComponent<UIController>();

        orgMaterial = render.material;
        newMaterial = new Material(orgMaterial);
        newMaterial.color = orgMaterial.color * 2;
    }

    private void OnMouseDown()
    {
        if (!isOpened) {
            controller.openUI.SetActive(true);
        }
        if(isOpened)
        {
            controller.takeUI.SetActive(true);
        }
     //   animator.SetBool("IsOpened",true);
     //   ChestSpawn.spawnChest();
      //  await Task.Delay(1000);
     //   Destroy(gameObject);
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
