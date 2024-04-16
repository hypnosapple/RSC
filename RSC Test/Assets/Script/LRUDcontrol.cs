using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRUDcontrol : MonoBehaviour
{
    public RectTransform videoDisplayRectTransform;
    //public GameObject[] moveButtons;
    public float moveDuration = 1.0f; // Duration of the movement in seconds

    public void MoveLeft()
    {
        StartCoroutine(MoveToPosition(new Vector3(videoDisplayRectTransform.localPosition.x - 400f, videoDisplayRectTransform.localPosition.y, videoDisplayRectTransform.localPosition.z)));
        //foreach (GameObject button in moveButtons)
        //{
        //    StartCoroutine(MoveButtonToPosition(button, new Vector3(button.transform.localPosition.x - 400f, button.transform.localPosition.y, button.transform.localPosition.z)));
        //}
    }

    public void MoveRight()
    {
        StartCoroutine(MoveToPosition(new Vector3(videoDisplayRectTransform.localPosition.x + 400f, videoDisplayRectTransform.localPosition.y, videoDisplayRectTransform.localPosition.z)));
        //foreach (GameObject button in moveButtons)
        //{
        //    StartCoroutine(MoveButtonToPosition(button, new Vector3(button.transform.localPosition.x + 400f, button.transform.localPosition.y, button.transform.localPosition.z)));
        //}
    }

    public void MoveUp()
    {
        StartCoroutine(MoveToPosition(new Vector3(videoDisplayRectTransform.localPosition.x, videoDisplayRectTransform.localPosition.y + 200f, videoDisplayRectTransform.localPosition.z)));
        //foreach (GameObject button in moveButtons)
        //{
        //    StartCoroutine(MoveButtonToPosition(button, new Vector3(button.transform.localPosition.x, button.transform.localPosition.y + 200f, button.transform.localPosition.z)));
        //}
    }

    public void MoveDown()
    {
        StartCoroutine(MoveToPosition(new Vector3(videoDisplayRectTransform.localPosition.x, videoDisplayRectTransform.localPosition.y - 200f, videoDisplayRectTransform.localPosition.z)));
        //foreach (GameObject button in moveButtons)
        //{
        //    StartCoroutine(MoveButtonToPosition(button, new Vector3(button.transform.localPosition.x, button.transform.localPosition.y - 200f, button.transform.localPosition.z)));
        //}
    }


    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0.0f;
        Vector3 startPosition = videoDisplayRectTransform.localPosition;

        while (elapsedTime < moveDuration)
        {
            videoDisplayRectTransform.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        videoDisplayRectTransform.localPosition = targetPosition; // Ensure final position is exact
    }

    //private IEnumerator MoveButtonToPosition(GameObject button, Vector3 targetPosition)
    //{
    //    float elapsedTime = 0.0f;
    //    Vector3 startPosition = button.transform.localPosition;

    //    while (elapsedTime < moveDuration)
    //    {
    //        button.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }

    //    button.transform.localPosition = targetPosition; // Ensure final position is exact
    //}
}