using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int id;
    public bool isTriggerActivated { get; set; }
    public GameObject connectedDoor;

    private void Awake()
    {      
        SetTriggerArea(connectedDoor.GetComponent<Door>().isLocked);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (connectedDoor.GetComponent<Door>().doorShape == Shapes.None && isTriggerActivated)
                GameEvents.current.DoorwayTriggerEnter(id);

            if (other.GetComponent<PlayerControler>().currentShape == connectedDoor.GetComponent<Door>().doorShape && isTriggerActivated)
                GameEvents.current.DoorwayTriggerEnter(id);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            GameEvents.current.DoorwayTriggerExit(id);
    }
    public void SetTriggerArea(bool isLocked)
    {
        if (isLocked)
            isTriggerActivated = false;
        else
            isTriggerActivated = true;
    }
}
