using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Material activatedMaterial;
    private Material baseMaterial;

    private Animator animator;

    public List<GameObject> linkedDoors;
    public List<GameObject> linkedSpawners;

    private bool hasBeenPushed;
    private bool isResting;

    private void Start()
    {
        baseMaterial = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isResting)
            return;

        if (collision.transform.CompareTag("Player"))
        {
            animator.SetTrigger("ButtonPushTrigger");

            ToggleMecanisme(hasBeenPushed);
            hasBeenPushed = !hasBeenPushed;
            StartCoroutine(RestCo());
        }


    }
    private IEnumerator RestCo()
    {
        isResting = true;
        yield return new WaitForSeconds(1f);
        isResting = false;
    }

    private void ToggleMecanisme(bool hasBeenPushed)
    {
        if (!hasBeenPushed)
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material = activatedMaterial;
        }
        else
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material = baseMaterial;
        }

        foreach (var door in linkedDoors)
        {
            var triggerArea = door.GetComponentInChildren<TriggerArea>();
            var doors = door.GetComponentsInChildren<Door>();
            foreach (var d in doors)
            {
                d.ToggleDoorState(triggerArea);
            }

        }

        foreach (var spanwer in linkedSpawners)
            spanwer.GetComponent<ShapeSpawner>().ToggleState();

    }
}
