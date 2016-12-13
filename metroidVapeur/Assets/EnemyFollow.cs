using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {

    public enum moveType {UseTransform, UsePhysics};
    public moveType moveTypes;
    public Transform[] pathPoints;
    public int currentPath = 0;
    public float reachDistance = 5f;
    float speed = 5.35f;
    Rigidbody2D rigid;
    public GameObject playerRef;



    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	
        switch(moveTypes)
        {
            case moveType.UseTransform:

                UseTransform();
                break;
            case moveType.UsePhysics:
                UsePhysics();
                break;
        }

	}


    void UseTransform()
    {
        Vector3 dir = pathPoints[currentPath].position - transform.localPosition;
        Vector3 dirNorm= dir.normalized;

        transform.Translate(dirNorm *(speed*Time.fixedDeltaTime));

        if(dir.magnitude <= reachDistance)
        {
            currentPath++;
            SpriteRenderer sprit = GetComponent<SpriteRenderer>();
            
            sprit.flipX = false;
            if (currentPath >= pathPoints.Length)
            {
                sprit.flipX = true;
                currentPath = 0;
            }
        }

    }

    void UsePhysics()
    {
        Vector3 dir = pathPoints[currentPath].position - transform.position;
        Vector3 dirNorm = dir.normalized;

        rigid = GetComponent<Rigidbody2D>();

        rigid.velocity += new Vector2(dirNorm.x * (speed * Time.fixedDeltaTime),rigid.velocity.y);

        if (dir.magnitude <= reachDistance)
        {
            Debug.Log("aaa");
            currentPath++;
            if (currentPath >= pathPoints.Length)
            {
                currentPath = 0;
            }
        }
    }

    void OnDrawGizmos()
    {
        if(pathPoints == null)
        {
            return;
        }

        foreach(Transform pathPoint in pathPoints)
        {
            if(pathPoint)
            {
                Gizmos.DrawSphere(pathPoint.position, reachDistance);
            }
        }
    }

    
}
