using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string nameMusic)
    {
        Sound s = Array.Find(musicSounds, x => x.name == nameMusic);

        if (s == null)
        {
            Debug.LogWarning("Sonido no encontrado");
        }
        else{
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string nameSFX)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == nameSFX);

        if (s == null)
        {
            Debug.LogWarning("sonido no encontrado");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

}
