using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private Renderer mesh;
    private Camera cam;

    private MeshCollider meshCollider;

    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<Renderer>();
        meshCollider = GetComponent<MeshCollider>();
        cam = Camera.main;
    }

    void Start()
    {

    }

    void Update()
    {
        // WeirdCulling();
    }

    void WeirdCulling()
    {
        float angleCalc = Vector3.Angle(-cam.transform.forward, transform.position);
        if (angleCalc < (cam.fieldOfView / 2f))
        {
            // mesh.forceRenderingOff = true;
        }
        else
        {
            // mesh.forceRenderingOff = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "blockTag")
        {
            Destroy(gameObject);
        }
    }

    // private void OnBecameInvisible()
    // {
    //     mesh.forceRenderingOff = false;
    // }

    // private void OnBecameVisible()
    // {
    //     mesh.forceRenderingOff = true;
    // }
}
