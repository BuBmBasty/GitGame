using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class OSTController : MonoBehaviour
{
    [HideInInspector] public UnityEvent<AudioClip, AudioClip> newOstMusic;
    [SerializeField] private AudioClip _start, _loop;
    private AudioSource _audioSource;
    
    #region SingleTone
    private static OSTController _instance;
    public static OSTController Instance => _instance;
    private void Awake()
    {
        if (Instance == null) 
        {
            _instance = this; 
        } 
        else if(Instance == this)
        { 
            Destroy(gameObject); 
        }

        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartOstMusicCoroutine());
    }
    #endregion
    private void Start()
    {
        newOstMusic.AddListener(StartOSTMusic);
    }

    private void StartOSTMusic(AudioClip start, AudioClip loop)
    {
        Debug.Log("call");
        _start = start;
        _loop = loop;
        StartCoroutine(StartOstMusicCoroutine());
    }

    IEnumerator StartOstMusicCoroutine()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _start;
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length);
        _audioSource.loop = true;
        _audioSource.clip = _loop;
        _audioSource.Play();
    }
}
