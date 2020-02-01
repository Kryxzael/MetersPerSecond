using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float Speed = 2f;
    public float Multiplier = 1f;

    private void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime * Multiplier;
    }

    public void SetDirection(Vector2 direction)
        => transform.SetEuler2D(Vector2.up.RealAngleBetween(direction));
}
