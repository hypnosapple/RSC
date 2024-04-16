using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class FTvideoControl : MonoBehaviour
{
    public VideoClip[] videoclips;
    public GameObject ExploreButtons;

    //Gameobject that carrying RawImage
    public GameObject videoDisplayObject;
    //public GameObject[] exploreButtons;

    private VideoPlayer videoplayer;
    private RawImage rawImage;
    private int videoClipIndex;

    //buttons HERE:
    public GameObject CameraFlipButton;
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject UpButton;
    public GameObject DownButton;

    private void Awake()
    {
        videoplayer = GetComponent<VideoPlayer>();
        rawImage = videoDisplayObject.GetComponent<RawImage>();
    }

    void Start()
    {
        videoplayer.clip = videoclips[0];
       
    }

    void Update()
    {
        // Check if a video clip is playing
        if (videoplayer.isPlaying)
        {
            // Check the index of the currently playing video clip
            videoClipIndex = System.Array.IndexOf(videoclips, videoplayer.clip);

            // Adjust the size of the video display object based on the current video clip
            if (videoClipIndex == 0) 
            {
                videoDisplayObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 1080); // Change the width and height as needed
            }
            else
            {
                // Reset the size of the video display object to its original size
                videoDisplayObject.GetComponent<RectTransform>().sizeDelta = new Vector2(2880, 1620);
            }

            // Enable ExploreButtons if videoClipIndex is 1, otherwise disable it
            if (ExploreButtons != null)
            {
                ExploreButtons.SetActive(videoClipIndex == 1);
            }
        }
    }

    public void CameraFlipClick()
    {
        videoClipIndex++;

        // Set the next video clip to the VideoPlayer
        videoplayer.clip = videoclips[videoClipIndex];

        // Play the video
        videoplayer.Play();

        CameraFlipButton.SetActive(false);
        LeftButton.SetActive(true);
        RightButton.SetActive(true);
        UpButton.SetActive(true);
        DownButton.SetActive(true);
    }

    public void MoveLeft()
    {
        videoDisplayObject.GetComponent<LRUDcontrol>().MoveLeft();
        //foreach (GameObject button in exploreButtons)
        //{
        //    button.GetComponent<LRUDcontrol>().MoveLeft();
        //}
    }

    public void MoveRight()
    {
        videoDisplayObject.GetComponent<LRUDcontrol>().MoveRight();
        //foreach (GameObject button in exploreButtons)
        //{
        //    button.GetComponent<LRUDcontrol>().MoveRight();
        //}
    }

    public void MoveUp()
    {
        videoDisplayObject.GetComponent<LRUDcontrol>().MoveUp();
        //foreach (GameObject button in exploreButtons)
        //{
        //    button.GetComponent<LRUDcontrol>().MoveUp();
        //}
    }

    public void MoveDown()
    {
        videoDisplayObject.GetComponent<LRUDcontrol>().MoveDown();
        //foreach (GameObject button in exploreButtons)
        //{
        //    button.GetComponent<LRUDcontrol>().MoveDown();
        //}
    }
}