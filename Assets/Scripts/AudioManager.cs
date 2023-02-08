using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    public AudioClip gameOver;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[Random.Range(0, playlist.Length)];
        audioSource.Play();
    }
    public void gameEnded()
    {
        audioSource.clip = gameOver;
        audioSource.Play();
    }
}
