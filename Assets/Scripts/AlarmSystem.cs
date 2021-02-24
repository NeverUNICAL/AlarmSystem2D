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
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        var alarmOn = StartCoroutine(AlarmSystemOn());
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        var alarmOff = StartCoroutine(AlarmSystemOff());
    }

    private IEnumerator AlarmSystemOn()
    {
        _audioSource.volume = 0.1F;
        _audioSource.Play();
        for (int i = 0; i < 5; i++)
        {
            _audioSource.volume += 0.05F ;
            yield return new WaitForSeconds(1F);
        }
    }
    
    private IEnumerator AlarmSystemOff()
    {
        for (int i = 0; i < 10; i++)
        {
            _audioSource.volume -= 0.05F ;
            yield return new WaitForSeconds(0.5F);
        }
        _audioSource.Stop();
    }
    
    
}
