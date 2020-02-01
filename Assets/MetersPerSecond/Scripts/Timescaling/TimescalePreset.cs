using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Time Scale", menuName = "Time Scale")]
public class TimescalePreset : ScriptableObject
{
    public float TimeScale;
    public Color Color;
}
