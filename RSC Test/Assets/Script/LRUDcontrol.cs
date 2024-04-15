using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRUDcontrol : MonoBehaviour
{
    public RectTransform videoDisplayRectTransform; // Reference to the RectTransform component of the video display object
    public float moveDuration = 1.0f; // Duration of the movement in seconds

    public void MoveLeft()
    {
        StartCoroutine(MoveToPosition(new Vector3(videoDisplayRectTransform.localPosition.x - 400f, videoDisplayRectTransform.localPosition.y, videoDisplayRectTransform.localPosition.z)));
    }

    public void MoveRight()
    {
        StartCoroutine(MoveToPosition(new Vector3(videoDisplayRectTransform.localPosition.x + 400f, videoDisplayRectTransform.localPosition.y, videoDisplayRectTransform.localPosition.z)));
    }

    public void MoveUp()
    {
        StartCoroutine(MoveToPosition(new Vector3(videoDisplayRectTransform.localPosition.x, videoDisplayRectTransform.localPosition.y + 200f, videoDisplayRectTransform.localPosition.z)));
    }

    public void MoveDown()
    {
        StartCoroutine(MoveToPosition(new Vector3(videoDisplayRectTransform.localPosition.x, videoDisplayRectTransform.localPosition.y - 200f, videoDisplayRectTransform.localPosition.z)));
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
}
