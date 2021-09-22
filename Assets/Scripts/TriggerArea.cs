using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int id;
    public bool isTriggerActivated { get; set; }
    public GameObject connectedDoor;

    protected void Awake()
    {   
        if(connectedDoor!=null)
            SetTriggerArea(connectedDoor.GetComponent<Door>().isLocked);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (connectedDoor.GetComponent<Door>().doorShape == Shapes.None && isTriggerActivated)
                GameEvents.current.DoorwayTriggerEnter(id);

            if (other.GetComponent<PlayerControler>().currentShape == connectedDoor.GetComponent<Door>().doorShape && isTriggerActivated)
                GameEvents.current.DoorwayTriggerEnter(id);
        }
    }

    protected void OnTriggerExit(Collider other)
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
