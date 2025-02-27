using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 移动速度
    public float jumpForce = 5.0f; // 跳跃力度
    private bool isGrounded = true; // 是否在地面上
    private Rigidbody rb; // 刚体组件

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 获取物体的 Rigidbody 组件
    }

    // Update is called once per frame
    void Update()
    {
        // 获取水平和垂直输入
        float horizontal = -Input.GetAxis("Horizontal"); // 水平方向输入（A/D 或左摇杆） Z轴前后
        float vertical = Input.GetAxis("Vertical");     // 垂直方向输入（W/S 或左摇杆） X轴左右

        // 计算移动方向
        Vector3 movement = new Vector3(vertical, 0, horizontal ) * moveSpeed * Time.deltaTime;

        // 应用移动
        transform.Translate(movement);

        // 检测跳跃输入
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // 按下空格键且在地面上
        {
            Jump(); // 执行跳跃
        }
    }

    // 跳跃逻辑
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 给物体一个向上的力
        isGrounded = false; // 标记为不在空中
    }

    // 检测物体是否落地
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 如果碰撞的物体是地面
        {
            isGrounded = true; // 标记为在地面上
        }
    }
}