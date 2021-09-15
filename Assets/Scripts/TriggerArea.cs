using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int id;
    public GameObject connectedDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerControler>().currentShape == connectedDoor.GetComponent<Door>().doorShape)
                GameEvents.current.DoorwayTriggerEnter(id);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            GameEvents.current.DoorwayTriggerExit(id);
    }
}
