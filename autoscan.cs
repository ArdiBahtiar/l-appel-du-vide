using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoscan : MonoBehaviour
{
    
    void Update()
    {
        AstarPath.active.Scan();
    }
}
