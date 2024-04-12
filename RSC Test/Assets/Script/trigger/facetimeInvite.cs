using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facetimeInvite : MonoBehaviour
{

        // Reference to the window GameObject
        public GameObject Facetime;

        // Method to toggle the window on/off
        public void InviteOn()
        {
            // Toggle the active state of the window
            Facetime.SetActive(true);
        Facetime.transform.SetAsLastSibling();
        }

}
