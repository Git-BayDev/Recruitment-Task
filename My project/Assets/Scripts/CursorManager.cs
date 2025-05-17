using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D normalCursor;
    [SerializeField] Texture2D pressedCursor;
    private Vector2 clickPosition;
    void Start()
    {
        clickPosition = new Vector2(normalCursor.width / 2, normalCursor.height / 4);
        Cursor.SetCursor(normalCursor,clickPosition,CursorMode.Auto);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
         Cursor.SetCursor(pressedCursor, clickPosition, CursorMode.Auto);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(normalCursor, clickPosition, CursorMode.Auto);
        }
    }

}
