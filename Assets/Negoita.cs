using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Negoita : MonoBehaviour 
{
	[SerializeField]
	GameObject parrotPrefab = null;

	const float speedModifier = 3.5f;

	const float shootCooldown = 1.0f;

	float shootTimer = 0.0f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey("s"))
		{
			transform.position -= transform.forward * speedModifier * Time.deltaTime;
		}
		else if(Input.GetKey("w"))
		{
			transform.position += transform.forward * speedModifier * Time.deltaTime;
		}

		if(Input.GetKey("a"))
		{
			transform.position -= transform.right * speedModifier * Time.deltaTime;
		}
		else if(Input.GetKey("d"))
		{
			transform.position += transform.right * speedModifier * Time.deltaTime;
		}

		if(Input.GetKey("space") && shootTimer > shootCooldown)
		{
			var parrot = Instantiate(parrotPrefab);

			parrot.transform.position = transform.position;

			shootTimer = 0.0f;
		}

		shootTimer += Time.deltaTime;
	}
}
