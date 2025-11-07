using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

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
    public void Start()
    {
        if (GameController.instance != null)
        {
            ApplyVolumeSettings();
        }
    }

    public void PlayMusic(string nameMusic)
    {
        Sound s = Array.Find(musicSounds, x => x.name == nameMusic);

        if (s == null)
        {
            Debug.LogWarning("Sonido no encontrado" + nameMusic);
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string nameSFX)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == nameSFX);

        if (s == null)
        {
            Debug.LogWarning("sonido no encontrado" + nameSFX);
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlaySFX3D(string nameSFX, Transform followTarget, float maxDistance)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == nameSFX);

        if (s == null)
        {
            Debug.LogWarning("sonido no encontrado" + nameSFX);
            return;
        }

        GameObject followAudioObject = new GameObject("FollowAudio" + nameSFX);
        followAudioObject.transform.position = followTarget.position;

        AudioSource audioSource = followAudioObject.AddComponent<AudioSource>();

        audioSource.clip = s.clip;
        audioSource.spatialBlend = 1f;
        audioSource.maxDistance = maxDistance;
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.Play();

        StartCoroutine(FollowTarget(followAudioObject.transform, followTarget, s.clip.length));
    }
    private IEnumerator FollowTarget(Transform audioTransform, Transform target, float duration)
    {
        float timer = 0f;

        while (timer < duration && target != null)
        {
            audioTransform.position = target.position;
            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(audioTransform.gameObject);
    }
    public void ApplyVolumeSettings()
    {
        if (GameController.instance == null) return;

        musicSource.volume = GameController.instance.musicVolume;
        sfxSource.volume = GameController.instance.sfxVolume;
    }
}
