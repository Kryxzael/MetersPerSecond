using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SwitchTrack : DirectionalTrack
{
    private Glow _glow;
    private SpriteRenderer _rndr;

    public int SwitchTime;

    public bool FlipRight;

    public bool On;

    public Sprite OffSprite;
    public Sprite OnSprite;

    private void Start()
    {
        _glow = GetComponentInChildren<Glow>();
        _rndr = GetComponent<SpriteRenderer>();

        StartCoroutine(nameof(CoSwitchLoop));
    }

    protected override void OnObjectEnter(TrackObject obj) 
        => base.OnObjectEnter(obj);

    public IEnumerator CoSwitchLoop()
    {
        while (true)
        {
            if (On)
                RelativeDirection = FlipRight ? -90 : 90;
            else
                RelativeDirection = 0;

            for (int i = 0; i < SwitchTime; i++)
            {
                if (i >= SwitchTime - 3)
                    _glow.Pulse();

                yield return new WaitForSeconds(1f);
            }

            On = !On;
            _rndr.sprite = On ? OnSprite : OffSprite;
        }
    }
}
