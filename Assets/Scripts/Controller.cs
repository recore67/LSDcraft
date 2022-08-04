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

    private Camera cam;

    void Awake()
    {
        camMoveSpeed = MenuSystemsScript.camMoveSpeed;
        cam = Camera.main;
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        // CamBasicStuff();
    }

    void Update()
    {
        CamBasicStuff();

        // badCulling();

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

        yMouse = Mathf.Clamp(yMouse, -90, 90);

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

        Vector3 MoveVect = (transform.forward * zMove + Vector3.up * yMove + transform.right * xMove).normalized * (camMoveSpeed / 10f) * Time.fixedDeltaTime;

        Quaternion RotVect = Quaternion.Euler(-yMouse, xMouse, 0f).normalized;

        // transform.Translate(MoveVect, Space.Self);
        if (MoveVect.magnitude != 0 || yMove != 0)
        {
            transform.localPosition += MoveVect;
        }
        transform.localRotation = RotVect;
    }

    void badCulling()
    {
        foreach(GameObject i in GameObject.FindGameObjectsWithTag("blockTag"))
        {
            Vector3 screenPoint = cam.WorldToViewportPoint(i.transform.position);
            bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        }
    }
}
