using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public BulletManager bm;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("fire bullet!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bm.DequeueBullet(ray.origin);
        }
    }
}
