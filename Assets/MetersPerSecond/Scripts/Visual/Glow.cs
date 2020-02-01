using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Glow : MonoBehaviour
{
    private SpriteRenderer _rndr;
    private bool _running;

    public float MinSize;
    public float MaxSize;

    public float Speed;

    private void Awake()
    {
        _rndr = GetComponent<SpriteRenderer>();
        _rndr.color = default;
        transform.localScale = new Vector3(MinSize, MinSize, transform.localScale.z);
    }

    public void Pulse()
    {
        _rndr.color = new Color(1f, 1f, 1f, MinSize);
        transform.localScale = new Vector3(MinSize, MinSize, transform.localScale.z);
        _running = true;
    }

    private void Update()
    {
        if (!_running)
            return;

        transform.localScale += new Vector3(Speed * Time.deltaTime, Speed * Time.deltaTime, 0f);

        if (transform.localScale.x > MaxSize)
        {
            _running = false;
            return;
        }

        _rndr.color = new Color(1f, 1f, 1f, 1f - ((transform.localScale.x - MinSize) / (MaxSize - MinSize)));
    }
}
