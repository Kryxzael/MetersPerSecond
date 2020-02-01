using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// No... Not that type of time zone
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class TimeZone : MonoBehaviour
{
    private SpriteRenderer _rndr;
    private Collider2D _collider;

    public int TimeScaleIndex;

    public TimescalePreset TimeScale
    {
        get => TimeScales[TimeScaleIndex];
    }

    public TimescalePreset[] TimeScales;

    private void Awake()
    {
        if (!TimeScales.Any())
        {
            Debug.LogWarning("Time Zone did not have any time scale instances and self destructed");
            Destroy(this);
        }

        _rndr = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        ApplyTimeScale(0);
    }

    private void OnMouseDown()
    {
        ApplyTimeScale((TimeScaleIndex + 1) % TimeScales.Length);
    }

    public void ApplyTimeScale(int index)
    {
        TimeScaleIndex = index;
        _rndr.color = TimeScale.Color;

        //Resets the OnTriggerEnter2D function
        _collider.enabled = false;
        _collider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MovementController>() is MovementController obj)
        {
            obj.Multiplier = TimeScale.TimeScale;
        }
    }
}
