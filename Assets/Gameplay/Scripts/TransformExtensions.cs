using UnityEngine;

public static class TransformExtensions
{
    public static Vector2 GetPosition2D(this Transform transform) => new Vector2(transform.position.x, transform.position.y);
    public static Vector2 GetForward2D(this Transform transform) => Quaternion.Euler(transform.rotation.eulerAngles) * Vector2.up;
}
