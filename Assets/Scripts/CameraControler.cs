using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private GameObject player;
    void Start()
    {
        offset = new Vector3(12, 12, -12);
       // offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
