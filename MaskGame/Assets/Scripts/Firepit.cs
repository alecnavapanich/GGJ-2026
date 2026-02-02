using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

// Activate this to make the warriors move to this location

public class Firepit : MonoBehaviour, IActivatable
{
    [SerializeField] List<Firepit> linkedPits;
    [SerializeField] GameObject warriorZone; //setpiece including fire particles, permission zone, and NPCs
    [SerializeField] bool on;
    [SerializeField] AudioClip fireLitClip;

    public void Activate(GameObject player)
    {
        if (on)
            return;
        warriorZone.transform.position = this.transform.position;
        foreach (Firepit other in linkedPits)
            other.SetOn(false);
        SetOn(true);
    }

    public void SetOn(bool b)
    {
        SFXManager.instance.playAudioClip(fireLitClip, transform, 1f);
        on = b;
    }

    public int GetPriority()
    {
        return 1;
    }

    public Vector2 Position()
    {
        return transform.position;
    }

    public bool CanInteract()
    {
        return !on;
    }
}
