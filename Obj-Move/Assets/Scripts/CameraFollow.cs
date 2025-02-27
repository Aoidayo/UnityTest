using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /**
     public Transform target; // 跟随的目标物体
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: 未设置目标物体！");
            return;
        }
        else
        {
            offset = target.position - transform.position;
            Debug.Log(offset);
        }
    }

     */

    public Transform target; // 目标物体
    // public Vector3 offset = new Vector3(10, 15, -100); // 摄像机相对于目标的偏移量
    public float smoothSpeed = 0.125f; // 摄像机跟随的平滑速度
    public float padding = 1.0f; // 额外的视野边距
    public float z_distance = 6.52f; // 摄像机与物体的距离  z distance
    public float y_height = 18.7f; // 摄像机相对于物体的高度 y distance
    public float x_distance = -1.62f; // x distance
    
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogError("CameraFollowObject: 请将此脚本挂载到摄像机上！");
        }
    }

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollowObject: 未设置目标物体！");
            return;
        }

        // 获取目标物体的包围盒
        Bounds bounds = CalculateObjectBounds(target);

        // 计算摄像机的位置和视野
        UpdateCameraPositionAndFOV(bounds);

        // 平滑移动摄像机
        // Vector3 desiredPosition = bounds.center + offset;
        // 计算摄像机的位置
        // target.position - target.forward * distance : 使摄像机的目标方向 位于target的z轴后方
        // 摄像机的目标方向 朝上 : Vector3.up * height;
        Vector3 desiredPosition = target.position - target.right * z_distance + Vector3.up * y_height;
        desiredPosition = desiredPosition + Vector3.forward * x_distance;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // 让摄像机始终看向目标
        transform.LookAt(bounds.center);
    }

    // 计算目标物体的包围盒
    Bounds CalculateObjectBounds(Transform target)
    {
        Renderer[] renderers = target.GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0)
        {
            return new Bounds(target.position, Vector3.zero);
        }

        Bounds bounds = renderers[0].bounds;
        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate(renderer.bounds);
        }

        // 添加边距
        bounds.Expand(padding);

        return bounds;
    }

    // 更新摄像机的位置和视野
    void UpdateCameraPositionAndFOV(Bounds bounds)
    {
        // 计算物体的大小
        float objectSize = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);

        // 根据物体大小调整摄像机的视野
        float distance = objectSize / Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        // offset = new Vector3(0, objectSize, -distance);
    }
}
