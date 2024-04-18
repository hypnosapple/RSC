using System;
using System.Collections;
using UnityEngine;

public class LRUDControl : MonoBehaviour
{
    public Transform CameraMove;
    public float moveDuration = 1.0f; // Duration of the movement in seconds

    public static event Action<Vector3> CameraMoved;

    public void MoveLeft()
    {
        StartCoroutine(MoveToPosition(new Vector3(CameraMove.localPosition.x + 1f, CameraMove.localPosition.y, CameraMove.localPosition.z)));
    }

    public void MoveRight()
    {
        StartCoroutine(MoveToPosition(new Vector3(CameraMove.localPosition.x - 1f, CameraMove.localPosition.y, CameraMove.localPosition.z)));
    }

    public void MoveUp()
    {
        StartCoroutine(MoveToPosition(new Vector3(CameraMove.localPosition.x, CameraMove.localPosition.y - 0.5f, CameraMove.localPosition.z)));
    }

    public void MoveDown()
    {
        StartCoroutine(MoveToPosition(new Vector3(CameraMove.localPosition.x, CameraMove.localPosition.y + 0.5f, CameraMove.localPosition.z)));
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0.0f;
        Vector3 startPosition = CameraMove.localPosition;

        while (elapsedTime < moveDuration)
        {
            CameraMove.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        CameraMove.localPosition = targetPosition; // Ensure final position is exact
        NotifyCameraMoved(targetPosition);
    }

    private void NotifyCameraMoved(Vector3 newPosition)
    {
        CameraMoved?.Invoke(newPosition);
    }
}
