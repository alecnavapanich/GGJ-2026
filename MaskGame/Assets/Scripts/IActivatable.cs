using UnityEngine;

//This is for objects that players can interact with in-game with the action button

public interface IActivatable
{
    public void Activate(GameObject player);
    public int GetPriority(); //higher priority Activatable is the one that gets activated
    public Vector2 Position();
    public bool CanInteract();
}
