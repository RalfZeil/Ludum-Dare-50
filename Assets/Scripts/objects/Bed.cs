using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Object
{
    protected override void OnMouseDown()
    {
        PopupMessage.ShowPopupMessage(message, promt);
        player.interacted(0, 0, 0);
    }
}
