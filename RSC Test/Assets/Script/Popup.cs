using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Popup : MonoBehaviour
{
    //in inspector
    public TMP_Text Title, Content;

    private GameObject window;
    private Animator popup;

    private Queue<string> popupQueue;
    private Coroutine queueChecker;
    private string titletext;
    private string messagetext;

    private void Start()
    {
        window = transform.GetChild(0).gameObject;
        popup = window.GetComponent<Animator>();
        window.SetActive(false);
        popupQueue = new Queue<string>();

        //customize text HERE: 
        titletext = "mom";
        messagetext = "hi";
    }

    public void AddToQueue(string text)
    {
        popupQueue.Enqueue(text);
        if (queueChecker == null)
            queueChecker = StartCoroutine(CheckQueue());
    }
    public void DisplayText()
    {
        Title.text = titletext;
        Content.text = messagetext;
    }

    private void ShowPopup(string text)
    {
        window.SetActive(true);
        Title.text = text;
        popup.Play("PopupAnimation");
    }


    private IEnumerator CheckQueue()
    {
        do
        {
            ShowPopup(popupQueue.Dequeue());
            
            do
            {
                yield return null;
            } while (!popup.GetCurrentAnimatorStateInfo(0).IsTag("Idle"));
        } while (popupQueue.Count > 0);

        window.SetActive(false);
        queueChecker = null;
    }


}

