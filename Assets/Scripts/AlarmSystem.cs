using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.1F;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        _audioSource.Play();
    }

    private void OnCollisionStay2D(Collision2D collision2D)
    {
        if (_audioSource.volume != 1)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, 0.01F);
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        var off = StartCoroutine(SoundAttenuation());

    }
    private IEnumerator SoundAttenuation()
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();
        while (_audioSource.volume > 0)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume,0, 0.02F);
            yield return waitForFixedUpdate;
        }
        _audioSource.Stop();
    }

    



}
