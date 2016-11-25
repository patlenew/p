using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    float speed = 5.0f;
    float jumpPower = 200f;
    private string findName = "";
    private bool jumpAble;
   



	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {

        
    }

    private void movePlayer()
    {
    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.gameObject)
        {
            jumpAble = false;
        }

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

        EventCollision2D(col);

    }

    void EventCollision2D(Collider2D col)
    {
        if(EventManager.EventContGet.Contains(col.gameObject))
        {
            Debug.Log("wowowow");
        }
    }

    private bool isName(string name)
    {
        return (name == findName);  
    }
}
