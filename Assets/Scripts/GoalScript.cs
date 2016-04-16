using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour
{
    private int counter = 0;
    private int offSetCounter = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("En går i mål!");

            ++counter;
            if (counter == 3)
            {
                //Debug.Log("Jo fan du vann!");
                GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
                int listLength = list.Length;
                //Debug.Log(listLength);
                for (int i = 0; i < listLength; i++)
                {
                    if (list[i] == other.gameObject)
                    {
                        other.gameObject.transform.position = gameObject.transform.FindChild("VictoryScreen").position;
                        other.gameObject.transform.position += new Vector3(0.0f, 2.0f, 0.0f);//other.gameObject.transform.position.y+2;
                        other.GetComponent<PlayerInput>().StopMoving();
                    }
                    else
                    {
                        //other.gameObject.transform.position = gameObject.transform.FindChild("VictoryScreen").position;
                        //other.gameObject.transform.position += new Vector3(2.0f+offSetCounter, 0.0f, 0.0f);//other.gameObject.transform.position.y+2;
                        //other.GetComponent<PlayerInput>().StopMoving();
                        //offSetCounter++;
                    }
                }
            }

        }

    }
}
