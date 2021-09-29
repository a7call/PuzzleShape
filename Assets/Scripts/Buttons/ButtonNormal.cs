using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNormal : Button
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (isResting)
            return;
        base.OnCollisionEnter(collision);
 
        ToggleButton();
        hasBeenPushed = !hasBeenPushed;
    }

    public override void ToggleButton()
    {
        base.ToggleButton();

        foreach (var obj in ObjectsToToggle)
        {
            var ToggleObjs = obj.GetComponentsInChildren<IToggleObject>();
            foreach(var toggleObj in ToggleObjs)
                toggleObj.ToggleMecanisme();
        }
            
    }

   
}
