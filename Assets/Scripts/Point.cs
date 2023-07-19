using UnityEngine;

public class Point : MonoBehaviour
{
    public Transform spriteTransform;
    public Transform playerTransform;
    public Vector3 offset;

    private Quaternion defaultRotation; // Default rotation of the sprite

    /// finds the player game transform and makes the rotation equal to the sprite rotation.
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        defaultRotation = spriteTransform.rotation;
    }

    void Update()
    {
        Vector3 targetPosition = playerTransform.position + offset;
        Vector3 direction = targetPosition - spriteTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        spriteTransform.rotation = defaultRotation * Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
