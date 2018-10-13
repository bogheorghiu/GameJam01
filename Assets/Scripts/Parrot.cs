using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrot : MonoBehaviour 
{
	const float lifeTime = 2.0f;

	float timer = 0.0f;

	Vector3 direction;

	bool hasDamaged = false;

	public Vector3 Direction
	{
		set {direction = value;}
	}

	// Use this for initialization
	void Start () 
	{
		hasDamaged = false;			
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		transform.position += direction * 0.2f;

		if(timer > lifeTime)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if(hasDamaged)
			return;

		var citizen = collider.gameObject.GetComponent<Citizen>();
		if(citizen == null)
			return;

		hasDamaged = true;

		SpawnManager.KillCitizen(false);

		Destroy(citizen.gameObject);

		Destroy(gameObject);
	}
}
