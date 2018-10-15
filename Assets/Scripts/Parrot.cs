using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrot : MonoBehaviour 
{
	const float lifeTime = 20.0f;

    public Transform target;

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

        transform.position = Vector3.MoveTowards(transform.position, target.position,  10 * Time.deltaTime);

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

        Jetpack.instance.fuel += 18f;

        hasDamaged = true;

		SpawnManager.KillCitizen(false);

		citizen.Die();
        SpawnManager.instance.ImpactParrot.Play();
        Destroy(gameObject);

	}
}
