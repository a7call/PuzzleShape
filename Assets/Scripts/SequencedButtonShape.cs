﻿using UnityEngine;


public class SequencedButtonShape : SequencedButton
{
    public GameObject associatedShape;
    protected override void SequenceCheck()
    {
        if (id != container.buttons.IndexOf(gameObject))
        {

            foreach (var button in container.buttons)
            {
                var SqButton = button.GetComponent<SequencedButtonShape>();
                SqButton.hasBeenPushed = false;
                SqButton.ToggleMecanisme(SqButton.hasBeenPushed);
            }
            if(associatedShape != null)
                associatedShape.GetComponent<SequencedShape>().ToggleMat(hasBeenPushed);
            container.buttons.Clear();
        }
        else
        {
            if (associatedShape != null)
                associatedShape.GetComponent<SequencedShape>().ToggleMat(hasBeenPushed);
            ToggleMecanisme(hasBeenPushed);
        }
    }

}

