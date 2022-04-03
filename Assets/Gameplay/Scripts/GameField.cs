using UnityEngine;

public class GameField : MonoBehaviour
{
    public float FieldMaxY => _fieldMaxHeight;
    public float FieldMinY => -_fieldMaxHeight;
    public float FieldMaxX => _fieldMaxWidth;
    public float FieldMinX => -_fieldMaxWidth;

    [SerializeField] private float _fieldMaxHeight;
    [SerializeField] private float _fieldMaxWidth;

    public Vector2 ClampPosition(Vector2 position)
    {
        position.x = Repeat(position.x, FieldMinX, FieldMaxX);
        position.y = Repeat(position.y, FieldMinY, FieldMaxY);
        return position;
    }

    public bool IsInGameField(Vector2 position)
    {
        if (position.x > FieldMinX && position.x < FieldMaxX)
            if (position.y > FieldMinY && position.y < FieldMaxY)
                return true;

        return false;
    }
    private static float Repeat(float time, float min, float max)
    {
        if (time > max)
            return min;

        return time < min ? max : time;
    }
}
