using UnityEngine;
using System.Collections;

public class Rullfan : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody>().AddForce(Vector3.right * 500, ForceMode.Acceleration);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
