using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject shot;
	public Transform firePosition;

	float speed = 5.0f;
	float tilt = 5;
	void Start () 
	{
		
	}

	//키 입력 값들을 처리할 때 사용
	void Update()
	{
		if(Input.GetButtonDown("Fire1")== true)
		{
			Instantiate(shot,firePosition.position,firePosition.rotation);
		}
	}

	//물리적인 움직임을 관리
	void FixedUpdate () 
	{
		//int a = 10;
		float dirX=Input.GetAxis("Horizontal");
		float dirY=Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (dirX, 0, dirY);
		// 방향 * 스피드
		GetComponent<Rigidbody> ().velocity = movement * speed;
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0,0,GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
