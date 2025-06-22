using UnityEngine;

public abstract class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static readonly object lockObject = new object();
    private static bool isQuitting = false;

    public static T Instance
    {
        get
        {
            if (isQuitting) return null;

            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = FindAnyObjectByType<T>();
                    
                    if (instance == null)
                    {
                        GameObject singleton = new GameObject(typeof(T).Name);
                        instance = singleton.AddComponent<T>();
                        DontDestroyOnLoad(singleton);
                    }
                }
                return instance;
            }
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnApplicationQuit()
    {
        isQuitting = true;
    }
}

public class Singleton<T> where T : class, new()
{
    private static T instance;
    private static readonly object lockObject = new object();

    public static T Instance
    {
        get
        {
            lock (lockObject)
            {
                return instance ??= new T();
            }
        }
    }

    protected Singleton() { }
}