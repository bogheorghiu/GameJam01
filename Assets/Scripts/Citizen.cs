using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour 
{
	public GameObject Camp = null;

	public Vector3 Direction;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += Direction * Time.deltaTime * 2.2f;
	}

	void OnTriggerEnter(Collider collider)
	{
		var camp = collider.gameObject.GetComponent<PicketCamp>();
		if(camp == null)
			return;

		SpawnManager.KillCitizen(true);

		Destroy(gameObject);
	}
}
