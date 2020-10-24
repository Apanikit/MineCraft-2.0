using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int testSize;
    public GameObject blocks;

    private float seed_ofsetX;
    private float seed_ofsetZ;

    public float freq;
    public float amp;

    void Start()
    {
        seed_ofsetX = Random.Range(0f, 9999f);
        seed_ofsetZ = Random.Range(0f, 9999f);

        for (int x = -testSize / 2; x < testSize / 2; x++)
        {
            for (int z = -testSize / 2; z < testSize / 2; z++)
            {
                float y = Mathf.PerlinNoise(x / freq + seed_ofsetX, z / freq + seed_ofsetZ) * amp;
                y = Mathf.Floor(y);

                if (y % 2 == 1)
                {
                    y -= 1;
                }

                Vector3 pos = new Vector3(x * 2, y, z * 2);
                Quaternion rot = new Quaternion(0, 0, 0, 0);
                Instantiate(blocks, pos, rot);
            }
        }
    }

    void Update()
    {
        /*
        for (int x = -testSize / 2; x < testSize / 2; x++)
        {
            for (int z = -testSize / 2; z < testSize / 2; z++)
            {
                int y = (int)Mathf.PerlinNoise(x + seed_ofsetX, z + seed_ofsetZ);
                Vector3 pos = new Vector3(x, y, z);
                Quaternion rot = new Quaternion(0, 0, 0, 0);
                Instantiate(blocks, pos, rot);
            }
        }
        */
    }
}
