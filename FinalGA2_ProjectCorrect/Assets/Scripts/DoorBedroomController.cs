using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBedroomController : MonoBehaviour
{
    public Animator DoorBedroom;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Player"))
        {
            DoorBedroom.SetTrigger("open");
        }

        
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorBedroom.SetTrigger("close");
        }
        
    }
}
