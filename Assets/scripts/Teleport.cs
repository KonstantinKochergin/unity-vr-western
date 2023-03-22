using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{

    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer = 0f;

    public int distanceOfRay = 10;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
        }
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if(gvrTimer > totalTime && _hit.transform.CompareTag("Teleport"))
            {
                _hit.transform.gameObject.GetComponent<Move>().TeleportRig();
                gvrStatus = false;
            }
        }


    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVRoff()
    {
        gvrStatus = false;
        gvrTimer = 0f;
    }
}
