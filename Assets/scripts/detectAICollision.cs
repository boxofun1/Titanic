using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class detectAICollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision hit)
	{
		if (hit.collider.gameObject.tag == "Player")
		{
            print("Reloading the scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
