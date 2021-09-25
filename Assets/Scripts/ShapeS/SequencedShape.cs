using System.Collections;
using UnityEngine;


public class SequencedShape : MonoBehaviour, IToggleObject
{
    public Material activatedMat;
    public Material unActivatedMat;

    bool activated;

    private void Start()
    {
        unActivatedMat = GetComponent<MeshRenderer>().material;
    }

    public void ToggleMecanisme()
    {
        activated = !activated;
        if (activated)
        {
            GetComponent<MeshRenderer>().material = activatedMat;
        }
        else
        {
            GetComponent<MeshRenderer>().material = unActivatedMat;
        }
    }

}
