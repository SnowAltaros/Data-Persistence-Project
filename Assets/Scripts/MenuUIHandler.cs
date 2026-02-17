using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        bestScoreText.text = $"Best Score : {PlayerDataFlow.instance.playerName} : {PlayerDataFlow.instance.score}";
    }

    public void StartNew()
    {
        if (string.IsNullOrEmpty(nameInput.text))
        {
            nameInput.image.color = new Color(1f, 0.388f, 0.278f); // FF6347 in RGB
            Debug.LogWarning("Player name is empty. Please enter a name.");
            return;
        }
        
        nameInput.image.color = Color.white; // Reset to default color
        PlayerDataFlow.instance.newPlayerName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
