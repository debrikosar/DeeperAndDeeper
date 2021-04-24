using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandScriptOfUndestructibleness : MonoBehaviour
{
    private static bool isExisting;

    public void Awake()
    {
        if (isExisting)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        isExisting = true;
    }
}
