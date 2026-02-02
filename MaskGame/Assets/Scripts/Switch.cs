using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

//These are pressure plate switches that open doors when activated

public class Switch : MonoBehaviour
{
    [SerializeField] List<GameObject> linkedObjects; //these objects disappear when this is pressed
    [SerializeField] Sprite unpressedSprite;
    [SerializeField] Sprite pressedSprite;
    [SerializeField] AudioClip switchOnClip;
    [SerializeField] AudioClip switchOffClip;
    List<Heavy> pressers = new List<Heavy>();
    bool pressed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
            return;
        Heavy h = collision.GetComponent<Heavy>();
        if (collision != null)
        {
            AddPresser(h);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger)
            return;
        Heavy h = collision.GetComponent<Heavy>();
        if (collision != null)
        {
            RemovePresser(h);
        }
    }

    private void AddPresser(Heavy h)
    {
        if (!pressers.Contains(h))
        {
            pressers.Add(h);
            if (pressers.Count == 1)
            {
                SetPressed(true);
            }
        }
    }

    private void RemovePresser(Heavy h)
    {
        if (pressers.Contains(h))
        {
            pressers.Remove(h);
            if (pressers.Count == 0)
                SetPressed(false);
        }
    }

    private void SetPressed(bool b)
    {
        pressed = b;
        Sprite s;
        if (pressed)
        {
        
            SFXManager.instance.playAudioClip(switchOnClip, transform, 1f);
            s = pressedSprite;
        }
        else
        {
        
            SFXManager.instance.playAudioClip(switchOffClip, transform, 1f);
            s = unpressedSprite;
        }
        GetComponent<SpriteRenderer>().sprite = s;
        foreach (GameObject obj in linkedObjects)
        {
            obj.SetActive(!b);
        }
    }
}
