using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGkeepPlaying : MonoBehaviour
{

    private static BGkeepPlaying instance = null;
    public static BGkeepPlaying Instance{
        get {return instance; }
    }

    void Awake()
    {
        if(instance != null && instance != this){
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}

