using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndStick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadScene(0);
        }
    }
}
