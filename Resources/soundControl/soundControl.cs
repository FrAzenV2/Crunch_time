using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundControl : MonoBehaviour
{
    public GameObject childSound;
    public GameObject childMusic;
    public AudioClip[] soundClip;
    AudioSource sound;
    AudioSource music;
    void Start()
    {
        sound = childSound.GetComponent<AudioSource>();
        music = childMusic.GetComponent<AudioSource>();
        music.Play();
        soundClip = new AudioClip[9];
    }

    public void MusicPlay(){
        music.Play();
    }

    public void MusicStop(){
        music.Stop();
    }

    public void SoundPlay(int audioID){
        sound.clip = soundClip[audioID];
        sound.Play();
    }
}
