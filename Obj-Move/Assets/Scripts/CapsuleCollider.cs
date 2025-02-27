using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // 当碰撞开始时触发
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("碰撞开始：" + collision.gameObject.name);
    
        // 检查碰撞对象的标签
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("撞到了敌人！");
        }
    }

    // 当碰撞持续时触发
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("碰撞持续：" + collision.gameObject.name);
    }

    // 当碰撞结束时触发
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("碰撞结束：" + collision.gameObject.name);
    }
}
