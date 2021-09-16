using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private GameObject player;

    private List<FovObjects> objectInFov = new List<FovObjects>();
    private List<FovObjects> transparentObject = new List<FovObjects>();
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = new Vector3(12, 12, -12);
       // offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        LookForObjectInFOV();
        SetWallsToTransparent();
        SetWallsToSolid();
        objectInFov.Clear();
    }

    void LookForObjectInFOV()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Ray ray = new Ray(transform.position, (player.transform.position -transform.position).normalized);
        var hits = Physics.RaycastAll(ray, distance);

        foreach(var hit in hits)
        {
            if(hit.transform.TryGetComponent(out FovObjects fovObject))
            {
                objectInFov.Add(fovObject);
            }
        }
    }

    void SetWallsToTransparent()
    {
        foreach(var wall in objectInFov.ToArray())
        {
            if (!transparentObject.Contains(wall))
            {
                transparentObject.Add(wall);
                wall.TurnToTransparent();
               
            }
        }
    }

    void SetWallsToSolid()
    {
        foreach(var fovObject in transparentObject.ToArray())
        {
            if (!objectInFov.Contains(fovObject))
            {
                transparentObject.Remove(fovObject);
                fovObject.TurnToSolid();
                
            }
        }
    }
}
