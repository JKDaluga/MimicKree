using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

        public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
        public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
        public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
        public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
        public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.


    public void playClip(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }
}
