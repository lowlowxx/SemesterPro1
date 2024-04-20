using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WriterStorage : MonoBehaviour
{
    public TMP_InputField NewName;
    public int num_scores = 5;
    public TMP_InputField NewScore;

    public string nameofFile;

    public void AddNewScore(string score)
    {
        string path = "Assets/" + "Level1Scores" + ".txt";
        string line;
        string[] fields;
        int scores_written = 0;
        string newName = "don't forget to input";
        string newScore = "999";
        bool newScoreWritten = false;
        string[] writeNames = new string[5];
        string[] writeScores = new string[5];

        newScore = score;

        if (newScore.GetType() == typeof(string))
        {
            Debug.Log("First object is a string.");
            Debug.Log("String content: " + newScore);
        }
        else
        {
            Debug.Log("The object is not a string.");
        }


        if (PlayerPrefs.GetString("PlayerName") == "")
        {
            newName = "enterName";
        }
        else
        {
            newName = PlayerPrefs.GetString("PlayerName");
        }

        //newName = "Glenn";
        //newScore = "200";

        if (newScore.GetType() == typeof(string))
        {
            Debug.Log("Second object is a string.");
            Debug.Log("String content: " + newScore);
        }
        else
        {
            Debug.Log("The object is not a string.");
        }


        print(newName);
        print(newScore);

        // you need to have at least one record (name, score) for this to work.
        // if there is no record at all,  the code  below will report an index out of bounds.
        // you can fix this with the code at https://www.techiedelight.com/check-if-file-is-empty-csharp/

        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            fields = line.Split(',');
            if (!newScoreWritten && scores_written < num_scores) // if new score has not been written yet
            {
                //check if we need to write new higher score first
                if (Convert.ToInt32(newScore) > Convert.ToInt32(fields[1]))
                {
                    writeNames[scores_written] = newName;
                    writeScores[scores_written] = newScore;
                    newScoreWritten = true;
                    scores_written += 1;
                }

            }
            if (scores_written < num_scores) // we have not written enough lines yet
            {
                writeNames[scores_written] = fields[0];
                writeScores[scores_written] = fields[1];
                scores_written += 1;
            }
        }
        reader.Close();

        // now we have parallel arrays with names and scores to write
        StreamWriter writer = new StreamWriter(path);

        for (int x = 0; x < scores_written; x++)
        {
            writer.WriteLine(writeNames[x] + ',' + writeScores[x]);
        }
        writer.Close();

        // AssetDatabase.ImportAsset(path);
        //TextAsset asset = (TextAsset)Resources.Load("scores");

    }
}