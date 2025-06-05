using UnityEngine;

public abstract class Interact : MonoBehaviour
{
    public Renderer[] renderers;

    [SerializeField] protected Material highLightMaterial;
    [SerializeField] protected Material orgMaterial;

 


    private void OnMouseEnter()
    {
        foreach (var renderer in renderers) { 
        renderer.material = highLightMaterial;
        }
    }

    private void OnMouseExit()
    {
        foreach (var renderer in renderers)
        {
            renderer.material = orgMaterial;
        }
    }
}
