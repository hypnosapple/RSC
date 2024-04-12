using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using UnityEngine;

public class WindowOpen : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] windows;

    //store pairs of buttons and windows
    private Dictionary<GameObject, GameObject> buttonToWindowMap;

    void Start()
    {
        
        buttonToWindowMap = new Dictionary<GameObject, GameObject>();

        // Populate the dictionary with button-window pairs
        for (int i = 0; i < buttons.Length && i < windows.Length; i++)
        {
            buttonToWindowMap.Add(buttons[i], windows[i]);
        }
    }

    public void OpenPage(GameObject buttonClicked)
    {
        // Check if the clicked button exists in the dictionary
        if (buttonToWindowMap.ContainsKey(buttonClicked))
        {
            // Get the corresponding window for the clicked button
            GameObject windowToToggle = buttonToWindowMap[buttonClicked];

            // Toggle the window
            windowToToggle.SetActive(!windowToToggle.activeSelf);

            // Put the window on top
            windowToToggle.transform.SetAsLastSibling();
        }
    }
}