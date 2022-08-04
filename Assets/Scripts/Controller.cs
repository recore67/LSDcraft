using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private float camMoveSpeed;
    public float camRotSpeed;

    float xMouse, yMouse;
    float xMove, zMove;

    bool cursorLocked = true;

    void Awake()
    {
        camMoveSpeed = MenuSystemsScript.camMoveSpeed;
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        CamBasicStuff();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
        }

        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void CamBasicStuff()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        zMove = Input.GetAxisRaw("Vertical");
        float yMove = 0f;

        xMouse += Input.GetAxisRaw("Mouse X") * camRotSpeed;
        yMouse += Input.GetAxisRaw("Mouse Y") * camRotSpeed;

        if (Input.GetKey(KeyCode.E))
        {
            yMove = 1f;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            yMove = -1f;
        }
        else
        {
            yMove = 0f;
        }

        Vector3 MoveVect = (transform.forward * zMove + Vector3.up * yMove + transform.right * xMove) * (camMoveSpeed / 10f);

        Quaternion RotVect = Quaternion.Euler(-yMouse, xMouse, 0f);

        // transform.Translate(MoveVect, Space.Self);
        if (MoveVect.magnitude != 0 || yMove != 0)
        {
            transform.localPosition += MoveVect;
        }
        transform.localRotation = RotVect;
    }
}
