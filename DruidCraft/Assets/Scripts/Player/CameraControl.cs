using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField, Range(10, 20)] int MaxHeight = 15;
    [SerializeField, Range(50, 70)] int MaxRotation = 60;
	[SerializeField] Camera camera1;

	float rotationAngle = -2;

	void Update()
	{
		if(Input.mouseScrollDelta.y != 0)
		{
			Zoom(Input.mouseScrollDelta.y);
		}

	}

	private void Zoom(float zoomValue)
	{
		Vector3 zoom = Vector3.zero;

		zoom.y = -zoomValue;

		zoom.z = -zoomValue;

		camera1.transform.localPosition += zoom;

		float cameraY = camera1.transform.localPosition.y;
		float cameraZ = camera1.transform.localPosition.z;

		cameraY = Mathf.Clamp(cameraY, 10, MaxHeight);
		
		cameraZ = Mathf.Clamp(cameraZ, -5, -3);

		Vector3 finalPosition = new Vector3(camera1.transform.localPosition.x, cameraY, cameraZ);

		camera1.transform.localPosition = finalPosition;

		float currentRotation = camera1.transform.localRotation.eulerAngles.x;

		float newRotation = currentRotation + (rotationAngle * zoomValue);

		newRotation = Mathf.Clamp(newRotation, 50, MaxRotation);

		Quaternion rotation = Quaternion.Euler(newRotation, 0, 0);


		camera1.transform.localRotation = rotation;




	}
}
