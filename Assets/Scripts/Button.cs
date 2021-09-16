using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator animator;
    public GameObject linkedDoor;
    public Material activatedMaterial;
    private void Start()
    {      
        animator = GetComponent<Animator>();      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            animator.SetTrigger("ButtonPushTrigger");

            transform.GetChild(0).GetComponent<MeshRenderer>().material = activatedMaterial;

            if (linkedDoor == null)
            {
                Debug.LogWarning("No Doors Are Associated With This Button");
                return;
            }
               
            linkedDoor.GetComponentInChildren<Door>().GetComponent<MeshRenderer>().material = activatedMaterial;
            linkedDoor.GetComponentInChildren<TriggerArea>().isButtonActivated = true;

        }
    }
}
