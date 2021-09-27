using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManagementMenu : MonoBehaviour
{
    public void GoToSpecificLevel()
    {
        var buttonObject = EventSystem.current.currentSelectedGameObject;
        var text = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
        SceneManager.LoadScene(int.Parse(text.text));
    }
}
