using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BestScoresUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerDataFlow.instance.topPlayers.Count != 0)
        {
            bestScoreText.text = "Best Score:";
            for (int i = 0; i < PlayerDataFlow.instance.topPlayers.Count; i++)
            {
                bestScoreText.text += $"\n{PlayerDataFlow.instance.topPlayers[i].playerName} : {PlayerDataFlow.instance.topPlayers[i].score}";
            }
        }
        else
        {
            bestScoreText.text = "No Best Score Yet";
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
