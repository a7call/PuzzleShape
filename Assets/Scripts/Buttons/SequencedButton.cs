using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SequencedButton : Button
{
    public int id;
    protected ButtonContainer container;


    protected override void Start()
    {
        base.Start();
        container = GetComponentInParent<ButtonContainer>();
        ToggledObjects.AddRange(container.buttons);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (container.buttons.Contains(gameObject))
            return;

        container.buttons.Add(gameObject);   
        hasBeenPushed = true;
        SequenceCheck();
    }

    protected virtual void SequenceCheck()
    {
        ToggleMecanisme();

        if (id != container.buttons.IndexOf(gameObject))
        {
            foreach (var obj in ToggledObjects)
            {
                var SqButton = obj.GetComponent<IToggleObject>();
                
                SqButton.ToggleMecanisme();
            }
            container.buttons.Clear();
        }
    }

}
