using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] private AudioClip bgMusic;

    public AudioClip hoverButton;
    public AudioClip pressedButton;
    public AudioClip chestOpening;
    public AudioClip popUI;
    public AudioClip keySound;



    private void Start()
    {
        backgroundMusic.clip = bgMusic;
            backgroundMusic.Play();
    }
    public void playSFX(AudioClip whatToPlay) 
    {
        sfx.PlayOneShot(whatToPlay);
    }
}
