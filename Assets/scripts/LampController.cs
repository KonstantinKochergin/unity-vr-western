using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{

    private Light[] lightComponents;


    void Start()
    {
        lightComponents = GetComponentsInChildren<Light>();    
    }

    void Update()
    {
        
    }

    public void ToggleLight()
    {
        foreach (var light in lightComponents)
        {
            light.enabled = !light.enabled;
        }
    }
}
