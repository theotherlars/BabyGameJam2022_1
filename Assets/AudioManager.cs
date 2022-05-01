using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource audioSource;

    public AudioClip music;
    private void Awake() {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        audioSource.clip = music;
        audioSource.Play();
    }
}
