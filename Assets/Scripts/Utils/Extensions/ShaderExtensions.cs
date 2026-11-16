using UnityEngine;

public static class ShaderExtensions
{
    public static void Dispatch(this ComputeShader shader, int kernelIndex, Vector3Int threadGroups)
    {
        shader.Dispatch(kernelIndex, threadGroups.x, threadGroups.y, threadGroups.z);
    }

    public static void SetFloat2(this ComputeShader shader, string name, Vector2 value)
    {
        shader.SetFloats(name, new float[] { value.x, value.y });
    }

    public static void SetFloat2(this ComputeShader shader, string name, float val1, float val2)
    {
        shader.SetFloats(name, new float[] { val1, val2 });
    }

    public static void SetInt2(this ComputeShader shader, string name, Vector2Int value)
    {
        shader.SetInts(name, new int[] { value.x, value.y });
    }
}