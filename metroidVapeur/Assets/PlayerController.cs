using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    float speed = 5.0f;
    private string findName = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        movePlayer();
    }

    private void movePlayer()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * 5, 0);


        if (transform.position.y >= 2.5f)
        {
            transform.position = new Vector3(transform.position.x, 2.5f, 0);
        }
        else
        {
            transform.position += move * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(Main.doorArrEnterRef.Contains(col.gameObject))
        {
            findName = col.gameObject.ToString();
            int index = Main.doorArrEnterRef.IndexOf(col.gameObject);
            transform.position = new Vector3(Main.doorArrExitRef[index].transform.position.x + 1.5f, Main.doorArrExitRef[index].transform.position.y + 1.5f, 0);
        }
        else if(Main.doorArrExitRef.Contains(col.gameObject))
        {
            findName = col.gameObject.ToString();
            int index = Main.doorArrExitRef.IndexOf(col.gameObject);
            transform.position = new Vector3(Main.doorArrEnterRef[index].transform.position.x - 1.5f, Main.doorArrEnterRef[index].transform.position.y + 1.5f, 0);
        }
    }

    private bool isName(string name)
    {
        return (name == findName);  
    }
}
