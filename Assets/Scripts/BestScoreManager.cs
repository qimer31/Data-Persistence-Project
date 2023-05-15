using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string BestPlayerName;
    public int BestPlayerScore;

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
    }

    [System.Serializable]
    class SaveData
    {
        public string BestPlayerName;
        public int BestPlayerScore;
    }

    public void SaveBestPlayer()
    {
        SaveData data = new SaveData();
        data.BestPlayerScore = BestPlayerScore;
        data.BestPlayerName = BestPlayerName;

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
        }
    }
}