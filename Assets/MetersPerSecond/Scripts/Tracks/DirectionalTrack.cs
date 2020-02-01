using UnityEngine;

public class DirectionalTrack : Track
{
    public Vector2 RelativeDirection;

    protected override void OnObjectEnter(TrackObject obj)
    {
        obj.transform.position = transform.position;
        obj.MovementController.SetDirection((Vector2)transform.up + RelativeDirection);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }
}