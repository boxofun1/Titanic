using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collectObjects_b : MonoBehaviour
{
    bool startDeleteMessage;
    float timer;

    int score;

    int nbPetrolCansCollected;

    GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
        startDeleteMessage = false;
        timer = 0.0f;

        score = 0;

        nbPetrolCansCollected = 0;

        GameObject.Find("userMessageUI").GetComponent<Text>().text = "";

        if (GameObject.Find("plane") != null)
		{
            plane = GameObject.Find("plane");
            plane.SetActive(false);
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (startDeleteMessage)
		{
            timer += Time.deltaTime;

            if (timer >= 2)
			{
                displayMessageToUser("");
                timer = 0.0f;
			}
		}
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "pick_me" || hit.collider.gameObject.tag == "petrol_can" || hit.collider.gameObject.tag == "plane")
        {
            string label = hit.collider.gameObject.tag;
            print("Collision with " + label);
            if (label == "pick_me" || label == "petrol_can")
            {
                score++;
            }

            if (label == "petrol_can")
            {
                nbPetrolCansCollected++;
                displayMessageToUser("Collected " + nbPetrolCansCollected + " can(s)");
                Destroy(hit.collider.gameObject);
            }


			if (label == "pick_me")
			{
				displayMessageToUser("You collected " + score + " box(es)");
				Destroy(hit.collider.gameObject);
			}

			if (score >= 4) SceneManager.LoadScene("outdoor");

			if (label == "plane")
			{
				if (nbPetrolCansCollected < 3)
				{
					displayMessageToUser("Sorry you need 3 cans to fly the plane");
				}
				else
				{
					displayMessageToUser("Well done, you can now fly the plane and leave the island");
					Destroy(GameObject.Find("AircraftJet"));
					plane.SetActive(true);
					plane.transform.position += Vector3.up * 2;
					gameObject.SetActive(false);
				}
			}
		}
    }

    void displayMessageToUser(string messageToDisplay)
	{
        GameObject.Find("userMessageUI").GetComponent<Text>().text = messageToDisplay;
        startDeleteMessage = true;
    }
}
