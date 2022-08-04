using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldGenerater : MonoBehaviour
{
    [SerializeField] GameObject _mapobj;
    [SerializeField] GameObject dirtobj;

    bool NextBlock = false;

    float[] verticals = { 0f, 1f };

    private int MapSize;

    // int z, x;

    int SpawnCount = 0;

    void Awake()
    {
        MapSize = MenuSystemsScript.MapSize;
    }

    void Start()
    {
        SpawnBlocks();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void BacktomainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void SpawnBlocks()
    {

        int sqrMapSize = MapSize / 2;

        for (int i = 0; i < MapSize; i++)
        {
            // if (!NextBlock)
            // {
            //     FirstBlock();
            // }
            // else
            // {
            //     SecondBlock();
            // }
            for (int x = -sqrMapSize; x <= sqrMapSize; x++)
            {
                for (int z = -sqrMapSize; z <= sqrMapSize; z++)
                {
                    Vector3 dirtSpawnpos = new Vector3(x, verticals[Random.Range(0, verticals.Length)], z);
                    GameObject spawnedDirt = GameObject.Instantiate(dirtobj, dirtSpawnpos, Quaternion.identity);
                    spawnedDirt.transform.parent = _mapobj.transform;
                }
            }
        }
    }

    // void FirstBlock()
    // {
    //     if (NextBlock) return;

    //     float[] verticals = { -1f, 0f, 1f };

    //     for (x = -10; x <= 10; x++)
    //     {
    //         for (z = -10; z <= 10; z++)
    //         {
    //             Vector3 dirtSpawnpos = new Vector3(x, verticals[Random.Range(0, verticals.Length)], z);
    //             GameObject spawnedDirt = GameObject.Instantiate(dirtobj, dirtSpawnpos, Quaternion.identity);
    //             spawnedDirt.transform.parent = _mapobj.transform;
    //         }
    //     }

    //     NextBlock = false;
    // }

    // void SecondBlock()
    // {
    //     if (!NextBlock) return;

    //     float[] verticals = { -1f, 0f, 1f };

    //     for (x = -10; x <= 10; x++)
    //     {
    //         for (z = -10; z <= 10; z++)
    //         {
    //             Vector3 dirtSpawnpos = new Vector3(x, verticals[Random.Range(0, verticals.Length)], z);
    //             GameObject spawnedDirt = GameObject.Instantiate(dirtobj, dirtSpawnpos, Quaternion.identity);
    //             spawnedDirt.transform.parent = _mapobj.transform;
    //         }
    //     }

    //     NextBlock = true;
    // }
}
