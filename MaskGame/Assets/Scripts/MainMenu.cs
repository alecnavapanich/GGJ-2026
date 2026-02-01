using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        Debug.Log("StartButton called successfully!");
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        Debug.Log("ExitButton called successfully!");
        Application.Quit();
    }
}
