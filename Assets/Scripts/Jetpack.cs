using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour
{
    public JetpackFuelBar fuelbar;
    private Rigidbody rb;
    public int maxheight;
    [SerializeField]
    private Vector3 force = new Vector3(0f, 25f, 0f);
    [Tooltip("Max jetpack force")]
    [SerializeField]
    private float maxVerticalSpeed = 100f;
    [Tooltip("Fuel in seconds")]
    [SerializeField]
    private float maxJetpackTime = 0.5f;
    public float fuel = 100f;

    private JetpackFuelBar JetpackBar;

    public static Jetpack instance;

    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        if (GetComponent<JetpackFuelBar>())
            JetpackBar = GetComponent<JetpackFuelBar>();
    }

    private void Update()
    {
        fuelbar.UpdateFuelBar(fuel / 100);
        if (Input.GetMouseButton(1))
        {
            if (fuel > 0f)
            {
                fuel -= 32 * Time.deltaTime;
                if (rb.velocity.y < maxVerticalSpeed)
                    rb.velocity += force * Time.deltaTime;
                else
                    rb.velocity = new Vector3(0f, maxVerticalSpeed,0);

                if (transform.position.y >= maxheight)
                   transform.position = new Vector3(transform.position.x,maxheight,transform.position.z);
            }
        }
        else
        {
            if (fuel <=100f && !GameManager.instance.parc && !GameManager.instance.santier)
            {
                fuel += 15 * Time.deltaTime;
            
            }
            
        }


    }

}



/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour
{

	private Rigidbody rb;

	[SerializeField]
	private Vector3 force = new Vector3(0f, 25f,0f);
	[Tooltip("Max jetpack force")]
	[SerializeField]
	private float maxVerticalSpeed = 3f;
	[Tooltip("Fuel in seconds")]
	[SerializeField]
	private float maxJetpackTime = 1.5f;
	private float jetpackTimeCounter = 0f;

	private JetpackFuelBar JetpackBar;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		if (GetComponent<JetpackFuelBar>())
			JetpackBar = GetComponent<JetpackFuelBar>();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			if (jetpackTimeCounter < maxJetpackTime)
			{
				jetpackTimeCounter += Time.deltaTime;
				if (rb.velocity.y < maxVerticalSpeed)
					rb.velocity += force * Time.deltaTime;
				else
					rb.velocity = new Vector2(0f, maxVerticalSpeed);
			}
		}
		else
		{
			if (jetpackTimeCounter > 0f)
			{
				jetpackTimeCounter -= Time.deltaTime;
			}
			else
				jetpackTimeCounter = 0f;
		}

		if (JetpackBar)
			JetpackBar.UpdateFuelBar(100f - jetpackTimeCounter / maxJetpackTime);

	}

}
*/