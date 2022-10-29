using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
     public static MainManager Instance;

 //VARIABLES FOR CURRENT SESSION
    public string playerName;
    public int currentScore;
    
    //VARIABLES FOR HIGH SCORE SESSION
    
    public int highScore;
    public string highScoreName;

private void Awake()
{
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    // end of new code

    Instance = this;
    DontDestroyOnLoad(gameObject);

     LoadHighScore();
}

 //DATA PERSISTANCE ACROSS SCENES PART
    [System.Serializable]
    public class SaveData
    {
        public int highScore;
        public string highScoreName;

    }

    public void SaveHighScore(int currentScore, string playerName)
    {
        //create a new instance of the save data 
        SaveData data = new SaveData();

        //specify what to store
        data.highScore = currentScore;
        data.highScoreName = playerName;

        //transform that instance to JSON with JsonUtility.ToJson: 
        string json = JsonUtility.ToJson(data);

        //Finally, use the special method File.WriteAllText to write a string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }
}
