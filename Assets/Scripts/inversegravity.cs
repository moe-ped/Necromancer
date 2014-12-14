using UnityEngine;
using System.Collections;

public class inversegravity : MonoBehaviour {

	public float upStrength = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.AddForce (Vector3.up * -Physics.gravity.y * 10 * Time.deltaTime * upStrength);
	}
}
