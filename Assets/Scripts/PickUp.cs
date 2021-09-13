using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Mesh formeComestible;
    public Rigidbody comestible;
    public GameObject spawnPoint;
    public Shapes shape;
    

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
        if (other.CompareTag("Player"))
        {
            other.GetComponent<MeshFilter>().mesh = formeComestible;
            other.GetComponent<PlayerControler>().currentShape = shape;
        }
    }

    
   
}

