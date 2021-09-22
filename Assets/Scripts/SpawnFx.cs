using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFx : MonoBehaviour
{
    public Material unActivatedMaterial;
    private Material activatedMaterial;
    void Start()
    {
        activatedMaterial = GetComponent<ParticleSystemRenderer>().material;
    }

    // Update is called once per frame
    internal void ChangeState(bool isActivated)
    {
        print("tess");
        if (isActivated)
            GetComponent<ParticleSystemRenderer>().material = activatedMaterial;
        else
            GetComponent<ParticleSystemRenderer>().material = unActivatedMaterial;
    }
}
