using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FovObjects : MonoBehaviour
{
    private Material solidMaterial;
    public Material transparentMaterial;
    private List<MeshRenderer> childsMeshs = new List<MeshRenderer>();
    void Start()
    {
        if (GetComponent<MeshRenderer>())
        {
            childsMeshs.Add(GetComponent<MeshRenderer>());
            solidMaterial = GetComponent<MeshRenderer>().material;
        }
            
        foreach (Transform t in transform)
        {
            var mesh = t.GetComponent<MeshRenderer>();
            childsMeshs.Add(mesh);
            if (solidMaterial == null)
                solidMaterial = mesh.material;
        }

    }

    public void TurnToSolid()
    {
        foreach(var mesh in childsMeshs)
        {
            mesh.material = solidMaterial;
        }
          

    }

    public void TurnToTransparent()
    {
        foreach (var mesh in childsMeshs)
        {
            mesh.material = transparentMaterial;
        }
    }

}
