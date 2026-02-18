using UnityEngine.SceneManagement;
using UnityEngine;

public class MainUIHandler : MonoBehaviour
{
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
