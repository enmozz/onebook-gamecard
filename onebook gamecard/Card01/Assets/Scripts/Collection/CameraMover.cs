using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    public void MoveCameraUp()
    {
        if (transform.position.y != 0)
            transform.position = new Vector3(transform.position.x, transform.position.y + 4.5f, transform.position.z);
    }

    public void MoveCameraDown()
    {
        if (transform.position.y != -27)
            transform.position = new Vector3(transform.position.x, transform.position.y - 4.5f, transform.position.z);
    }

    public void page1()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }

    public void page2()
    {
        transform.position = new Vector3(transform.position.x, -4.5f, transform.position.z);
    }
    public void page3()
    {
        transform.position = new Vector3(transform.position.x, -9f, transform.position.z);
    }
    public void page4()
    {
        transform.position = new Vector3(transform.position.x, -13.5f, transform.position.z);
    }
    public void page5()
    {
        transform.position = new Vector3(transform.position.x, -18f, transform.position.z);
    }
    public void page6()
    {
        transform.position = new Vector3(transform.position.x, -22.5f, transform.position.z);
    }
    public void page7()
    {
        transform.position = new Vector3(transform.position.x, -27f, transform.position.z);
    }
}
