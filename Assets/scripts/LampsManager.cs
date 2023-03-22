using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampsManager : MonoBehaviour
{

    private List<LampController> lampsControllers = new List<LampController>();

    void Start()
    {
        GameObject[] lampsGameObjects = GameObject.FindGameObjectsWithTag("StreetLamp");
        foreach (var lampGO in lampsGameObjects) {
            lampsControllers.Add(lampGO.GetComponent<LampController>());
        }
    }

    public void ToggleLamps()
    {
        foreach (var lampController in lampsControllers)
        {
            lampController.ToggleLight();
        }
    }
}
