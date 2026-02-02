using UnityEngine;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
            return;
        Activator player = collision.GetComponent<Activator>();
        if (player != null)
        {
            Debug.Log("YOU WIN");
        }
    }
}
