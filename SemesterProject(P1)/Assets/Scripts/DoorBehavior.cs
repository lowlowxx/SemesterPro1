using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public bool locked;
    public bool keyPickedUp;


    void Start()
    {
        locked = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key") && keyPickedUp)
        {
            locked = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key") && keyPickedUp)
        {
            locked = true;
        }
    }

}
