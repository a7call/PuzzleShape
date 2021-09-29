using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonContainer : MonoBehaviour
{
    public GameObject door;

    [HideInInspector]
    public List<GameObject> buttons = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> ToggledObjects = new List<GameObject>();

    public int maxButton;

    private bool shouldOpenDoor;
    // Use this for initialization
    private void Start()
    {
       // maxButton = transform.childCount;
    }
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
        var ds = door.GetComponentsInChildren<Door>();

        foreach(var d in ds)
            d.ToggleMecanisme();
    }
}
