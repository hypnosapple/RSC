using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    public VideoClip[] videoclips;
    private VideoPlayer videoplayer;
    private int videoClipIndex;
    private int maxVideoClipIndex;

    private void Awake()
    {
        videoplayer = GetComponent<VideoPlayer>();
        maxVideoClipIndex = videoclips.Length - 1;
    }

    void Start()
    {
        videoplayer.clip = videoclips[0];
    }


    public void playNext()
    {
        videoClipIndex++;

        if (videoClipIndex > maxVideoClipIndex)
        {
            videoClipIndex = 0;
        }
        
        videoplayer.clip = videoclips[videoClipIndex];
        
    }


    public void playBack()
    {

        videoClipIndex--; 

        // If index goes below zero, wrap around to the last video clip
        if (videoClipIndex < 0)
        {
            videoClipIndex = maxVideoClipIndex;
        }

        // Set the video clip to be played
        videoplayer.clip = videoclips[videoClipIndex];

    }


    public void playPause()
    {
        if (videoplayer.isPlaying)
        {
            videoplayer.Pause();
        }
        else
        {
            videoplayer.Play();
        }
    }
}
