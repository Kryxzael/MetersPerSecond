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

    public float MinSize;
    public float MaxSize;

    public float Speed;

    private void Awake()
    {
        _rndr = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(MinSize, MinSize, transform.localScale.z);
    }

    private void Update()
    {
        transform.localScale += new Vector3(Speed * Time.deltaTime, Speed * Time.deltaTime, 0f);

        if (transform.localScale.x > MaxSize)
            transform.localScale = new Vector3(MinSize, MinSize, transform.localScale.z);

        _rndr.color = new Color(1f, 1f, 1f, 1f - ((transform.localScale.x - MinSize) / (MaxSize - MinSize)));
        Debug.Log(_rndr.color.a);
    }
}
