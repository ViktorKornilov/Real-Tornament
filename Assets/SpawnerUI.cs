using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerUI : MonoBehaviour
{
	public AudioClip roundStartedSound;

	public void WaveStart()
	{
		AudioSystem.Play(roundStartedSound);
	}
}