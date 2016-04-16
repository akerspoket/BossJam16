using UnityEngine;
using System.Collections;

public class Randomautstuffs : MonoBehaviour {
    public float minObjectSize;
    public float maxObjectSize;
    public int numberOfOils;
    public int numberOfSpeedBoosts;
    public GameObject oilObject;
    public GameObject speedBoostObject;
    public GameObject spelPlan;
    public float density;
    public GameObject powerStrip;
    public float minDistanceBetweenStrips;
    public float maxDistanceBetweenStrips;
    public float firstPossiblePowerStrip;
	// Use this for initialization
	void Start ()
    {
        RandomiseOil();
        RandomiseSpeed();
        RandomisePowerStrips();
    }

    private void RandomiseOil()
    {
        for (int i = 0; i < numberOfOils; i++)
        {
            // Set Scale
            float xScale = Random.Range(minObjectSize, maxObjectSize);
            float yScale = Random.Range(minObjectSize, maxObjectSize);
            float zScale = Random.Range(minObjectSize, maxObjectSize);
            GameObject t_speedBoostObject = Instantiate(oilObject);

            t_speedBoostObject.transform.localScale = new Vector3(xScale, 0.02f, zScale);

            // Set position;
            Vector3 banaStart = spelPlan.transform.position - spelPlan.transform.localScale / 2;
            Vector3 banaEnd = spelPlan.transform.position + spelPlan.transform.localScale / 2;


            float x = Random.Range(banaStart.x, banaEnd.x);
            float y = Random.value;
            float z = Random.Range(banaStart.z + zScale / 2, banaEnd.z - zScale / 2);
            // Y ska vara statisk förmodligen men låter koden va kvar ifall vi vill

            Vector3 scale = spelPlan.transform.localScale;
            //Debug.Log(scale);
            scale = new Vector3(scale.x / 2, scale.y / 2, scale.z / 2);

            y = 0.5f + (0.02f * y);

            t_speedBoostObject.transform.position = new Vector3(x, y, z);

        }
    }

    private void RandomiseSpeed()
    {
        for (int i = 0; i < numberOfSpeedBoosts; i++)
        {
            // Set Scale
            float xScale = Random.Range(minObjectSize, maxObjectSize);
            float yScale = Random.Range(minObjectSize, maxObjectSize);
            float zScale = Random.Range(minObjectSize, maxObjectSize);
            GameObject t_speedBoostObject = Instantiate(speedBoostObject);

            t_speedBoostObject.transform.localScale = new Vector3(xScale, 0.02f, zScale);

            // Set position;
            Vector3 banaStart= spelPlan.transform.position - spelPlan.transform.localScale / 2;
            Vector3 banaEnd = spelPlan.transform.position + spelPlan.transform.localScale / 2;


            float x = Random.Range(banaStart.x, banaEnd.x);
            float y = Random.value;
            float z = Random.Range(banaStart.z + zScale/2, banaEnd.z - zScale/2);
            // Y ska vara statisk förmodligen men låter koden va kvar ifall vi vill
            
            Vector3 scale = spelPlan.transform.localScale;
            scale = new Vector3(scale.x / 2, scale.y / 2, scale.z / 2);

            y = 0.5f + (0.02f * y);

            t_speedBoostObject.transform.position = new Vector3(x, y, z);
        }
    }

    private void RandomisePowerStrips()
    {
        // first is special case
        float banaStartX = spelPlan.transform.position.x - spelPlan.transform.localScale.x / 2;
        float banaEndX = spelPlan.transform.position.x + spelPlan.transform.localScale.x / 2;
        float x = Random.Range(banaStartX + firstPossiblePowerStrip, banaStartX + maxDistanceBetweenStrips);
        if (x > banaEndX)
        {
            return;
        }
        Instantiate(powerStrip, new Vector3(x, 0, 0), Quaternion.identity);

        while (true)
        {
            x = Random.Range(x + minDistanceBetweenStrips, x + maxDistanceBetweenStrips);
            if (x > banaEndX)
            {
                break;
            }
            Instantiate(powerStrip, new Vector3(x, 0, 0), Quaternion.identity);
        }
    }
}
