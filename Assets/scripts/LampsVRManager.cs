using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampsVRManager : MonoBehaviour
{

    public float totalTime = 1.5f;

    private float timer = 0f;

    private bool status = false;

    public int distanceOfRay = 10;
    private RaycastHit _hit;


    void Update()
    {
        if (status)
        {
            timer += Time.deltaTime;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if (timer >= totalTime && _hit.transform.CompareTag("StreetLamp"))
            {
                _hit.transform.gameObject.GetComponent<LampController>().ToggleLight();
                status = false;
                timer = 0f;
            }
        }
    }

    public void StatusOn()
    {
        status = true;
    }

    public void StatusOff()
    {
        status = false;
        timer = 0f;
    }
}
