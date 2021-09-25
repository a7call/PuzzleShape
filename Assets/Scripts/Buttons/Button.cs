using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Button : MonoBehaviour, IToggleObject
{
    public Material activatedMaterial;
    protected Material baseMaterial;

    protected Animator animator;

    protected bool hasBeenPushed;
    protected bool isResting;

    public List<GameObject> ToggledObjects;

    protected virtual void Start()
    {
        ToggledObjects.Add(this.gameObject);
        baseMaterial = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        animator = GetComponent<Animator>();
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (isResting)
            return;

        animator.SetTrigger("ButtonPushTrigger");
        StartCoroutine(RestCo());
    }

    public virtual void ToggleButton()
    {
        ToggleMecanisme();
    }
    public void ToggleMecanisme()
    {
        hasBeenPushed = !hasBeenPushed;
        if (!hasBeenPushed)
            transform.GetChild(0).GetComponent<MeshRenderer>().material = activatedMaterial;
        else
            transform.GetChild(0).GetComponent<MeshRenderer>().material = baseMaterial;
    }

    protected IEnumerator RestCo()
    {
        isResting = true;
        yield return new WaitForSeconds(1.5f);
        isResting = false;
    }
}
