using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public abstract class TrackObject : MonoBehaviour
{
    public MovementController MovementController { get; private set; }

    protected virtual void Awake()
    {
        MovementController = GetComponent<MovementController>();
    }
}
