using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    public static FPSLimiter instance;

    public int target = 60;
      
    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }
    
    void Update() {
        if(Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }
}
