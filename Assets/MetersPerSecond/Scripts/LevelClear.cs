using Assets.MetersPerSecond.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LevelClear : MonoBehaviour
{
    public float Predelay;
    public float SlurDelay;
    public float SlurToChordDelay;
    public float PostDelay;

    public bool _clearing;

    public void Clear()
    {
        if (_clearing)
            return;

        StartCoroutine(nameof(CoClear));
    }

    private IEnumerator CoClear()
    {
        _clearing = true;

        IEnumerable<SyncPoint> points = FindObjectsOfType<SyncPoint>().OrderBy(i => i.Id);

        foreach (TrackObject i in FindObjectsOfType<TrackObject>())
            Destroy(i);

        foreach (MovementController i in FindObjectsOfType<MovementController>().Where(i => !i.GetComponent<BackgroundBall>()))
            Destroy(i);

        yield return new WaitForSeconds(Predelay);

        foreach (SyncPoint i in points)
        {
            i.Pulse();
            yield return new WaitForSeconds(SlurDelay);
        }

        yield return new WaitForSeconds(SlurDelay);

        foreach (SyncPoint i in points)
            i.Pulse();

        yield return new WaitForSeconds(PostDelay);

        _clearing = false;
    }
}
