using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    public delegate void PositionUpdateDelegate(Vector3 position);
    public event PositionUpdateDelegate OnPositionUpdate;

    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        //Current position is always the same as the transform position
        //When the current position is not the same as the last recorded last position it updates the current position
        Vector3 currentPosition = transform.position;
        if (currentPosition != lastPosition)
        {
            lastPosition = currentPosition;
            OnPositionUpdate?.Invoke(lastPosition);
        }
    }
}
