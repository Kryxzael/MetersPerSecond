using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public float FadeSpeed;

    public AudioClip[] Clips;

    private AudioSource _musicPlayer;
    private bool _fading = false;

    private void Awake()
    {
        _musicPlayer = GetComponent<AudioSource>();
    }

    public void PlaySFX(int index)
    {
        transform.Find("Sound" + index).GetComponent<AudioSource>().Play();
    }

    public void PlayRandomMusic()
    {
        if (_fading)
            return;

        StartCoroutine(nameof(CoFadeAndPlayRandom));
    }

    private IEnumerator CoFadeAndPlayRandom()
    {
        _fading = true;
        _musicPlayer.volume = 1f;

        while (_musicPlayer.volume > 0)
        {
            _musicPlayer.volume -= FadeSpeed;
            yield return new WaitForEndOfFrame();
        }
        _musicPlayer.clip = Clips[Random.Range(0, Clips.Length)];
        _musicPlayer.volume = 1f;
        _musicPlayer.Play();
        _fading = false;
    }

}
