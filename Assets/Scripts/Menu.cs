﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void PlayAgain()
    {
        Application.LoadLevel(1);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
