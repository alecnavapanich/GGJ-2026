using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PermissionZone : MonoBehaviour
{
    [SerializeField] List<Mask.Type> allowedMasks;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
            return;
        Activator player = collision.GetComponent<Activator>();
        if (player != null)
            player.EnterZone(this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger)
            return;
        Activator player = collision.GetComponent<Activator>();
        if (player != null)
            player.ExitZone(this);
    }

    public List<Mask.Type> AllowedMasks()
    {
        return allowedMasks;
    }
}
