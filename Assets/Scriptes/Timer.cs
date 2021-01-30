using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeOfTheFlash;
    private float timeOfTheMusic;
    public int lenOfTabPause;
    public int[] pauseTab;
    private int pauseNbr = 0;

    private float startTime;
    public AudioSource ambientAudio;
    public AudioSource flashaudio;

    public bool flash = false;
    public bool end = false;
    public int timeAfterEnd = 3;
        
    private void Start()
    {
        int inpleNewTab = 0;
        timeOfTheFlash = flashaudio.clip.length;
        timeOfTheMusic = ambientAudio.clip.length;
        flash = false;
        ambientAudio.Play();

        startTime = Time.time;
        if (lenOfTabPause == 0) {
            lenOfTabPause = Random.Range((int)(timeOfTheMusic * 0.12f), (int)(timeOfTheMusic * 0.05f));
            pauseTab = new int[lenOfTabPause];
            pauseTab[0] = 0;
            for (int i = 1; i < lenOfTabPause; i++) {
                inpleNewTab = inpleNewTab + (int)timeOfTheFlash + ((int)timeOfTheMusic / lenOfTabPause);
                pauseTab[i] = Random.Range(inpleNewTab, inpleNewTab + ((int)timeOfTheMusic / lenOfTabPause));
            }
        }
    }

    void Paly()
    {
        ambientAudio.UnPause();
    }

    void Pause()
    {
        ambientAudio.Pause();
        flashaudio.Play();
    }

    void MusicSwitch(float time)
    {

    }
    void Update()
    {
        float time = Time.time - startTime;

        if (time > ambientAudio.clip.length + timeAfterEnd)
            end = true;
        if (lenOfTabPause > pauseNbr) {
            if (time >= pauseTab[pauseNbr] && time <= pauseTab[pauseNbr] + timeOfTheFlash && flash == false) {
                flash = true;
                Pause();
            }
            if (time > pauseTab[pauseNbr] + timeOfTheFlash) {
                flash = false;
                Paly();
                pauseNbr++;
                startTime += timeOfTheFlash;
            }
        }
    }
}
