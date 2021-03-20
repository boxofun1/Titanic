using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    float time;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("timerUI").GetComponent<Text>().text = "";
        GameObject.Find("userMessageUI").GetComponent<Text>().text = "";
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //print("Time: " + time);
        int seconds = (int) (time % 60);
        int minutes = (int) (time / 60);
        GameObject.Find("timerUI").GetComponent<Text>().text = minutes + ":" + seconds;

        if (time > 118)
		{
            GameObject.Find("userMessageUI").GetComponent<Text>().text = "Time Almost Up.";
        }

        if (time > 120)
		{
            print("TIME UP");
            SceneManager.LoadScene("maze");

		}
    }
}
