using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateObjects : MonoBehaviour
{
    public GameObject obstacle;
    float timer;
    float score;

    float cloudTimer;
    public GameObject cloud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        manageTimer();
        score += Time.deltaTime;
        displayScore();
        createClouds();
    }

    void manageTimer()
	{
        timer += Time.deltaTime;
        if (timer >= 2)
		{
            addObstacle();
            timer = 0;
		}
	}

    void addObstacle()
	{
        Vector3 postionOfPlayer = GameObject.Find("player").GetComponent<ControlPlayer>().initialPosition + Vector3.down * .3f;
        float randomNumber = Random.Range(1, 5);
        GameObject t1, t2, t3, t4;
        t1 = (GameObject)GameObject.Instantiate(obstacle, postionOfPlayer + Vector3.right * 20, Quaternion.identity);
        if (randomNumber > 1) t2 = (GameObject)GameObject.Instantiate(obstacle, postionOfPlayer + Vector3.right * 21, Quaternion.identity);
        if (randomNumber > 2) t3 = (GameObject)GameObject.Instantiate(obstacle, postionOfPlayer + Vector3.right * 22, Quaternion.identity);
        if (randomNumber > 3) t4 = (GameObject)GameObject.Instantiate(obstacle, postionOfPlayer + Vector3.right * 20, Quaternion.identity);
    }

    void displayScore()
	{
        GameObject.Find("scoreUI").GetComponent<Text>().text = "" + (int)score;
	}

    void createClouds()
	{
        cloudTimer += Time.deltaTime;
        GameObject cloud1;
        Vector3 topRightCorner = GameObject.Find("topRightCorner").transform.position;
        int altitude = Random.Range(0, 2);
        if (cloudTimer >= 10)
		{
            cloud1 = (GameObject)GameObject.Instantiate(cloud, topRightCorner + -Vector3.up * altitude, Quaternion.identity);
            cloudTimer = 0;
		}
	}
}
