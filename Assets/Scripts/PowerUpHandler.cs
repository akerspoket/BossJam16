using UnityEngine;
using System.Collections;

public class PowerUpHandler : MonoBehaviour {
    int powerUpInt = 0; // 0 = None, 1 = SpeedUp, 2 = SpeedDown, 3 = SpeedRocket, 4 = SlowRocket.
    public float speedUp = 1;
    public float speedDown = 1;
    public GameObject speedRocket;
    public GameObject slowRocket;
    // Use this for initialization
    void Start ()
    {
        powerUpInt = 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void SetPowerUp(int p_powerUpId)
    {
        powerUpInt = p_powerUpId;
    }
    public void FirePowerUp()
    {
        if(powerUpInt ==0)
        {
            //inte ett smack
            powerUpInt = 0;
        }
        else if(powerUpInt==1)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(speedUp, 0.0f, 0.0f));
            powerUpInt = 0;
            // Speedup
        }
        else if(powerUpInt==2)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-speedDown, 0.0f, 0.0f));
            powerUpInt = 0;
            //SpeedDown
        }
        else if(powerUpInt==3)
        {
            GameObject t_speedRocket = Instantiate(speedRocket);
            t_speedRocket.transform.position = transform.position + (transform.forward);
            t_speedRocket.transform.GetComponent<Rigidbody>().AddForce(transform.forward);
            t_speedRocket.GetComponent<RocketHitScript>().SetIgnoreTarget(this.gameObject);
            powerUpInt = 0;
            //SpeedRocket
        }
        else if(powerUpInt==4)
        {
            GameObject t_slowRocket = Instantiate(slowRocket);
            t_slowRocket.transform.position = transform.position + (transform.forward * 5);
            t_slowRocket.transform.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
            powerUpInt = 0;
            //SlowRocket
        }
    }
}
