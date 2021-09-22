using System.Collections;
using UnityEngine;


public class SequencedShape : MonoBehaviour
{
    public Material activatedMat;
    public Material unActivatedMat;

    private void Start()
    {
        unActivatedMat = GetComponent<MeshRenderer>().material;
    }

    public void ToggleMat(bool hasBeenPushed)
    {
        if (hasBeenPushed)
        {
            GetComponent<MeshRenderer>().material = activatedMat;
        }
        else
        {
            GetComponent<MeshRenderer>().material = unActivatedMat;
        }
    }

}
