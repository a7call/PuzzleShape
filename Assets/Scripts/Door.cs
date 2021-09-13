using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shapes
{
    Sphere,
    Cube,
    Prisme
}
public class Door : MonoBehaviour
{
    bool isOpen = false;
    public int id;
    public Shapes doorShape;
    void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorWayOpen;      
        GameEvents.current.onDoorwayTriggerExit += OnDoorWayClose;      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDoorWayOpen(int id)
    {

        if (!isOpen && id == this.id)
        {
            LeanTween.moveLocalY(gameObject, 2.5f, 1f);
            isOpen = true;
        }    
    }
    private void OnDoorWayClose(int id)
    {
        if (isOpen && id == this.id)
        {
            LeanTween.moveLocalY(gameObject, 0, 1f);
            isOpen = false;
        }      
    }
}
