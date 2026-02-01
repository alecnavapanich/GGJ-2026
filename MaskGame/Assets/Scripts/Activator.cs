using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//This file handles the context-dependent actions the player can take.

public class Activator : MonoBehaviour, IDisplaysMask
{
    // List of Activatables in range
    List<IActivatable> activatables = new List<IActivatable>();

    // TODO: Move this into PlayerMovement once that one changes sprites
    [SerializeField] SpriteRenderer maskSR;
    [SerializeField] Sprite maskSpr;
    public void Display(Mask.Type type)
    {
        Sprite spr;
        if (type == Mask.Type.None)
            spr = null;
        else
            spr = maskSpr;
        maskSR.sprite = spr;
    }

    // Call this when the player hits the Activate button
    public void DoActivate(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        int index = GetPriorityIndex();
        if (index >= 0)
            activatables[index].Activate(this.gameObject);
    }

    // Identify which of the Activatables in range has highest priority.
    // Returns -1 if there are no Activatables in range
    private int GetPriorityIndex()
    {
        if (activatables.Count == 0)
            return -1;

        int max = -1;
        int pri;
        List<int> candidates = new List<int>();

        //find all candidates with the highest priority
        for (int ii = 0; ii < activatables.Count; ii++)
        {
            pri = activatables[ii].GetPriority();
            if (pri > max)
            {
                max = pri;
                candidates.Clear();
                candidates.Add(ii);
            }
            else if (pri == max)
            {
                candidates.Add(ii);
            }
        }

        int result = -1;
        float min = float.MaxValue;
        float dist;

        //find the closest candidate by distance
        foreach (int cc in candidates)
        {
            dist = Vector2.Distance(transform.position, activatables[cc].Position());
            if (dist < min)
            {
                result = cc;
                min = dist;
            }
        }

        return result;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IActivatable act = collision.GetComponent<IActivatable>();
        if (act != null)
        {
            activatables.Add(act);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IActivatable act = collision.GetComponent<IActivatable>();
        if (act != null)
        {
            activatables.Remove(act);
        }
    }
}
