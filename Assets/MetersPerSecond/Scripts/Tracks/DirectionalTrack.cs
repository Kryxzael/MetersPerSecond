using UnityEngine;

public class DirectionalTrack : Track
{
    public float RelativeDirection;

    protected override void OnObjectEnter(TrackObject obj)
    {
        obj.transform.position = transform.position;

        obj.MovementController.SetDirection(RotateVector(transform.up, RelativeDirection));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }

    private static Vector2 RotateVector(Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}