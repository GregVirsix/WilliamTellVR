﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioSource MusicAudioSource;
	public AudioClip[] DopeTracks;

	int currentSongIndex = 0;
	float currentSongLength = 0f;


	void Start () 
	{
		StartWithRandomSong();
	}

	void StartWithRandomSong()
	{
		if (DopeTracks.Length > 0)
		{
			currentSongIndex = Random.Range(0, DopeTracks.Length);
			MusicAudioSource.clip = DopeTracks[currentSongIndex];
			currentSongLength = DopeTracks[currentSongIndex].length;
			MusicAudioSource.Play();

			StartCoroutine(WaitUntilSongDone());
		}
	}

	IEnumerator WaitUntilSongDone()
	{
		yield return new WaitForSeconds(currentSongLength);
		PlayNextSong();
	}

	void PlayNextSong()
	{
		currentSongIndex++;
		MusicAudioSource.clip = DopeTracks[currentSongIndex];
		currentSongLength = DopeTracks[currentSongIndex].length;
		MusicAudioSource.Play();

		StartCoroutine(WaitUntilSongDone());
	}
}
