using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueEnd : Interactable {

    private void OnMouseEnter()
    {
        FindObjectOfType<CursorManager>().changeCursor("SceneChangeIcon");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            walk();
            if (itemRequired == "")
            {
                StartCoroutine("waitForTrigger");
            }
        }
    }
}
