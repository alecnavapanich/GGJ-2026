using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField] GameObject victoryScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
            return;
        Activator player = collision.GetComponent<Activator>();
        if (player != null)
        {
            victoryScreen.SetActive(true);
            Debug.Log("YOU WIN");
        }
    }
}
