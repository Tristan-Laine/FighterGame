using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    public AudioClip gameOver;
    private int musicIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[Random.Range(0, playlist.Length)];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying){
                PlayNextSong();
        }
    }
 	public void gameEnded()
    {
        audioSource.clip = gameOver;
        audioSource.Play();
    }
	void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
}
