using UnityEngine.Audio;
using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : Singleton<MusicManager>
{

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;
	public Sound CurrentlyPlayingSound { get; set; }

	public void Play(string sound, ulong delay = 0)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		if (s.source == null)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
			s.source.volume = s.volume;
			s.source.outputAudioMixerGroup = s.mixerGroup;
			s.source.pitch = s.pitch;
		}

		CurrentlyPlayingSound = s;

		s.source.Play(delay);

	}


    private void Start()
    {
		Play("Music1");
		StartCoroutine(LoopMusics());
    }

	IEnumerator LoopMusics()
    {
        while (true)
        {
			yield return new WaitForSeconds(CurrentlyPlayingSound.clip.length- 1.5f);
			int i = UnityEngine.Random.Range(0, sounds.Length - 1);
			ChangeMusic(sounds[i].name, 1f);
		}
    }

    public void ChangeMusic(string nextMusic, float duration)
	{
		if (CurrentlyPlayingSound != null)
		{
			StartCoroutine(MusicFade(CurrentlyPlayingSound.mixerGroup.audioMixer, CurrentlyPlayingSound.mixerGroup.name + "Volume", duration, 0));
		}

		Play(nextMusic);
		StartCoroutine(MusicFade(CurrentlyPlayingSound.mixerGroup.audioMixer, CurrentlyPlayingSound.mixerGroup.name + "Volume", duration, 1));
	}

	private IEnumerator MusicFade(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume)
	{
		float currentTime = 0;
		float currentVol;
		audioMixer.GetFloat(exposedParam, out currentVol);
		currentVol = Mathf.Pow(10, currentVol / 20);
		float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);

		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
			audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
			yield return null;
		}
		yield break;
	}
	public void StopPlaying(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		if (s.source == null)
		{
			Debug.LogWarning("AudioSouce: not found!");
			return;
		}

		s.source.Stop();
	}

}


