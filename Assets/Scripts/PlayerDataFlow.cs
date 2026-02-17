using System.IO;
using UnityEngine;

public class PlayerDataFlow : MonoBehaviour
{
    public static PlayerDataFlow instance;
    public string newPlayerName;
    public string playerName;
    public int score;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
    }

    public void SavePlayerData()
    {
        SavePlayerData data = new SavePlayerData();
        data.playerName = playerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/save-player-file.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/save-player-file.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavePlayerData data = JsonUtility.FromJson<SavePlayerData>(json);

            playerName = data.playerName;
            score = data.score;
        }
    }
}
