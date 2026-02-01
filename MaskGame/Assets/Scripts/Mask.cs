using UnityEngine;

//This script keeps track of a type of Mask held by another entity

public class Mask : MonoBehaviour
{
    public enum Type
    {
        None,
        Warrior,
        Medic
    }

    [SerializeField] private Type type;

    private void Awake()
    {
        SetMaskType(type);
    }

    public void SwapMasks(Mask other)
    {
        Type newType = other.GetMaskType();
        other.SetMaskType(type);
        SetMaskType(newType);
    }

    public Type GetMaskType()
    {
        return type;
    }
    public void SetMaskType(Type t)
    {
        type = t;
        GetComponent<IDisplaysMask>()?.Display(t);
    }
}
