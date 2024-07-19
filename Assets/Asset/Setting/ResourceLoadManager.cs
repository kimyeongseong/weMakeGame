using UnityEngine;
using System.Collections.Generic;

public class ResourceLoadManager : MonoBehaviour
{
    private Dictionary<string, Object> resourceCache = new Dictionary<string, Object>();

    public T LoadResource<T>(string path) where T : Object
    {
        if (resourceCache.ContainsKey(path))
        {
            return resourceCache[path] as T;
        }

        T resource = Resources.Load<T>(path);
        if (resource != null)
        {
            resourceCache[path] = resource;
        }
        else
        {
            Debug.LogError("Failed to load resource at path: " + path);
        }

        return resource;
    }
}
