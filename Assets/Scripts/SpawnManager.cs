using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CitizenGroupData
{
	public int count;
	public float direction;
}

[Serializable]
public class CitizenWaveData
{
	public List <CitizenGroupData> groups;
}

public class SpawnManager : MonoBehaviour 
{
	[SerializeField]
	List <CitizenWaveData> waveDatas = null;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
