using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Sprite SoundOn;
    public Sprite SoundOff;
    private void OnEnable()
    {
        if (MainMenu.isSoundOn)
        {
            GetComponent<Image>().sprite = SoundOn;

        }
        else
        {
            GetComponent<Image>().sprite = SoundOff;
        }
    }
}
