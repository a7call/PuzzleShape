using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shapes
{
    Sphere,
    Cube,
    Prisme,
    Ressort, 
    None
}
public class Door : MonoBehaviour, IToggleObject
{
    public bool isLocked = false;
    public int id;
    public Shapes doorShape;

    public bool isRightDoor;

    public Material activatedMaterial;
    private Material baseMaterial;
    void Start()
    {
        baseMaterial = GetComponent<MeshRenderer>().material;
        GameEvents.current.onDoorwayTriggerEnter += OnDoorWayOpen;      
        GameEvents.current.onDoorwayTriggerExit += OnDoorWayClose;
        SetDoorState();
    }

    private void OnDisable()
    {
        GameEvents.current.onDoorwayTriggerEnter -= OnDoorWayOpen;
        GameEvents.current.onDoorwayTriggerExit -= OnDoorWayClose;
    }

    private void OnDoorWayOpen(int id)
    {
        if (id == this.id)
        {
            if(isRightDoor)
                LeanTween.rotateLocal(this.gameObject, new Vector3(0, 90, 0), 0.5f);
            else
                LeanTween.rotateLocal(this.gameObject, new Vector3(0, -90, 0), 0.5f);
        }
        GetComponent<Collider>().enabled = false;
    }
    private void OnDoorWayClose(int id)
    {
        if ( id == this.id)
        {
            if (isRightDoor)
                LeanTween.rotateLocal(this.gameObject, new Vector3(0, 0, 0), 0.51f);
            else
                LeanTween.rotateLocal(this.gameObject, new Vector3(0, 0, 0), 0.51f);
        }
        GetComponent<Collider>().enabled = true;
    }

    public void ToggleMecanisme()
    {
        isLocked = !isLocked;
        SetDoorState();
        var triggerArea = transform.parent.GetComponentInChildren<TriggerArea>();
        triggerArea.SetTriggerArea(isLocked);

    }
    private void SetDoorState()
    {
        if (isLocked)
            GetComponent<MeshRenderer>().material = baseMaterial;
        else
            GetComponent<MeshRenderer>().material = activatedMaterial;
    }
}
