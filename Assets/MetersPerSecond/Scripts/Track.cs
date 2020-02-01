using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Track : MonoBehaviour
{
    protected abstract void OnObjectEnter(TrackObject obj);

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TrackObject>() is TrackObject obj)
            OnObjectEnter(obj);
    }
}
