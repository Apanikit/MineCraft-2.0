using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    public Camera Cam;
    public float range;

    public GameObject block;
    public float dig_speed;
    static float dig_proggres;

    private Quaternion rot;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
            {
                if (hit.transform.name == "Dirt")
                {
                    dig_speed *= 1;
                }
                else if (hit.transform.name == "Stone")
                {
                    dig_speed *= 5;
                }

                if (dig_proggres == dig_speed)
                {
                    Destroy(hit.collider.gameObject);
                    dig_proggres = 0;
                }
                else
                {
                    dig_proggres++;
                }
            }
            else
            {
                dig_proggres = 0;
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
            {
                for (int i = 0; i < 3; i++)
                {
                    if ((hit.point[i] == hit.transform.position[i] - 1) || (dig_proggres >= dig_speed))
                    {
                        Vector3 pos = hit.transform.position;
                        pos[i] -= 2;
                        Instantiate(block, pos, rot);
                    }

                    if ((hit.point[i] == hit.transform.position[i] + 1) || (dig_proggres >= dig_speed))
                    {
                        Vector3 pos = hit.transform.position;
                        pos[i] += 2;
                        Instantiate(block, pos, rot);
                    }
                }
            }
        }

        /*
        if ((!Input.GetMouseButtonDown(0)) && (!Input.GetMouseButtonDown(1)))
        {
            dig_proggres = 0;
        }
        */
    }
}

   