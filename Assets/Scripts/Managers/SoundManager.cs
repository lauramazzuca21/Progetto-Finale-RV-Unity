using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.CorrectRecycling += PlayCorrectRecycling;
        EventManager.WrongRecycling += PlayWrongRecycling;

        audioSource = GetComponent<AudioSource>();
    }

    void PlayCorrectRecycling(RecyclableObject.ObjID ID)
    {
        Play(Constants.Clips[Enums.AudioClips.CORRECT]);
    }
    void PlayWrongRecycling()
    {
        Play(Constants.Clips[Enums.AudioClips.WRONG]);
    }

    void Play(string audioclip)
    {
        foreach (AudioClip audio in sounds)
        {
            if (audio.name == audioclip)
            {
                audioSource.clip = audio;
                audioSource.Play();
                return;
            }
        }
    }
}
