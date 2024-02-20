using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestioneAudio : MonoBehaviour
{
    public Sound sound;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play(sound.name);
    }

    // Update is called once per frame
    public void FermaAudio()
    {
        AudioManager.instance.Stop(sound.name);
    }

    public void PausaAudio()
    {
        sound.source.volume = 0.4f;
    }

    public void RipresaAudio()
    {
        AudioManager.instance.Play(sound.name);
    }

    public void SoundGameOver()
    {
        AudioManager.instance.Play("GameOver");
    }
}
