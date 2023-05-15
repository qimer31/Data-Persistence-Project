using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class BestScoreManager : MonoBehaviour
{
    public static BestScoreManager Instance;

    public string BestPlayerName;
    public int BestPlayerScore;
    public string Name;

    public Text BestPlayerText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestPlayer();
        BestPlayerText.text = "Best Score: " + BestPlayerName + " : " + BestPlayerScore;
    }

    [System.Serializable]
    class SaveData
    {
        public string BestPlayerName;
        public string Name;
        public int BestPlayerScore;
    }

    public void SaveBestPlayer()
    {
        SaveData data = new SaveData();
        data.BestPlayerScore = BestPlayerScore;
        data.BestPlayerName = BestPlayerName;
        data.Name = Name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestPlayerScore = data.BestPlayerScore;
            BestPlayerName = data.BestPlayerName;
            Name = data.Name;
        }
    }
}