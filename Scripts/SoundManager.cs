using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource = null;
    public AudioClip healAudio = null;
    public AudioClip bombDetonate = null;
    public AudioClip takeAmmoAudio = null;
    public AudioClip takeBombAudio = null;
    public AudioClip openDoorAudio = null;
    public AudioClip takeKeyAudio = null;
    public AudioClip playerDeath = null;
    public AudioClip enemyDeath = null;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
