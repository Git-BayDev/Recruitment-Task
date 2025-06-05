using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public int howManyKeys = 0;
    public bool hasKey = false;
    public Image missingKey;
    public Image key;
    public Camera cam;

    [HideInInspector] public int howManyKeysFound = 0;
    public static Key Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        missingKey.enabled = false;
        key.enabled = false;
    }

    public void keyImageDisplay()
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
