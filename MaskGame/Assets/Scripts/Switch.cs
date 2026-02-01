using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

//These are pressure plate switches that open doors when activated

public class Switch : MonoBehaviour
{
    [SerializeField] List<GameObject> linkedObjects; //these objects disappear when this is pressed
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
        //TODO: change sprite?
        //PLAY sound effect
        foreach (GameObject obj in linkedObjects)
        {
            obj.SetActive(!b);
        }
    }
}
