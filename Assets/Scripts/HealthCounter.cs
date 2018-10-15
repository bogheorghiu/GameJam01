using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour 
{
	[SerializeField]
	Text label = null;

    public int complete = 20;
	// Use this for initialization
	void Start () 
	{
		SpawnManager.OnCitizenFinished += HandleCitizenFinished;

		SpawnManager.OnGameRestarted += HandleCitizenFinished;
	}
    void Update()
    {
            while(complete < 100)
            {
            complete += 5;
            }    
    }
    void HandleCitizenFinished()
	{
	}
	
}
