using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public int construct_;
    public int construct {
        get { return construct_;  }
        set {
            if (!endgame && GameOverMenu.instance != null)
            {
                construct_ = value;
            UIManager.instance.construct.text =  value + "%";
           
                    GameOverMenu.instance.HandleGameOverConstruct();
                           
            }
        }
    }
    public bool santier;
    public bool parc;
    public float timer = 1;
    private float tm;
    void Awake()
    {
        instance = this;
        construct_ = 30;
    }
    // Use this for initialization
    void Start () {
		
	}

    public bool endgame;

	// Update is called once per frame
	void Update () {

        if (construct == 0)
        {

        }
        if (tm > timer && santier)
        {
            construct += 10;
            tm = 0;
        }
        else
            tm += Time.deltaTime;
	}
}
