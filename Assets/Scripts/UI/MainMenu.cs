using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Sprite SoundOn;
    public Sprite SoundOff;
    public static bool isSoundOn = true;

    private void OnEnable()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void DisableMusics()
    {
        isSoundOn =  !isSoundOn;
        AudioListener.pause = !AudioListener.pause;
        var buttonObject = EventSystem.current.currentSelectedGameObject;
        if (isSoundOn)
        {
            buttonObject.GetComponent<Image>().sprite = SoundOn;
            
        }
        else
        {
            buttonObject.GetComponent<Image>().sprite = SoundOff;
        }
           
    }
}
