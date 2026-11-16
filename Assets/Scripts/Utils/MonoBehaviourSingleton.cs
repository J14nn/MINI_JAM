using UnityEngine;

public class MonoBehaviourSingleton<T> : MonoBehaviour where T : Component
{
    protected static T _instance;

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<T>();

                if (_instance == null)
                {
                    GameObject newObj = new GameObject("Auto generated " + typeof(T));
                    _instance = newObj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    public static void Reset()
    {
        _instance = null;
    }
}