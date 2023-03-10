using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D newCursor;

    public void OnMouseEnter()
    {
        Cursor.SetCursor(newCursor, new Vector2(32, 32), CursorMode.ForceSoftware);
    }
    public void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, new Vector2(32, 32), CursorMode.ForceSoftware);
    }
    private void OnDestroy()
    {
        Cursor.SetCursor(defaultCursor, new Vector2(32, 32), CursorMode.ForceSoftware);
    }
}
