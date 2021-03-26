using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPlayer : MonoBehaviour
{
    bool isOnGround;
    public Vector3 initialPosition;

    GameObject btPause, btExit, btResume, gamePausedTxt;
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        initialPosition = transform.position;
        gamePausedTxt = GameObject.Find("gamePaused");
        btResume = GameObject.Find("resumeBt");
        btExit = GameObject.Find("exitBt");
        btPause = GameObject.Find("pauseBt");
        displayPauseButtons(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) jump();
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag == "obstacle")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (collision.collider.name == "ground")
            isOnGround = true;
        else
            isOnGround = false;
	}

    void jump()
	{
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400.0f));
        isOnGround = false;
	}

    public void pause()
	{
        paused = true;
        displayPauseButtons(true);

        Time.timeScale = 0;
	}

    void displayPauseButtons(bool state)
	{
        gamePausedTxt.SetActive(state);
        btResume.SetActive(state);
        btExit.SetActive(state);
        btPause.SetActive(!state);
	}

    public void resume()
	{
        Time.timeScale = 1;
        displayPauseButtons(false);
	}
}
