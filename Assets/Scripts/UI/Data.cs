using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;

    public int score;
    public string _name;
    public string bestPalyerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
        LoadData();

    }
    [System.Serializable ]
    class SavedData 
    {
        public string name;
        public int score;
    }

    public void SaveData()
    {
        SavedData data = new SavedData();
        data.name = bestPalyerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/BestScore.json", json);   
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/BestScore.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SavedData data = JsonUtility.FromJson<SavedData>(json);

            bestPalyerName = data.name;
            score = data.score;
        }
    }
}
