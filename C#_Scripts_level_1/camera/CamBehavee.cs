using UnityEngine;
using System.Collections;

public class CamBehavee : MonoBehaviour {
	private const float Y_ANGLE_MIN = 0.0f;
	private const float Y_ANGLE_MAX = 50.0f;

	//private Vector3 firstpoint;
	//private Vector3 secondpoint;

	public Transform lookAt;
	public Transform camTransform;

	private Camera cam;

	public float distance;
	public float height;
	private float currentX = 0.0f;
	private float currentY = 0.0f;
	public float senseX=14.0f;
	public float senseY=10.0f;
	public VirtualJoystick camerastick;
	private Touch screentouch;


	private void Start()
	{

		camTransform = transform;
		cam = Camera.main;


	}

	private void Update()
	{
		if (Input.touchCount > 0) {
			if (Input.touchCount==1 && Input.GetTouch(0).phase == TouchPhase.Moved) {
				screentouch = Input.GetTouch (0);
				currentX += screentouch.deltaPosition.x * senseX * 1.0f;
				currentY -= screentouch.deltaPosition.y * senseY * 1.0f;
		
			}
		}

		currentY = Mathf.Clamp (currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
	}

	private void LateUpdate()
	{
		Vector3 dir = new Vector3 (0,height,-distance);
		Quaternion rotation = Quaternion.Euler (180,currentX,0);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt (lookAt.position);
	}

}

