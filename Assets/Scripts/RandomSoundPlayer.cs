using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioClip soundClip1;
    public AudioClip soundClip2;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomSound();

    }



    public void PlayRandomSound()
    {
        int randomIndex = Random.Range(0, 2);

        if (randomIndex == 0)
        {
            audioSource.clip = soundClip1;
        }
        else
        {
            audioSource.clip = soundClip2;
        }

        audioSource.Play();
    }
}

