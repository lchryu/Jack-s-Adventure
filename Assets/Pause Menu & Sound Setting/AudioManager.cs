using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------------------------------ Audio Source ------------------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------------------------------ Audio Clip ------------------------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip jump;
    public AudioClip collect;
    public AudioClip finish;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
