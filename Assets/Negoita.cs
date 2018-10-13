using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Negoita : MonoBehaviour 
{
	[SerializeField]
	GameObject parrotPrefab = null;

	const float speedModifier = 3.5f;

	const float shootCooldown = 0.5f;

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
			Fire();
		}

		shootTimer += Time.deltaTime;
	}

	void Fire()
	{
		var screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		screenPosition.z = screenPosition.y;
		screenPosition.y = 0.0f;
		var mousePosition = new Vector3(Input.mousePosition.x, 0.0f, Input.mousePosition.y);

		var direction = mousePosition - screenPosition;
		direction.Normalize();

		var parrotObject = Instantiate(parrotPrefab);

		parrotObject.transform.position = transform.position;

		var parrot = parrotObject.GetComponent<Parrot>();
		parrot.Direction = direction;

		shootTimer = 0.0f;
	}
}
