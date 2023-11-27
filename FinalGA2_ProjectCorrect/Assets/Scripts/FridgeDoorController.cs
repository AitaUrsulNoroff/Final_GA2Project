using UnityEngine;

public class FridgeDoorController : MonoBehaviour
{
    public Animator FridgeDoor;


    // Start is called before the first frame update
    void Start()
    {
        FridgeDoor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (FridgeDoor)
            {
                Debug.Log("door open");
                FridgeDoor.SetTrigger("openDoor");
            }
            else
            {
                Debug.Log("no door!");

            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (FridgeDoor)
            {
                Debug.Log("door close");
                FridgeDoor.SetTrigger("closeDoor");

            }
            else
            {
                Debug.Log("no door!");
            }
        }

    }
}
