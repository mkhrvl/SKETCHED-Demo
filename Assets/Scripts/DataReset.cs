using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataReset : MonoBehaviour
{
    void Start() {
        PlayerPrefs.DeleteAll();
    }
}
