using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using System;

public class Main : MonoBehaviour {

    public GameObject playerRef, loseTxtR, winTxtR;
    public static GameObject loseTxt, winTxt;
    public Transform playerT;
    
    
    public  List<GameObject> doorArrEnter = new List<GameObject>();
    public  List<GameObject> doorArrExit = new List<GameObject>();

    public static List<GameObject> doorArrEnterRef = new List<GameObject>();
    public static List<GameObject> doorArrExitRef = new List<GameObject>();

    // Use this for initialization
    void Start () {
        doorArrEnterRef = doorArrEnter;
        doorArrExitRef = doorArrExit;
        loseTxt = loseTxtR;
        winTxt = winTxtR;
    }
	
	// Update is called once per frame
	void Update () {
        if(playerT != null)
        transform.position = new Vector3(playerT.transform.position.x, playerT.transform.position.y + 3, -10);
	}

    public void receiveWin(bool gagne)
    {
        StartCoroutine(winorlose(gagne));
    }

    

    public IEnumerator winorlose(bool win)
    {
        if (win)
        {
            Main.winTxt.SetActive(true);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(0);
        }
        else
        {
            Main.loseTxt.SetActive(true);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(0);
        }

    }


}
