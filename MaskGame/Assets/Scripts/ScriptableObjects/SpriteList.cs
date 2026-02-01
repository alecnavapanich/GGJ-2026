using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteList", menuName = "Scriptable Objects/SpriteList")]
public class SpriteList : ScriptableObject
{
    readonly List<Sprite> sprites;
}
