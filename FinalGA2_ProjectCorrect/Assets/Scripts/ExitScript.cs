using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
    public Image panelExit;
    public GameObject exitButton, descriptions;
    bool isCursorIsLocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ExitGame()
    {
        Debug.Log("EXIT GAME");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ToggleCursorLockMode()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;

            isCursorIsLocked = false;

        }

        else
        {
            isCursorIsLocked = true;

            Cursor.lockState = CursorLockMode.Locked;


        }
    }

    void LateUpdate()
    {
        if (isCursorIsLocked)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            panelExit.enabled = !panelExit.enabled;
            exitButton.SetActive(panelExit.enabled);
            descriptions.SetActive(panelExit.enabled);


            ToggleCursorLockMode();

        }
    }
}
