using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manageMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadMainGame()
	{
        SceneManager.LoadScene("maze");
	}

    public void restartGame()
    {
        SceneManager.LoadScene("startingScene");
    }
}
