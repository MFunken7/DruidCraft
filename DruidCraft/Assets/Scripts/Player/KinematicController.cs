using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KinematicController : MonoBehaviour
{
	[SerializeField, Range(0, 80)] float speed = 1;
	[SerializeField] GameObject PlayerModel;

	Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{

		Vector3 direction = Vector3.zero;

		direction.x = Input.GetAxis("Horizontal");
		direction.z = Input.GetAxis("Vertical");

		Vector3 force = direction * speed * Time.deltaTime;
		force.y = 0;
		rb.MovePosition(transform.position + force);

		Vector3 rotation = new Vector3(-direction.x, direction.y, -direction.z);

		PlayerModel.transform.rotation = Quaternion.LookRotation(rotation, Vector3.up);

	}
}
