using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonContainer : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public int maxButton;
    public bool shouldOpenDoor;
    public List<GameObject> linkedDoors = new List<GameObject>();
    // Use this for initialization

    private void Update()
    {
        if (maxButton == buttons.Count && !shouldOpenDoor) 
        {
            shouldOpenDoor = true;
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        foreach (var door in linkedDoors)
        {
            var triggerArea = door.GetComponentInChildren<TriggerArea>();
            var doors = door.GetComponentsInChildren<Door>();
            foreach (var d in doors)
            {
                d.ToggleDoorState(triggerArea);
            }
            print(triggerArea.isTriggerActivated);
        }
    }
}
