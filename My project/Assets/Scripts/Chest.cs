using UnityEngine;

public class Chest : MonoBehaviour
{
    public MeshRenderer render;
    public MeshRenderer lidRender;
    private Material orgMaterial;
    private Material newMaterial;
    public Animator animator;


    private void Start()
    {
        orgMaterial = render.material;
        newMaterial = new Material(orgMaterial);
        newMaterial.color = orgMaterial.color * 2;
    }

    private void OnMouseDown()
    {
        print("Klik");
        animator.SetBool("IsOpened",true);
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
