using System.Collections;
using UnityEngine;


public class FovObjects : MonoBehaviour
{
    public Material solidMaterial;
    public Material transparentMaterial;
    private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = solidMaterial;
    }

    public void TurnToSolid()
    {
        meshRenderer.material = solidMaterial;

    }

    public void TurnToTransparent()
    {
        meshRenderer.material = transparentMaterial;
    }

}
