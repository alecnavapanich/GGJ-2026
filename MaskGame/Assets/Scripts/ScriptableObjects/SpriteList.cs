using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteList", menuName = "Scriptable Objects/SpriteList")]
public class SpriteList : ScriptableObject
{
    [SerializeField] List<Sprite> sprites;

    public Sprite GetSprite(int index)
    {
        return sprites[index];
    }
}
