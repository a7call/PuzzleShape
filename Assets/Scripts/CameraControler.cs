using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private GameObject player;

    private List<Walls> wallsInFov = new List<Walls>();
    private List<Walls> transparentWalls = new List<Walls>();
    void Start()
    {
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
        wallsInFov.Clear();
    }

    void LookForObjectInFOV()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Ray ray = new Ray(transform.position, (player.transform.position -transform.position).normalized);
        var hits = Physics.RaycastAll(ray, distance);

        foreach(var hit in hits)
        {
            if(hit.transform.TryGetComponent<Walls>(out Walls wall))
            {
                wallsInFov.Add(wall);
            }
        }
    }

    void SetWallsToTransparent()
    {
        foreach(var wall in wallsInFov.ToArray())
        {
            if (!transparentWalls.Contains(wall))
            {
                transparentWalls.Add(wall);
                wall.TurnToTransparent();
               
            }
        }
    }

    void SetWallsToSolid()
    {
        foreach(var wall in transparentWalls.ToArray())
        {
            if (!wallsInFov.Contains(wall))
            {
                transparentWalls.Remove(wall);
                wall.TurnToSolid();
                
            }
        }
    }
}
