using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject door;

    public bool isPickedUp;
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;

            this.gameObject.SetActive(false);
            Debug.Log("Key picked up!");


            door.GetComponent<BoxCollider2D>().enabled = false;
            door.GetComponent<DoorBehavior>().keyPickedUp = true;
        }
    }
}
