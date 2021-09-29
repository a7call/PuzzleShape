using UnityEngine;


public class SequencedButtonShape : SequencedButton
{
    public GameObject associatedShape;
    protected override void SequenceCheck()
    {
        if (associatedShape != null)
            associatedShape.GetComponent<SequencedShape>().ToggleMecanisme();


        container.ToggledObjects.Add(associatedShape.gameObject);
        container.ToggledObjects.Add(this.gameObject);

        ToggleMecanisme();
 
        if (id != container.buttons.IndexOf(gameObject))
        {
            foreach (var obj in container.ToggledObjects)
            {
                var SqButton = obj.GetComponent<IToggleObject>();
                SqButton.ToggleMecanisme();
            }
            container.ToggledObjects.Clear();
            container.buttons.Clear();
        }
    }

}

