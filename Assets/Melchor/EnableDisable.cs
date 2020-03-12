using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    private bool disabled = false;
    public GameObject objectToDisable;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)){
            objectToDisable.active = !(objectToDisable.active);
        }
    }
}