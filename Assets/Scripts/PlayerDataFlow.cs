using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDataFlow : MonoBehaviour
{
    public static PlayerDataFlow instance;
    public List<SavePlayerData> topPlayers = new List<SavePlayerData>();
    public string newPlayerName;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayersData();
    }

    public void AddPlayer(string name, int score)
    {
        SavePlayerData newPlayer = new SavePlayerData();
        newPlayer.playerName = name;
        newPlayer.score = score;

        topPlayers.Sort((x, y) => y.score.CompareTo(x.score));
        
        if (topPlayers.Count < 5)
        {
            topPlayers.Add(newPlayer);
        }
        else
        {
            for (int i = 0; i < topPlayers.Count; i++)
            {
                if (score > topPlayers[i].score)
                {
                    topPlayers.Insert(i, newPlayer);
                    topPlayers.RemoveAt(topPlayers.Count - 1);
                    break;
                }
            }
        }

        topPlayers.Sort((x, y) => y.score.CompareTo(x.score));

        SavePlayersData();
        Debug.Log(Application.persistentDataPath);
    }

    public void SavePlayersData()
    {
        SaveTopPlayersData data = new SaveTopPlayersData();
        data.topPlayers = topPlayers;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/save-player-file.json", json);
    }

    public void LoadPlayersData()
    {
        string path = Application.persistentDataPath + "/save-player-file.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveTopPlayersData data = JsonUtility.FromJson<SaveTopPlayersData>(json);

            topPlayers = data.topPlayers;
        }
    }
}
