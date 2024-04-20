
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    public ScoreManager scoreManager;
    public WriterStorage storage;

    private AudioSource finishSound;
    private bool levelCompleted = false;


    void Start()
    {
        finishSound = GetComponent<AudioSource>();

        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>(); 
        storage = GameObject.FindObjectOfType<WriterStorage>();


        if (scoreManager == null)
            Debug.LogError("ScoreManager not found!");

        if (storage == null)
            Debug.LogError("WriterStorage not found!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            SaveScore();
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
            
        }
    }

    void SaveScore()
    {
        
        if (!levelCompleted)
        {
            int Temp1 = 3;
            string Temp2 = Temp1.ToString();
            storage.AddNewScore("80");
        }


    }


    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
