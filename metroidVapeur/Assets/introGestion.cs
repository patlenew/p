﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class introGestion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeScene()
    {
        SceneManager.LoadScene(1);
    }
}
