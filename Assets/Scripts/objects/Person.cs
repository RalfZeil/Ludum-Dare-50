using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : Object
{

    [SerializeField] int strength;


    protected override void OnMouseDown()
    {
        player.SetupFight(strength);
    }

    public void changeStrength(int daysPassed)
    {
        if(daysPassed > 15)
        {
            strength = daysPassed + 5;
        }
    }
}
