using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftingBench : Object
{
    protected override void OnMouseDown()
    {
        PopupMessage.ShowPopupMessage(message, promt);
        player.interacted(-1, 1, 0);
    }
}
