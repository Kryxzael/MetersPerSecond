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
    {
        if (direction.normalized == Vector2.up)
            transform.SetEuler2D(0);
        if (direction.normalized == Vector2.down)
            transform.SetEuler2D(180);
        if (direction.normalized == Vector2.right)
            transform.SetEuler2D(-90);
        if (direction.normalized == Vector2.left)
            transform.SetEuler2D(-270);

    }
}
