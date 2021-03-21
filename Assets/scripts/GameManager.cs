using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject letter;
    public GameObject cen;

    private string wordToGuess = "";
    private int lengthOfWordToGuess;
    char[] lettersToGuess;
    bool[] lettersGuessed;

    private string[] wordsToGuess = new string[] { "car", "elephant", "autocar" };

    private int nbAttempts, maxNbAttempts;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        nbAttempts = 0;
        maxNbAttempts = 10;
        updateNbAttempts();
        updateScore();
        cen = GameObject.Find("centerOfScreen");
        initGame();
        initLetters();
    }

    // Update is called once per frame
    void Update()
    {
        //checkKeyboard();
        checkKeyBoard2();
    }

    void initLetters()
	{
        int nbletters = lengthOfWordToGuess;
        for (int i = 0; i < nbletters; i++)
		{
            Vector3 newPosition;
            newPosition = new Vector3(cen.transform.position.x + ((i - nbletters / 2.0f) * 100), cen.transform.position.y, cen.transform.position.z);
            GameObject l = (GameObject)Instantiate(letter, newPosition, Quaternion.identity);
            l.name = "letter" + (i + 1);
            l.transform.SetParent(GameObject.Find("Canvas").transform);
		}
	}

    void initGame()
	{
        //wordToGuess = "Elephant";
        int randomNumber = Random.Range(0, wordsToGuess.Length);
        //wordToGuess = wordsToGuess[randomNumber];
        wordToGuess = pickAWordFromFile();

        lengthOfWordToGuess = wordToGuess.Length;
        wordToGuess = wordToGuess.ToUpper();
        lettersToGuess = new char[lengthOfWordToGuess];
        lettersGuessed = new bool[lengthOfWordToGuess];
        lettersToGuess = wordToGuess.ToCharArray();
	}

    void checkKeyboard()
	{
        if (Input.GetKeyDown(KeyCode.A))
		{
            for (int i = 0; i < lengthOfWordToGuess; i++)
			{
                if (!lettersGuessed[i])
				{
                    if (lettersToGuess[i] == 'A')
					{
                        lettersGuessed[i] = true;
                        GameObject.Find("letter" + (i + 1)).GetComponent<Text>().text = "A";
					}
				}
			}
		}
	}

    void checkKeyBoard2()
	{
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0))
		{
            char letterPressed = Input.inputString.ToCharArray()[0];
            int letterPressedAsInt = System.Convert.ToInt32(letterPressed);
            if (letterPressedAsInt >= 97 && letterPressed <= 122)
			{
                nbAttempts++;
                updateNbAttempts();

                if (nbAttempts > maxNbAttempts)
				{
                    SceneManager.LoadScene("wordGameEnd");
				}

                for (int i = 0; i < lengthOfWordToGuess; i++)
				{
                    if (!lettersGuessed[i])
					{
                        letterPressed = System.Char.ToUpper(letterPressed);
                        if (lettersToGuess[i] == letterPressed)
						{
                            lettersGuessed[i] = true;
                            GameObject.Find("letter" + (i + 1)).GetComponent<Text>().text = letterPressed.ToString();

                            score = PlayerPrefs.GetInt("score");
                            score++;
                            PlayerPrefs.SetInt("score", score);
                            updateScore();
                            checkIfWordWasFound();
						}
					}
				}
			}
		}
	}

    void updateNbAttempts()
	{
        GameObject.Find("nbAttempts").GetComponent<Text>().text = nbAttempts + "/" + maxNbAttempts;
	}

    void updateScore()
	{
        GameObject.Find("scoreUI").GetComponent<Text>().text = "Score: " + score;
    }

    void checkIfWordWasFound()
	{
        bool condition = true;

        for (int i = 0; i < lengthOfWordToGuess; i++)
		{
            condition = condition && lettersGuessed[i];
		}

        if (condition)
		{
            PlayerPrefs.SetString("lastWordGuessed", wordToGuess);
            SceneManager.LoadScene("wordGameWin");
		}
	}

    string pickAWordFromFile()
	{
        TextAsset t1 = (TextAsset)Resources.Load("words", typeof(TextAsset));
        string s = t1.text;
        string[] words = s.Split("\n" [0]);
        int randomWord = Random.Range(0, words.Length + 1);
        return (words[randomWord]);
	}
}
