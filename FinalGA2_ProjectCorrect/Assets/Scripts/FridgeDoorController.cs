using UnityEngine;

public class FridgeDoorController : MonoBehaviour
{
    public Animator FridgeDoor;
    bool isInTrigger = false;
    bool isOpen = false;
    public InventoryItem largeFood;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isInTrigger = true;

    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        { 
            isInTrigger = false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        FridgeDoor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInTrigger &&!isOpen)
        {
            if (FridgeDoor)
            {
                Debug.Log("door open");
                FridgeDoor.SetTrigger("openDoor");
                isOpen = true;

                largeFood.canPickup = true;
            }
            else
            {
                Debug.Log("no door!");

            }
        }

        if (Input.GetKeyDown(KeyCode.R) && isInTrigger && isOpen)
        {
            if (FridgeDoor)
            {
                Debug.Log("door close");
                FridgeDoor.SetTrigger("closeDoor");
                isOpen = false;

                largeFood.canPickup = false;
            }
            else
            {
                Debug.Log("no door!");
            }
        }

    }
}
