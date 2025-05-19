using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public bool hasKey = false;
    public Image missingKey;
    public Image key;
    public Camera cam;
    private void Start()
    {
        missingKey.enabled = false;
        key.enabled = false;
    }


    private void Update()
    {
        if (cam.enabled == true)
        {
            if (!hasKey)
            {
                missingKey.enabled = true;
                key.enabled = false;
            }
            else
            {
                key.enabled = true;
                missingKey.enabled = false;
            }
        }
        else 
        {
            missingKey.enabled = false;
            key.enabled = false;

        }
    }



}
