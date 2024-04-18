using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class callFacetime : MonoBehaviour
{
    public TMP_Text titleText;
    public Image personImage;
    public Button acceptButton;
    public Button denyButton;

    public GameObject facetimeWindow;
    public GameObject facetime;

    //public GameObject Camera1;

    public GameObject[] disableWhileFacetiming;

    private string Name;

    // set the title text
    private void Start()
    {
        Name = "Lili is calling";

        // Call the method to set the title text when the script starts
        SetPersonName(Name); 
    }

    public void SetPersonName(string text)
    {
        titleText.text = text;
    }

    // set the person's image
    public void SetPersonImage(Sprite image)
    {
        personImage.sprite = image;
    }

    // accept button click
    public void OnAcceptButtonClick()
    {
        //UnityEngine.Debug.Log("Accept button clicked");

        // Add logic to accept the Facetime call
        //facetime.SetActive(true);
        //Camera1.SetActive(true);


        //disable the facetime popUp
        foreach (GameObject obj in disableWhileFacetiming)
        {
            obj.SetActive(false);
        }

        facetimeWindow.SetActive(false);
    }

    // deny button click
    public void OnDenyButtonClick()
    {
        UnityEngine.Debug.Log("Deny button clicked");

        // Add logic to deny the Facetime call
        facetimeWindow.SetActive(false);

    }
}

