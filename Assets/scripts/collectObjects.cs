using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectObjects : MonoBehaviour
{
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
        if (hit.collider.gameObject.tag == "pick_me")
		{
            string label = hit.collider.gameObject.tag;
            print("Collision with " + label);
            score++;
            if (score >= 4) SceneManager.LoadScene("collide2");
            print("score: " + score);
            Destroy(hit.collider.gameObject);
        }
	}
}
