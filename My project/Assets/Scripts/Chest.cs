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

    private void Start()
    {
        ChestSpawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ChestSpawn>();


        orgMaterial = render.material;
        newMaterial = new Material(orgMaterial);
        newMaterial.color = orgMaterial.color * 2;
    }

    private async Task OnMouseDown()
    {
        print("Klik");
        animator.SetBool("IsOpened",true);
        ChestSpawn.spawnChest();
        await Task.Delay(1000);
        Destroy(gameObject);
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
