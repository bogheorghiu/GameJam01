﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    // Use this for initialization
    public Text construct;

    void Awake()
    {
        instance = this;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
