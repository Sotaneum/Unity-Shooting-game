using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public float delay=2;
	public Transform firePosition;
	void Start () {
		InvokeRepeating ("Fire",1,delay);
	}

	void Fire()
	{
		Instantiate (shot,firePosition.position,firePosition.rotation);
	}
}
