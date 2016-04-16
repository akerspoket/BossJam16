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
        //RandomiseOil();
        //RandomiseSpeed();
        RandomisePowerStrips();
    }

    private void RandomiseOil()
    {
        for (int i = 0; i < numberOfOils; i++)
        {
            // Set Scale
            float x = Random.value;
            float y = Random.value;
            float z = Random.value;
            GameObject t_oilObject = Instantiate(oilObject);
            float xValue = x * maxObjectSize;
            float yValue = y * maxObjectSize;
            float zValue = z * maxObjectSize;
            if (xValue < minObjectSize)
            {
                xValue = minObjectSize;
            }
            if (yValue < minObjectSize)
            {
                yValue = minObjectSize;
            }
            if (zValue < minObjectSize)
            {
                zValue = minObjectSize;
            }
            t_oilObject.transform.localScale = new Vector3(xValue, 0.02f, zValue);

            // Set position;

            x = Random.value;
            y = Random.value;
            z = Random.value;
            // Y ska vara statisk förmodligen men låter koden va kvar ifall vi vill

            Vector3 scale = spelPlan.transform.localScale;
            scale = new Vector3(scale.x / 2, scale.y / 2, scale.z / 2);
            x = x * scale.x;
            z = z * scale.z;
            y = 0.13f + (0.02f * y);
            if ((x + xValue) > scale.x)
            {
                x = scale.x - xValue;
            }
            if ((z + zValue) > scale.z)
            {
                z = scale.z - zValue;
            }
            for (int j = 0; j < 3; j++)
            {
                float positive = Random.value;
                if (positive < 0.5f)
                {
                    positive = -1.0f;
                }
                else
                {
                    positive = 1.0f;
                }
                if (j == 0)
                {
                    x *= positive;
                }
                else if (j == 2)
                {
                    z *= positive;
                }
            }

            t_oilObject.transform.position = new Vector3(x, y, z);

        }
    }

    private void RandomiseSpeed()
    {
        for (int i = 0; i < numberOfSpeedBoosts; i++)
        {
            // Set Scale
            float x = Random.value;
            float y = Random.value;
            float z = Random.value;
            GameObject t_speedBoostObject = Instantiate(speedBoostObject);
            float xValue = x * maxObjectSize;
            float yValue = y * maxObjectSize;
            float zValue = z * maxObjectSize;
            if (xValue < minObjectSize)
            {
                xValue = minObjectSize;
            }
            if (yValue < minObjectSize)
            {
                yValue = minObjectSize;
            }
            if (zValue < minObjectSize)
            {
                zValue = minObjectSize;
            }
            t_speedBoostObject.transform.localScale = new Vector3(xValue, 0.02f, zValue);

            // Set position;

            x = Random.value;
            y = Random.value;
            z = Random.value;
            // Y ska vara statisk förmodligen men låter koden va kvar ifall vi vill

            y = 0.15f;
            Vector3 scale = spelPlan.transform.localScale;
            Debug.Log(scale);
            scale = new Vector3(scale.x / 2, scale.y / 2, scale.z / 2);
            x = x * scale.x;
            z = z * scale.z;
            y = 0.13f + (0.02f * y);

            if ((x + xValue) > scale.x)
            {
                x = scale.x - xValue;
            }
            if ((z + zValue) > scale.z)
            {
                z = scale.z - zValue;
            }
            for (int j = 0; j < 3; j++)
            {
                float positive = Random.value;
                if (positive < 0.5f)
                {
                    positive = -1.0f;
                }
                else
                {
                    positive = 1.0f;
                }
                if (j == 0)
                {
                    x *= positive;
                }
                else if (j == 2)
                {
                    z *= positive;
                }
            }
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
