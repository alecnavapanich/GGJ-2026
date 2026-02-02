using UnityEngine;

public class Cart : MonoBehaviour, IActivatable
{
    [SerializeField] AudioClip cartHeldClip;
    [SerializeField] AudioClip cartDroppedClip;
    bool held;

    public void Activate(GameObject player)
    {
        SetHeld(!held, player);
    }

    private void SetHeld(bool b, GameObject holder)
    {
        held = b;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (held)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = Vector3.zero;
            SFXManager.instance.playAudioClip(cartHeldClip, transform, 1f);
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            SFXManager.instance.playAudioClip(cartDroppedClip, transform, 1f);
        }
        Transform parent;
        if (held)
            parent = holder.transform;
        else
            parent = null;
        transform.parent = parent;
    }

    public bool CanInteract()
    {
        return true;
    }

    public int GetPriority()
    {
        return 2;
    }

    public Vector2 Position()
    {
        return transform.position;
    }
}
