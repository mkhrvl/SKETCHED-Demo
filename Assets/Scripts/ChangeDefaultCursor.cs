using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeDefaultCursor : MonoBehaviour
{
    public Texture2D cursorArrow;

    void Start() {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.Auto);

        if(SceneManager.GetActiveScene().buildIndex == 1) {
            Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
