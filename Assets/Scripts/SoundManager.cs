using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    [SerializeField] private AudioClip[] audioClips;

    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
        audioSource.loop = true;
    }
}
