using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WorldGenerater : MonoBehaviour
{
    [SerializeField] GameObject _mapobj;
    [SerializeField] GameObject dirtobj;
    [SerializeField] TMP_Text fpsText;

    bool NextBlock = false;

    float[] verticals = { 0f, 1f };
    float[] verticalChange;

    private int MapSize;

    private int i;

    // int z, x;

    int SpawnCount = 0;

    float verticalInc;

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
        // SpawnBlocks();

        ShowFps();
    }

    void ShowFps()
    {
        float currentFps = 1f / Time.deltaTime;
        fpsText.text = currentFps.ToString();
    }

    public void BacktomainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void SpawnBlocks()
    {

        int sqrMapSize = MapSize * 10;

        verticalChange = new float[] { verticals[Random.Range(0, verticals.Length)], verticals[Random.Range(0, verticals.Length)] + 1f };

        for (i = 0; i <= MapSize; i++)
        {
            // if (!NextBlock)
            // {
            //     FirstBlock();
            // }
            // else
            // {
            //     FirstBlock();
            //     verticalInc++;
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

    //     int sqrMapSize = MapSize * 10;

    //     if (i < MapSize)
    //     {
    //         for (int x = -sqrMapSize; x <= sqrMapSize; x++)
    //         {
    //             for (int z = -sqrMapSize; z <= sqrMapSize; z++)
    //             {
    //                 Vector3 dirtSpawnpos = new Vector3(x, verticalInc, z);
    //                 GameObject spawnedDirt = GameObject.Instantiate(dirtobj, dirtSpawnpos, Quaternion.identity);
    //                 spawnedDirt.transform.parent = _mapobj.transform;
    //             }
    //         }
    //     }

    //     NextBlock = false;
    // }

    // void SecondBlock()
    // {
    //     if (!NextBlock) return;

    //     int sqrMapSize = MapSize * 10;

    //     if (i < MapSize)
    //     {
    //         for (int x = -sqrMapSize; x <= sqrMapSize; x++)
    //         {
    //             for (int z = -sqrMapSize; z <= sqrMapSize; z++)
    //             {
    //                 Vector3 dirtSpawnpos = new Vector3(x, verticalInc, z);
    //                 GameObject spawnedDirt = GameObject.Instantiate(dirtobj, dirtSpawnpos, Quaternion.identity);
    //                 spawnedDirt.transform.parent = _mapobj.transform;
    //             }
    //         }
    //     }

    //     NextBlock = true;
    // }
}
