using UnityEngine;

//This is the logic for a mask that's been left on the ground and can be interacted with.
//This script expects the following scripts to be attached to its gameobject:
//      Mask, SpriteRenderer

public class MaskPickup : MonoBehaviour, IActivatable, IDisplaysMask
{
    [SerializeField] SpriteList maskPickupSprites; //every mask-on-floor sprite in enum order

    // On activation, the player switches their mask with this mask.
    public void Activate(GameObject player)
    {
        //player.GetComponent<Mask>().SwapMasks(this.GetComponent<Mask>());
        //PLAY sound effect
        Debug.Log("YOU DID THE THING");
    }

    // Displays the indicated mask type. If the type is none, this gameobject
    // destroys itself
    public void Display(Mask.Type type)
    {
        if (type == Mask.Type.None)
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = maskPickupSprites.GetSprite((int)type);
        }
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
