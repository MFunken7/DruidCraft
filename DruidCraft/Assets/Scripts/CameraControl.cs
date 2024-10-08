using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField, Range(10, 20)] int MaxHeight = 15;
    [SerializeField, Range(50, 70)] int MaxRotation = 60;
	[SerializeField] Camera camera;

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

		camera.transform.localPosition += zoom;

		float cameraY = camera.transform.localPosition.y;

		cameraY = Mathf.Clamp(cameraY, 10, MaxHeight);

		Vector3 finalPosition = new Vector3(camera.transform.localPosition.x, cameraY, camera.transform.localPosition.z);

		camera.transform.localPosition = finalPosition;

		float currentRotation = camera.transform.localRotation.eulerAngles.x;

		float newRotation = currentRotation + (rotationAngle * zoomValue);

		newRotation = Mathf.Clamp(newRotation, 50, MaxRotation);

		Quaternion rotation = Quaternion.Euler(newRotation, 0, 0);


		camera.transform.localRotation = rotation;




	}
}
