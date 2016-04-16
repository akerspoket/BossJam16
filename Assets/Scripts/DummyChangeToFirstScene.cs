using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DummyChangeToFirstScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene("MainMenu");
	}
	
}
