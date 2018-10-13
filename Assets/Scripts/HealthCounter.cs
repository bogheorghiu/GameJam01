using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour 
{
	[SerializeField]
	Text label = null;

	// Use this for initialization
	void Start () 
	{
		SpawnManager.OnCitizenFinished += HandleCitizenFinished;

		SpawnManager.OnGameRestarted += HandleCitizenFinished;
	}

	void HandleCitizenFinished()
	{
		label.text = string.Format("Health: {0}", SpawnManager.HitpointCount);
	}
	
}
