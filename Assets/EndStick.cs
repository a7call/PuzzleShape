using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class EndStick : MonoBehaviour
{
    public Sound[] victorySounds;
    private AudioSource source;
    bool hasWon = false;
    public void Start()
    {
        source = GetComponent<AudioSource>();
        foreach (var s in victorySounds)
        {
            s.source = source;
        }
           
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasWon)
        {
            hasWon = true;
            StartCoroutine(GoToNextLevel());
        }
    }

    IEnumerator GoToNextLevel()
    {
        int i = Random.Range(0, victorySounds.Length - 1);
        source.volume = victorySounds[i].volume;
        MusicManager.GetInstance().CurrentlyPlayingSound.source.volume /= 2;
        source.PlayOneShot(victorySounds[i].clip);
        
        yield return new WaitForSeconds(victorySounds[i].clip.length);

        MusicManager.GetInstance().CurrentlyPlayingSound.source.volume *= 2;

        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);
    }
}
