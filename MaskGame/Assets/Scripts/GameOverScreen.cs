using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void LastRoomButton()
    {
        // Stretch goal -> save progress and reset to last room
        // currently resets the game
        SceneManager.LoadScene("Game");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
