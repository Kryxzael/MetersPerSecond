using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void PlaySFX(int index)
    {
        transform.Find("Sound" + index).GetComponent<AudioSource>().Play();
    }
}
