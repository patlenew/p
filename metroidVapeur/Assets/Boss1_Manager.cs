using UnityEngine;
using System.Collections;

public class Boss1_Manager : MonoBehaviour {

	[SerializeField]float speedX;
	[SerializeField]float speedY;

	Vector3 startPos;
	[SerializeField]float dephase;
	[SerializeField]float amplitudeX;
	[SerializeField]float amplitudeY;

	public Transform playerT;
	bool attackMode, onAttackCooldown;
	float absPos;
	public GameObject bulletE;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move ();
		ScanAttack ();
	}
	void Move()
	{
		Vector2 position = new Vector2(
			startPos.x + (amplitudeX * Mathf.Sin ( speedX *Time.timeSinceLevelLoad)),
			startPos.y +(amplitudeY * Mathf.Cos ( speedY  * (Time.timeSinceLevelLoad + dephase))));

		transform.position = position;
	}
	void ScanAttack()
	{

		absPos = Mathf.Abs(playerT.transform.position.x - transform.position.x);

		if(absPos < 12)
		{
			attackMode = true;
			if(!onAttackCooldown)
			{
				onAttackCooldown = true;
				Shoot ();
				StartCoroutine(DelayAttack());
			}
		}
		else
		{
			attackMode = false;
		}

	}
	void Shoot()
	{

		GameObject bul = Instantiate(bulletE, transform.position, Quaternion.identity) as GameObject;
		bul.AddComponent<Rigidbody2D>();

		Vector2 AimPosition = playerT.position - transform.position;
		AimPosition = AimPosition.normalized;
		bul.GetComponent<Rigidbody2D>().AddForce(AimPosition * 4000f);

		bul.GetComponent<BulletContainer> ().isEnemyBullet = true;
		//bul.transform.LookAt (playerT);
		Destroy(bul, 2.0f);

	}
	IEnumerator DelayAttack()
	{
		yield return new WaitForSeconds(1f);
		onAttackCooldown = false;

	}
}
