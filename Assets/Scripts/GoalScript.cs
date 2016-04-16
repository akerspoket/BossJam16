using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    private int counter = 0;
    private int offSetCounter = 0;
    public bool itIsDone = false;
    public float rotationSpeed = 1.0f;
    public float timeToMainMenu;
    private GameObject winner;

    public bool IsItDoneFunc()
    {
        return itIsDone;
    }
    void Update()
    {
        if(itIsDone)
        {
            winner.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, 1*Time.deltaTime*rotationSpeed));
            timeToMainMenu -= Time.deltaTime;
            if (timeToMainMenu < 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("En går i mål!");

            ++counter;
            if (counter == 3)
            {
                itIsDone = true;
                //Debug.Log("Jo fan du vann!");
                GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
                int listLength = list.Length;
                //Debug.Log(listLength);
                for (int i = 0; i < listLength; i++)
                {
                    if (list[i] == other.gameObject)
                    {
                        list[i].gameObject.transform.position = gameObject.transform.FindChild("VictoryScreen").position;
                        list[i].gameObject.transform.position += new Vector3(0.0f, 2.0f, 0.0f);//other.gameObject.transform.position.y+2;
                        list[i].GetComponent<PlayerInput>().StopMoving();
                        list[i].gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
                        
                        winner = other.gameObject;
                    }
                    else
                    {
                        list[i].gameObject.transform.position = gameObject.transform.FindChild("VictoryScreen").position;
                        list[i].gameObject.transform.position += new Vector3(2.0f, 0.0f, -3.0f+offSetCounter*1.5f);//other.gameObject.transform.position.y+2;
                        list[i].GetComponent<PlayerInput>().StopMoving();
                        list[i].gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
                        offSetCounter++;
                    }
                }
            }

        }

    }
}
