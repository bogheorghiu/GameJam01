using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrot : MonoBehaviour 
{
	const float lifeTime = 2.0f;

	float timer = 0.0f;

	Vector3 direction;

	public Vector3 Direction
	{
		set {direction = value;}
	}

	// Use this for initialization
	void Start () {
				
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		transform.position += direction * 0.1f;

		if(timer > lifeTime)
		{
			Destroy(gameObject);
		}
	}
}
