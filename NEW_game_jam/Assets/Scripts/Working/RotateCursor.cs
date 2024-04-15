using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCursor : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 direction;
    private Camera cam;
    private Rigidbody2D rid;
    
    void Start()
    {
        rid = this.GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }
    
    void Update()
    {
        RotateCamera();
    }

    public void RotateCamera()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Input.mousePosition.z - cam.transform.position.z));
        rid.transform.eulerAngles = new Vector3(0, 0,
            Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg);
    }
}
