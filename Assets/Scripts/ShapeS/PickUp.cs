using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Mesh formeComestible;
    public Shapes shape;

    public Material unActivatedMat;
    public Material activatedMat;


    private void Start()
    {
        formeComestible = GetComponent<MeshFilter>().mesh;
        
    }
    void Update()
    {
        transform.Rotate(new Vector3(50, 30, 45) * Time.deltaTime);       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GetComponentInParent<ShapeSpawner>().isActivated)
            return;

        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            other.GetComponent<MeshFilter>().mesh = formeComestible;
            other.GetComponent<PlayerControler>().currentShape = shape;
        }
    }
    private void OnEnable()
    {
        var Spawn = GetComponentInParent<ShapeSpawner>();
        if(Spawn == null)
        {
            return;
        }

       ChangeState(Spawn.isActivated);
    }

    internal void ChangeState(bool isActivated)
    {
        if (isActivated)
            GetComponent<MeshRenderer>().material = activatedMat;
        else
            GetComponent<MeshRenderer>().material = unActivatedMat;
    }
}

