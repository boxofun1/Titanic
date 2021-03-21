using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "wordGameStart")
		{
            PlayerPrefs.SetInt("score", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startWordGame()
	{
        SceneManager.LoadScene("wordGame");
	}
}
