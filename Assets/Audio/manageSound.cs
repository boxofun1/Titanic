using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageSound : MonoBehaviour {



    bool soundIsMuted;
    // Use this for initialization
    void Start()
    {
        soundIsMuted = false;
        GameObject[] bgSounds = GameObject.FindGameObjectsWithTag("bgSound");
        if (bgSounds.Length > 1) Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.M))
        {

            print("Muting sound");
            if (!soundIsMuted) 
            {
                GetComponent<AudioSource>().Stop();
                soundIsMuted = true;
            }
            
            else
            {
                GetComponent<AudioSource>().Play();
                soundIsMuted = false;
            }

        }
		
	}

	private void Awake()
	{
        DontDestroyOnLoad(gameObject.transform);
	}
}
