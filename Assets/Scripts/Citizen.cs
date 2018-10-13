using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour 
{
	public GameObject Camp = null;

	public Vector3 Direction;

	[SerializeField]
	GameObject signPrefab = null;

	float timer = 0.0f;

	const float cooldown = 2.0f;

	// Use this for initialization
	void Start () 
	{
		SpawnManager.OnGameRestarted += HandleGameRestarted;

		timer = UnityEngine.Random.Range(0.0f, cooldown);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += Direction * Time.deltaTime * 1.0f;

		if(timer > cooldown)
		{
			var signObject = Instantiate(signPrefab);
			signObject.transform.position = transform.position;

			var sign = signObject.GetComponent<Sign>();
			var direction = SpawnManager.Negoita.transform.position - transform.position;
			direction.y = 0.0f;
			direction.Normalize();

			sign.Direction = direction;

			timer = 0.0f;
		}

		timer += Time.deltaTime;
	}

	public void Die()
	{
		SpawnManager.OnGameRestarted -= HandleGameRestarted;

		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider collider)
	{
		var camp = collider.gameObject.GetComponent<PicketCamp>();
		if(camp == null)
			return;

		SpawnManager.KillCitizen(true);

		Die();
	}

	void HandleGameRestarted()
	{
		Die();
	}
}
