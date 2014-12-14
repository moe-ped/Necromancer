using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {

	public Camera camera;

	public Vector2 sensitivity;

	public float distance;
	
	public Vector3 eyePosition;

	public GameObject graphics;

	public Image crosshair;

	// Use this for initialization
	void Start () 
	{
		// lock mouse
		Screen.lockCursor = true;
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// crosshair
		Vector2 mouseMove = new Vector2 (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")).normalized;
		crosshair.rectTransform.right = mouseMove;

		Vector3 relativeEyePosition = eyePosition.x * transform.right + eyePosition.y * transform.up + eyePosition.z * transform.forward;
		// mouse look
		camera.transform.RotateAround (transform.position + relativeEyePosition, camera.transform.right, -Input.GetAxis("Mouse Y") * Time.deltaTime * 10 * sensitivity.y);
		camera.transform.RotateAround (transform.position + relativeEyePosition, Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * 10 * sensitivity.x);
		// follow
		Vector3 distanceVector = camera.transform.position - (transform.position + relativeEyePosition);
		distanceVector.Normalize();
		distanceVector *= distance;
		camera.transform.position = transform.position + relativeEyePosition + distanceVector;
		// look at player
		camera.transform.LookAt (transform.position + relativeEyePosition);
		// move
		// make orthogonal to global y-axis
		rigidbody.AddForce (camera.transform.forward * Input.GetAxis ("Vertical") * Time.deltaTime * 10, ForceMode.VelocityChange);
		rigidbody.AddForce (camera.transform.right * Input.GetAxis ("Horizontal") * Time.deltaTime * 10, ForceMode.VelocityChange);
		// turn char
		Vector3 forwardVector = rigidbody.velocity;
		forwardVector.y = 0;
		graphics.transform.LookAt (graphics.transform.position + forwardVector);
	}
}
