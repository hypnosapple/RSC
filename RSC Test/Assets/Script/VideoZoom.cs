using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class VideoZoom : MonoBehaviour
{
    private bool isZoomingBack = false;

    public GameObject mainCamera;
    private Camera m;
    public float zoomDuration = 1.0f;
    public float transformDuration = 1.0f;
    public float zoomScale;
    private float originalScale = 2.0f;
    public Vector3[] magnifyingGlassLoc;
    private Coroutine zoomCoroutine;
    private Coroutine transformCoroutine;
    private static Vector3 originalCameraPosition;

    //for Info Section
    public int currentIndex;
    public GameObject ObInfo;

    private void OnEnable()
    {
        LRUDControl.CameraMoved += OnCameraMoved;
    }

    private void OnDisable()
    {
        LRUDControl.CameraMoved -= OnCameraMoved;
    }

    public static void OnCameraMoved(Vector3 newPosition)
    {
        originalCameraPosition = newPosition;
    }

    private void Start()
    {
        m = mainCamera.GetComponent<Camera>();
        originalCameraPosition = m.transform.position;
    }

    public void LocateMagnifyPoint(int index)
    {
        currentIndex = index;
        //debug
        UnityEngine.Debug.Log("CurrentIndex value is: " + currentIndex);

        if (zoomCoroutine != null)
            StopCoroutine(zoomCoroutine);

        if (transformCoroutine != null)
            StopCoroutine(transformCoroutine);

        Vector3 targetLocation = magnifyingGlassLoc[index];

        zoomCoroutine = StartCoroutine(ZoomCoroutine(targetLocation, zoomScale));
        transformCoroutine = StartCoroutine(TransformCoroutine(targetLocation));

        ObInfo.SetActive(true);
    }

    public void ZoomIn(float targetScale)
    {
        zoomCoroutine = StartCoroutine(ZoomCoroutine(m.transform.position, targetScale));
    }

    public void ZoomBack()
    {
        ObInfo.SetActive(false);

        if (!isZoomingBack) // Check if zoom back animation is not already in progress
        {
            if (zoomCoroutine != null)
                StopCoroutine(zoomCoroutine);

            if (transformCoroutine != null)
                StopCoroutine(transformCoroutine);

            zoomCoroutine = StartCoroutine(ZoomBackCoroutine(originalScale, originalCameraPosition));
            transformCoroutine = StartCoroutine(TransformBackCoroutine(originalCameraPosition));

            isZoomingBack = true; // Set the flag to indicate that zoom back animation is in progress
        }
    }

    private IEnumerator ZoomCoroutine(Vector3 targetLocation, float targetScale)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < zoomDuration)
        {
            float t = elapsedTime / zoomDuration;

            m.orthographicSize = Mathf.Lerp(originalScale, targetScale, t);
            m.transform.position = Vector3.Lerp(m.transform.position, targetLocation, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        m.orthographicSize = targetScale;
        m.transform.position = targetLocation;
    }

    private IEnumerator TransformCoroutine(Vector3 targetLocation)
    {
        float elapsedTime = 0.0f;
        Vector3 currentLocation = m.transform.position;

        while (elapsedTime < transformDuration)
        {
            float t = elapsedTime / transformDuration;

            m.transform.position = Vector3.Lerp(currentLocation, targetLocation, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        m.transform.position = targetLocation;
    }

    private IEnumerator ZoomBackCoroutine(float targetScale, Vector3 targetLocation)
    {
        float elapsedTime = 0.0f;
        float currentScale = m.orthographicSize;
        Vector3 currentLocation = m.transform.position;

        while (elapsedTime < zoomDuration)
        {
            m.orthographicSize = Mathf.Lerp(currentScale, targetScale, elapsedTime / zoomDuration);
            m.transform.position = Vector3.Lerp(currentLocation, targetLocation, elapsedTime / zoomDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        m.orthographicSize = targetScale;
        m.transform.position = targetLocation;
        isZoomingBack = false;
    }

    private IEnumerator TransformBackCoroutine(Vector3 targetLocation)
    {
        float elapsedTime = 0.0f;
        Vector3 originalPosition = m.transform.position; // Get the current position of the camera

        while (elapsedTime < transformDuration)
        {
            float t = elapsedTime / transformDuration;

            // Interpolate between the current position and the target location
            m.transform.position = Vector3.Lerp(originalPosition, targetLocation, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is exact
        m.transform.position = targetLocation;
    }
}
