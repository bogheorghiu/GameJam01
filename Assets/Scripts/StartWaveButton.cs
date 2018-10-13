using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaveButton : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		SpawnManager.OnWaveSpawned += HandleWaveSpawned;

		SpawnManager.OnWaveEnded += HandleWaveEnded;

		SpawnManager.OnGameRestarted += HandleGameRestarted;
	}
	
	public void Press()
	{
		SpawnManager.SpawnWave();
	}

	void HandleWaveSpawned()
	{
		gameObject.SetActive(false);
	}

	void HandleWaveEnded()
	{
		if(!SpawnManager.HasWavesLeft)
			return;

		gameObject.SetActive(true);
	}

	void HandleGameRestarted()
	{
		gameObject.SetActive(true);
	}
}
