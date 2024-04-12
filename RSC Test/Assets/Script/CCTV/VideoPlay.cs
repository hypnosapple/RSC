using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    public VideoClip[] videoclips;
    private VideoPlayer videoplayer;
    private int videoClipIndex;

    private void Awake()
    {
        videoplayer = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        videoplayer.clip = videoclips[0];
    }


    public void playNext()
    {
        
        if (videoClipIndex >= videoclips.Length)
        {
            videoClipIndex = videoClipIndex % videoclips.Length;
        }
        videoClipIndex++;
        videoplayer.clip = videoclips[videoClipIndex];
        
    }


    public void playBack()
    {
        
        if (videoClipIndex >= videoclips.Length)
        {
            videoClipIndex = videoClipIndex % videoclips.Length;
        }
        videoClipIndex--;
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
