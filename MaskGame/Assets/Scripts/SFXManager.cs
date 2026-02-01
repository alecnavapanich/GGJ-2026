using UnityEngine;
using UnityEngine.Rendering;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioSource sfxObjectPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void playAudioClip(AudioClip audioClip, Transform spawnTransform, float volume = 1f)
    {

        //spawn gameObject
        AudioSource audioSource = Instantiate(sfxObjectPrefab, spawnTransform.position, Quaternion.identity);

        //assign audioClip & volume
        audioSource.clip = audioClip;
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get length of clip and destroy gameObject after finished
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void playRandomAudioClip(AudioClip[] audioClip, Transform spawnTransform, float volume = 1f)
    {
        int rand = Random.Range(0, audioClip.Length);
        //spawn gameObject
        AudioSource audioSource = Instantiate(sfxObjectPrefab, spawnTransform.position, Quaternion.identity);

        //assign audioClip & volume
        audioSource.clip = audioClip[rand];
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get length of clip and destroy gameObject after finished
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void playGlobal(AudioClip audioClip, float volume = 1f)
    {
        //use camera's position
        playAudioClip(audioClip, Camera.main.transform, volume);
    }
}
