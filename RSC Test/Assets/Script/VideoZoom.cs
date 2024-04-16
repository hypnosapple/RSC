using UnityEngine;
using System.Collections;

public class VideoZoom : MonoBehaviour
{
    public GameObject objectToZoom;
    private Vector3 originalScale;
    public float zoomDuration = 1.0f;
    public float zoomScale = 2.0f;

    private void Start()
    {
        originalScale = objectToZoom.transform.localScale;
    }

    public void ZoomIn()
    {
        // Calculate the target scale for the zoom-in effect
        Vector3 targetScale = originalScale * zoomScale;

        // Start the zoom-in animation
        StartCoroutine(ZoomCoroutine(targetScale));
    }

    public void ZoomBack()
    {
        StartCoroutine(ZoomCoroutine(originalScale));
    }

    private IEnumerator ZoomCoroutine(Vector3 targetScale)
    {
        Vector3 initialScale = objectToZoom.transform.localScale;
        float elapsedTime = 0.0f;

        while (elapsedTime < zoomDuration)
        {
            objectToZoom.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / zoomDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToZoom.transform.localScale = targetScale; // Ensure final scale is exact
    }
}
