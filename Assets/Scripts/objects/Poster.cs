using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poster : Object
{
    protected override void OnMouseDown()
    {
        PopupMessage.ShowPopupMessage(message, promt);
    }
}
