using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour
{
	[SerializeField, Range(0, 40)] float speed = 1;
	
	void Update()
	{

		Vector3 direction = Vector3.zero;

		direction.x = Input.GetAxis("Horizontal");
		direction.z = Input.GetAxis("Vertical");

		Vector3 force = direction * speed * Time.deltaTime;
		force.y = 0;
		transform.localPosition += force;

	}
}
