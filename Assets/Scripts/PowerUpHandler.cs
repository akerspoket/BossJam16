using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PowerUpHandler : MonoBehaviour {
    int powerUpInt = 0; // 0 = None, 1 = SpeedUp, 2 = SpeedDown, 3 = SpeedRocket, 4 = SlowRocket.
    public float speedUp = 1;
    public float speedDown = 1;
    public GameObject speedRocket;
    public GameObject slowRocket;
    public Image pupDisplay;
    public List<Sprite> powerUpSprites = new List<Sprite>();
    // Use this for initialization
    void Start ()
    {
        SetPowerUp(3);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void SetPowerUp(int p_powerUpId)
    {
        powerUpInt = p_powerUpId;
        pupDisplay.GetComponent<Image>().sprite = powerUpSprites[powerUpInt];
    }
    public void FirePowerUp()
    {
        if(powerUpInt ==0)
        {
            //inte ett smack
        }
        else if(powerUpInt==1)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(speedUp, 0.0f, 0.0f));
            // Speedup
        }
        else if(powerUpInt==2)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-speedDown, 0.0f, 0.0f));
            //SpeedDown
        }
        else if(powerUpInt==3)
        {
            GameObject t_speedRocket = Instantiate(speedRocket);
            t_speedRocket.transform.position = transform.position + (transform.right);
            t_speedRocket.transform.GetComponent<Rigidbody>().AddForce(transform.right);
            t_speedRocket.GetComponent<RocketHitScript>().SetIgnoreTarget(this.gameObject);
            //SpeedRocket
        }
        else if(powerUpInt==4)
        {
            GameObject t_slowRocket = Instantiate(slowRocket);
            t_slowRocket.transform.position = transform.position + (transform.right);
            t_slowRocket.transform.GetComponent<Rigidbody>().AddForce(transform.right);
            t_slowRocket.GetComponent<RocketHitScript>().SetIgnoreTarget(this.gameObject);
            powerUpInt = 0;
            //SlowRocket
        }
        SetPowerUp(0);
    }
}
