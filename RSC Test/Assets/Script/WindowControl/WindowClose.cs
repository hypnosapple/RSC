using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using UnityEngine;

public class WindowClose : MonoBehaviour
{
    public GameObject[] closeButton;
    public GameObject[] closeWindow;

    //store pairs of buttons and windows
    private Dictionary<GameObject, GameObject> closeButtonToWindowMap;

    void Start()
    {

        closeButtonToWindowMap = new Dictionary<GameObject, GameObject>();

        // pair up buttons and windows 
        for (int i = 0; i < closeButton.Length && i < closeWindow.Length; i++)
        {
            closeButtonToWindowMap.Add(closeButton[i], closeWindow[i]);
        }
    }

    public void ClosePage(GameObject closeButtonClicked)
    {
        // Check if the clicked button exists in the dictionary
        if (closeButtonToWindowMap.ContainsKey(closeButtonClicked))
        {
            // Get the corresponding window for the clicked button
            GameObject windowClose = closeButtonToWindowMap[closeButtonClicked];

            // close the window
            if (windowClose != null)
            {
                windowClose.SetActive(false);
            }
            

        }
    }
}