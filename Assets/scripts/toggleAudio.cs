using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleAudio : MonoBehaviour
{
    bool soundOn;
    // Start is called before the first frame update
    void Start()
    {
        soundOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
		{
            soundOn = !soundOn;
            if (soundOn) gameObject.GetComponent<AudioSource>().Play();
            else gameObject.GetComponent<AudioSource>().Stop();
		}
    }

	private void Awake()
	{
        DontDestroyOnLoad(transform.gameObject);
	}
}
