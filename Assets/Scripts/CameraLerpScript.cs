using UnityEngine;
using System.Collections;

public class CameraLerpScript : MonoBehaviour {

    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    // Use this for initialization
    void Start () {

    }
	public void OwnStart()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
	// Update is called once per frame
	public void OwnUpdate () {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        GetComponentInChildren<Camera>().transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        GetComponentInChildren<Camera>().transform.rotation = Quaternion.Lerp(startMarker.rotation, endMarker.rotation, fracJourney);
        //transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    }
}
