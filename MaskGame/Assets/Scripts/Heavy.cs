using UnityEngine;

//This marker handles whether a switch stays turned on.

public class Heavy : MonoBehaviour
{
    private void Awake()
    {
        if (GetComponent<Rigidbody2D>() == null)
            Debug.Log("ERROR: Heavy object without a rigidbody");
    }
}
