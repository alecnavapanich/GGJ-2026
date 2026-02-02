using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        Debug.Log("StartButton called successfully!");
        DontDestroyOnLoad(SFXManager.instance);
        SceneManager.LoadScene("MainScene");
    }

    public void ExitButton()
    {
        Debug.Log("ExitButton called successfully!");
        Application.Quit();
    }
}
