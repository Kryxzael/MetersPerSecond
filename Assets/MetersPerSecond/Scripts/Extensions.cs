using System;
using UnityEngine;

public static class Extensions
{
    public static Vector2 ToVector(this MovementDirection dir)
    {
        switch (dir)
        {
            case MovementDirection.Up:
                return Vector2.up;
            case MovementDirection.UpRight:
                return (Vector2.up + Vector2.right).normalized;
            case MovementDirection.Right:
                return Vector2.right;
            case MovementDirection.DownRight:
                return (Vector2.down + Vector2.right).normalized;
            case MovementDirection.Down:
                return Vector2.down;
            case MovementDirection.DownLeft:
                return (Vector2.down + Vector2.left).normalized;
            case MovementDirection.Left:
                return Vector2.left;
            case MovementDirection.UpLeft:
                return (Vector2.up + Vector2.left).normalized;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}