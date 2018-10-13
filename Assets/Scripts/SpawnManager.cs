using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CitizenGroupData
{
	public int Count;
	public float Direction;
}

[Serializable]
public class CitizenWaveData
{
	public List <CitizenGroupData> Groups;
}

public class SpawnManager : MonoBehaviour 
{
	static SpawnManager instance = null;

	public static event Action OnWaveSpawned;
	public static event Action OnWaveEnded;
	public static event Action OnGameOver;
	public static event Action OnGameRestarted;
	public static event Action OnCitizenFinished;

	[SerializeField]
	List <CitizenWaveData> waveDatas = null;

	[SerializeField]
	GameObject citizenPrefab = null;

	[SerializeField]
	GameObject picketCamp = null;

	[SerializeField]
	List <GameObject> treeBatches = null;

	[SerializeField]
	List <GameObject> houseBatches = null;

	[SerializeField]
	GameObject negoita = null;

	int currentWaveIndex = 0;

	int currentGroupIndex = 0;

	CitizenWaveData currentWave = null;

	int activeCitizenCount = 0;

	int hitpointCount = 10;

	bool isPlaying = false;

	public static bool IsAlive
	{
		get {return instance.hitpointCount > 0;}
	}

	public static bool HasWavesLeft
	{
		get {return instance.currentWaveIndex < instance.waveDatas.Count;}
	}

	public static int HitpointCount
	{
		get {return instance.hitpointCount;}
	}

	public static bool IsPlaying
	{
		get {return instance.isPlaying;}
	}

	public static GameObject Negoita
	{
		get {return instance.negoita;}
	}

	void Awake()
	{
		instance = this;
	}

	public static void SpawnWave()
	{
		instance.isPlaying = true;

		instance.currentGroupIndex = 0;

		instance.currentWave = instance.waveDatas[instance.currentWaveIndex];

		instance.currentWaveIndex++;

		instance.activeCitizenCount = 0;
		for(int i = 0; i < instance.currentWave.Groups.Count; ++i)
		{
			instance.activeCitizenCount += instance.currentWave.Groups[i].Count;
		}
		
		instance.StartCoroutine(instance.LaunchWaveCoroutine());

		if(OnWaveSpawned != null)
		{
			OnWaveSpawned.Invoke();
		}
	}

	public static void KillCitizen(bool hasFinished)
	{
		if(!IsAlive)
			return;

		instance.activeCitizenCount--;

		if(hasFinished)
		{
			instance.hitpointCount--;

			if(OnCitizenFinished != null)
			{
				OnCitizenFinished.Invoke();
			}

			if(instance.hitpointCount == 0)
			{
				instance.isPlaying = false;

				if(OnGameOver != null)
				{
					OnGameOver.Invoke();
				}

				return;
			}
		}

		if(instance.activeCitizenCount == 0)
		{
			instance.isPlaying = false;

			instance.treeBatches[instance.currentWaveIndex - 1].SetActive(false);

			instance.houseBatches[instance.currentWaveIndex - 1].SetActive(true);

			if(OnWaveEnded != null)
			{
				OnWaveEnded.Invoke();
			}

			if(!HasWavesLeft)
			{
				if(OnGameOver != null)
				{
					OnGameOver.Invoke();
				}
			}
		}
	}

	public static void Damage()
	{
		if(!IsAlive)
			return;

		instance.hitpointCount--;

		if(OnCitizenFinished != null)
		{
			OnCitizenFinished.Invoke();
		}

		if(instance.hitpointCount == 0)
		{
			instance.isPlaying = false;

			if(OnGameOver != null)
			{
				OnGameOver.Invoke();
			}
		}
	}

	public static void Restart()
	{
		instance.currentWaveIndex = 0;

		instance.hitpointCount = 10;

		foreach(var batch in instance.treeBatches)
		{
			batch.SetActive(true);
		}

		foreach(var batch in instance.houseBatches)
		{
			batch.SetActive(false);
		}

		if(OnGameRestarted != null)
		{
			OnGameRestarted.Invoke();
		}
	}

	IEnumerator LaunchWaveCoroutine()
	{
		for(int i = 0; i < currentWave.Groups.Count; ++i)
		{
			SpawnGroup();

			yield return new WaitForSeconds(3.0f);
		}
	}

	void SpawnGroup()
	{
		var group = currentWave.Groups[currentGroupIndex];

		float groupAngle = group.Direction;

		var sourcePosition = new Vector3(Mathf.Cos(groupAngle), 0.0f, Mathf.Sin(groupAngle));
		sourcePosition *= 10.0f;

		for(int i = 0; i < group.Count; ++i)
		{
			float angle = UnityEngine.Random.Range(0.0f, 6.2831f);
			float radius = UnityEngine.Random.Range(0.0f, 1.5f);

			var citizenObject = Instantiate(citizenPrefab);
			citizenObject.transform.position = new Vector3(
				sourcePosition.x + Mathf.Cos(angle) * radius, 
				citizenObject.transform.position.y, 
				sourcePosition.z + Mathf.Sin(angle) * radius);

			var citizen = citizenObject.GetComponent<Citizen>();
			citizen.Camp = picketCamp;

			var direction = picketCamp.transform.position - sourcePosition;
			direction.y = 0.0f;
			direction.Normalize();

			citizen.Direction = direction;
		}

		currentGroupIndex++;
	}
}
