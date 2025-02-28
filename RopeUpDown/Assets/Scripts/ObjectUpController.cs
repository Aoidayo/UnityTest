using UnityEngine;

public class ObjectUpController : MonoBehaviour
{
    public float moveSpeed = 180000.0f; // 物体A的上升速度
    public Transform objectB; // 物体B的引用
    private bool isMoving = true; // 控制物体是否可以移动

    // void Update()
    // {
    //     // 获取物体A的当前位置
    //     Vector3 currentPosition = transform.position;
    //
    //     // 计算物体A的新位置
    //     float newY = currentPosition.y + riseSpeed * Time.deltaTime;
    //
    //     // 限制物体A的上升高度
    //     // newY = Mathf.Clamp(newY, -Mathf.Infinity, -1f);
    //     if (newY <= -10f)
    //     {
    //         // 更新物体A的位置
    //         transform.position = new Vector3(currentPosition.x, newY, currentPosition.z);
    //         // 计算物体B的新位置
    //         float bNewY = objectB.position.y - riseSpeed * Time.deltaTime;
    //         // 移动B
    //         objectB.position = new Vector3(objectB.position.x, bNewY, objectB.position.z);
    //     }
    //     else
    //     {
    //         Debug.Log("到达最大高度.");
    //     }
    //     
    // }
    
    void Update()
    {
        // if (!isMoving) return; // 如果 isMoving 为 false，停止移动   
        // 按下 keyDown（假设为下箭头键）
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (objectB.position.y >= -2f)
            {
                // 前置判断, 如果ObjectB.y >=-2f, 则不允许A再下降
                return;
            }
            MoveObjects(-moveSpeed); // ObjectA 下降，ObjectB 上升
            if (objectB.position.y >= -2f) // 检查 ObjectB 是否达到上限
            {
                StopObjects();
            }
        }

        // 按下 keyUp（假设为上箭头键）
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y >= -10f)
            {
                // 前置判断, transform.y >=-2f, 则不允许A再上升
                return;
            }
            MoveObjects(moveSpeed); // ObjectA 上升，ObjectB 下降
            if (transform.position.y >= -10f) // 检查 ObjectA 是否达到上限
            {
                StopObjects();
            }
        }
    }
    
    // 移动物体的方法
    void MoveObjects(float speed)
    {
        // 移动 ObjectA
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // 移动 ObjectB
        objectB.Translate(Vector3.down * speed * Time.deltaTime);
        
        // 如果 ObjectB 有父类物体，移动父类物体
        if (objectB.parent != null)
        {
            objectB.parent.Translate(Vector3.forward * speed *4 * Time.deltaTime);
        }
    }

    // 停止物体的方法
    void StopObjects()
    {
        Debug.Log("物体已达到最大高度/深度，停止移动。");
        // enabled = false; // 禁用脚本，停止更新
        isMoving = true;
    }
}