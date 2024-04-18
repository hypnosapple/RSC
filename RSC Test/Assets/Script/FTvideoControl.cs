using System;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class FTVideoControl : MonoBehaviour
{
    public Transform CameraMove;
    public VideoClip[] videoclips;
    public GameObject ExploreButtons;
    public GameObject VPfrontCam;
    public GameObject videoDisplayObject;
    private VideoPlayer videoplayer;
    private RawImage rawImage;
    private int videoClipIndex;

    public VideoZoom videoZoom;
    public GameObject CameraFlipButton;
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject UpButton;
    public GameObject DownButton;

    private void Awake()
    {
        videoplayer = GetComponent<VideoPlayer>();
        rawImage = videoDisplayObject.GetComponent<RawImage>();
        videoZoom = FindObjectOfType<VideoZoom>();
        LRUDControl.CameraMoved += OnCameraMoved;
    }

    void Start()
    {
        videoplayer.clip = videoclips[0];
        videoplayer.Stop();
    }

    void Update()
    {
        if (videoplayer.isPlaying)
        {
            videoClipIndex = Array.IndexOf(videoclips, videoplayer.clip);
            if (ExploreButtons != null)
            {
                ExploreButtons.SetActive(videoClipIndex == 0);
            }
        }
    }

    public void CameraFlipClick()
    {
        VPfrontCam.SetActive(false);
        videoplayer.Play();
        CameraFlipButton.SetActive(false);
        LeftButton.SetActive(true);
        RightButton.SetActive(true);
        UpButton.SetActive(true);
        DownButton.SetActive(true);
    }

    public void MoveLeft()
    {
        videoDisplayObject.GetComponent<LRUDControl>().MoveLeft();
    }

    public void MoveRight()
    {
        videoDisplayObject.GetComponent<LRUDControl>().MoveRight();
    }

    public void MoveUp()
    {
        videoDisplayObject.GetComponent<LRUDControl>().MoveUp();
    }

    public void MoveDown()
    {
        videoDisplayObject.GetComponent<LRUDControl>().MoveDown();
    }

    private void OnCameraMoved(Vector3 newPosition)
    {
        VideoZoom.OnCameraMoved(newPosition);
    }
}
