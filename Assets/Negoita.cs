using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Negoita : MonoBehaviour 
{
    public AudioSource ParrotTrigger;
    public AudioSource Footsteps;
	[SerializeField]
	GameObject parrotPrefab = null;
    public Text NumarPapagali;

	const float speedModifier = 3.5f;
    public float minHeight;
    const float shootCooldown = 5f;
    int CNTpapagal = 14;
	float shootTimer = 0.0f;
    public float timer = 10;
    private float tm;
    // Use this for initialization
    void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
        NumarPapagali.text = CNTpapagal.ToString() + "/20";
		if(Input.GetKey("s"))
		{
			transform.position -= transform.forward * speedModifier * Time.deltaTime;
            if (!Footsteps.isPlaying)
                Footsteps.Play();
            

        }
		else if(Input.GetKey("w"))
		{
			transform.position += transform.forward * speedModifier * Time.deltaTime;
            if (!Footsteps.isPlaying)
                Footsteps.Play();
        }

		if(Input.GetKey("a"))
		{
			transform.position -= transform.right * speedModifier * Time.deltaTime;
            if (!Footsteps.isPlaying)
                Footsteps.Play();
        }
		else if(Input.GetKey("d"))
		{
			transform.position += transform.right * speedModifier * Time.deltaTime;
            if (!Footsteps.isPlaying)
                Footsteps.Play();
        }

        if (!Input.anyKey)
            Footsteps.Stop();

		if(Input.GetMouseButtonDown(0) && shootTimer > shootCooldown && SpawnManager.IsPlaying && CNTpapagal > 0)
		{
          
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Protestatar")
                {
                    Fire(hit.transform);
                }
            }
            --CNTpapagal;
            ParrotTrigger.Play();
		}

        if(transform.position.y <= 1.6)
        {
            if (CNTpapagal < 20 )
            {
                if (tm > timer )
                {
                    CNTpapagal += 1;
                    tm = 0;
                }
                else
                    tm += Time.deltaTime;
            }

        }

		shootTimer += Time.deltaTime;
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Santier")
            GameManager.instance.santier = true;
        Debug.Log("----->");
        if (collider.tag == "Parc");
            GameManager.instance.parc = true;
        Debug.Log("----->");
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag != "Santier")
            GameManager.instance.santier = false;
        Debug.Log("<--------");
        if (collider.tag != "Parc")
            GameManager.instance.parc = false;
        Debug.Log("<--------");
    }

    void Fire(Transform lovit)
	{
        if (transform.position.y > minHeight)
        {
            //var screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            //screenPosition.z = screenPosition.y;
            //screenPosition.y = 0.0f;
            //var mousePosition = new Vector3(Input.mousePosition.x, 0.0f, Input.mousePosition.y);

            //var direction = mousePosition - screenPosition;
            //direction.Normalize();

            var parrotObject = Instantiate(parrotPrefab);

            parrotObject.transform.position = transform.position;

            parrotObject.GetComponent<Parrot>().target = lovit;



            //var parrot = parrotObject.GetComponent<Parrot>();
            //parrot.Direction = direction;
            //shootTimer = 0.0f;
        }
	}
}
