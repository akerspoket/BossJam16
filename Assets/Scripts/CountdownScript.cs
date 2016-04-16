using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour {
    public float countdownTime = 3;
    public float goDisaparesIn = 1;
    public List<Sprite> countdownTextures = new List<Sprite>();
    public Image imageDisplay;

    private int imageToDisplay;
    private float secondsPerImage;
    // Use this for initialization
    void Start () {
        secondsPerImage = countdownTime / (countdownTextures.Count - 1);
        imageToDisplay = countdownTextures.Count;

    }
	
	// Update is called once per frame
	void Update () {
        countdownTime -= Time.deltaTime;
        imageToDisplay = Mathf.Max(-1, (int)Mathf.Floor(countdownTime / secondsPerImage)) + 1;
        if (countdownTime < 0)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < players.GetLength(0); i++)
            {
                players[i].GetComponent<PlayerInput>().StartMoving();
                players[i].GetComponent<CapsuleCollider>().enabled = true;
            }
        }
        imageDisplay.sprite = countdownTextures[imageToDisplay];
        if (countdownTime< -goDisaparesIn)
        {
            imageDisplay.enabled = false;
            this.enabled = false;
        }
	}
}
