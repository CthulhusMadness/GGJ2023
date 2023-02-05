using UnityEngine;

public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
            Destroy(this);
        else
        {
            Instance = this as T;
            DontDestroyOnLoad(this);
        }
    }
}
