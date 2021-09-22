using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencedTriggerArea : TriggerArea
{
   

    protected override void OnTriggerEnter(Collider other)
    {
        if (connectedDoor.GetComponent<Door>().doorShape == Shapes.None && isTriggerActivated)
            GameEvents.current.DoorwayTriggerEnter(id);

        
    }



}
