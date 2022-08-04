using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuSystemsScript : MonoBehaviour
{
    public static int MapSize = 0;
    public static float camMoveSpeed;

    [SerializeField] TMP_InputField mapsizeTextfield;
    [SerializeField] TMP_InputField MovespeedInput;

    void Awake()
    {
        MovespeedInput.text = "4";
    }


    public void exectueMapSize()
    {
        try
        {
            MapSize = int.Parse(mapsizeTextfield.text);
        }
        catch (FormatException e)
        {

        }
    }

    public void exectueMoveSpeed()
    {
        try
        {
            camMoveSpeed = float.Parse(MovespeedInput.text);
        }
        catch (FormatException e)
        {

        }
    }

    public void startLevel()
    {
        if (MapSize != 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
