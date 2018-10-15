using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour 
{
	public GameObject Camp = null;

	public Vector3 Direction;

    public AudioSource ImpactParrot;
    [SerializeField]
	GameObject signPrefab = null;

	float timer = 0.0f;

	const float cooldown = 5.0f;

	// Use this for initialization
	void Start () 
	{
		SpawnManager.OnGameRestarted += HandleGameRestarted;

		timer = UnityEngine.Random.Range(0.0f, cooldown);
        walking = true;
	}
    public bool walking = true;
    public bool allowtoshot = false;
	// Update is called once per frame
	void Update () 
	{
        if (walking)
        {
            transform.position += Direction * Time.deltaTime * 1.0f;
        }
        if (allowtoshot == false)
            return;
		if(timer > cooldown)
		{
			var signObject = Instantiate(signPrefab);
            GameManager.instance.construct--;
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
	 if(collider.tag != "Santier")
			return;
        allowtoshot = true;
        walking = false;
        
    }

	void HandleGameRestarted()
	{
		Die();
	}
}
