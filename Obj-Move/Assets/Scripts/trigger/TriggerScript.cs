using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    public GameObject go;
    
    // Start is called before the first frame update
    void Start()
    {
        // Collision 碰撞物体, Collider 碰撞组件
        go = GameObject.Find("Capsule");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //  go = GameObject.Find("Capsule");
        // 每次enter时执行, enter后exit会导致capsule不激活, 使用GameObject.Find("Capsule")获取不到 
        if (go != null)
        {
            // 不激活, 不显示
            go.SetActive(false);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        // go = GameObject.Find("Capsule");
        if (go != null)
        {
            // 激活, 显示
            go.SetActive(true);
        }
        else
        {
            Debug.Log("找不到Capsule");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }
}
