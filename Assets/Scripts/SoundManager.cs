using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource[] audioSources;
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        PlayMyAudioClip(0, 0,true);
    }
    
    public void PlayMyAudioClip(int type, int index, bool loopState)
    {
        // PARA ÁUDIO DE BACKGROUND
        if (type == 0)
        {
            audioSources[0].clip = audioClips[index];
            audioSources[0].Play();
            audioSources[0].loop = loopState;
        }
        // PARA ÁUDIO DE SFX
        else if (type == 1)
        {
            audioSources[1].clip = audioClips[index];
            audioSources[1].Play();
            audioSources[1].loop = loopState;
        }
    }
}
