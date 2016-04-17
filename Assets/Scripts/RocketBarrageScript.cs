using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RocketBarrageScript : MonoBehaviour {
    public Transform StartPosition;
    public Transform EndPosition;
    public List<GameObject> rockets = new List<GameObject>(); 
    public int NumberOfRockets = 5;
    public float FireAfterXSeconds = 20;
    private Vector3 stepLength;
	// Use this for initialization
	void Start () {
        Vector3 direction = StartPosition.position - EndPosition.position;
        direction.Normalize();
        stepLength = direction * Vector3.Distance(StartPosition.position, EndPosition.position) / (NumberOfRockets - 1);
	}
	
	// Update is called once per frame
	void Update () {
        FireAfterXSeconds -= Time.deltaTime;
        if (FireAfterXSeconds < 0)
        {
            // Fire all rockets!!
            for (int i = 0; i < NumberOfRockets; i++)
            {
                int rocketToFire = (i + 1) % rockets.Count;
                Instantiate(rockets[rocketToFire], StartPosition.position - stepLength * i, Quaternion.identity);
            }
            Destroy(this);
        }
	}
}
