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

    public List<GameObject> ObjectsToToggle;

    protected virtual void Start()
    {
        ObjectsToToggle.Add(this.gameObject);
        baseMaterial = transform.GetChild(0).GetComponent<MeshRenderer>().material;
        animator = GetComponent<Animator>();
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
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
        if (isResting)
            yield break;

        isResting = true;
        yield return new WaitForSeconds(0.3f);
        isResting = false;
    }
}
