using UnityEngine;

public static class VectorExtenstions
{
    public static Vector2Int ToVector2Int(this Vector2 vector2)
    {
        return new Vector2Int(Mathf.RoundToInt(vector2.x), Mathf.RoundToInt(vector2.y));
    }

    public static Vector3Int ToVector3Int(this Vector2 vector2)
    {
        return new Vector3Int(Mathf.RoundToInt(vector2.x), Mathf.RoundToInt(vector2.y));
    }

    public static Vector2 Floor(this Vector2 value)
    {
        return new Vector2(Mathf.FloorToInt(value.x), Mathf.FloorToInt(value.y));
    }

    public static Vector2Int FloorToInt(this Vector2 value)
    {
        return new Vector2Int(Mathf.FloorToInt(value.x), Mathf.FloorToInt(value.y));
    }
}