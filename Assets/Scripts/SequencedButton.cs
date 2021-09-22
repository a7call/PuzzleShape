﻿using System.Collections;
using UnityEngine;



public class SequencedButton : Button
{
    public int id;
    protected ButtonContainer container;

    protected override void Start()
    {
        base.Start();
        container = GetComponentInParent<ButtonContainer>();
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        animator.SetTrigger("ButtonPushTrigger");
        StartCoroutine(RestCo());

        if (container.buttons.Contains(gameObject))
            return;

        container.buttons.Add(gameObject);
   
        hasBeenPushed = true;
        SequenceCheck();

    }

    protected virtual void SequenceCheck()
    {
        if (id != container.buttons.IndexOf(gameObject))
        {

            foreach (var button in container.buttons)
            {
                var SqButton = button.GetComponent<SequencedButton>();
                SqButton.hasBeenPushed = false;
                SqButton.ToggleMecanisme(SqButton.hasBeenPushed);
            }

            container.buttons.Clear();
        }
        else
        {
            ToggleMecanisme(hasBeenPushed);
        }
    }

    protected override void ToggleMecanisme(bool hasBeenPushed)
    {
        if (hasBeenPushed)
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material = activatedMaterial;
        }
        else
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material = baseMaterial;
        }
    }


}
