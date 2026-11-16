using System;
using System.Collections.Generic;

public static class ListExtensions
{
    public static T Random<T>(this IList<T> list)
    {
        if (list == null || list.Count == 0)
            throw new InvalidOperationException("Cannot select a random element from an empty or null list.");

        int index = UnityEngine.Random.Range(0, list.Count);
        return list[index];
    }
}