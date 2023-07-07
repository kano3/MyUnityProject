using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{

    public float sensitivity = 5.0f; // 鼠标灵敏度

    public float zoomSpeed = 2.0f; // 缩放速度
    public float minZoom = 5.0f; // 最小缩放距离
    public float maxZoom = 20.0f; // 最大缩放距离
    public float moveSpeed = 100.0f; // 最大缩放距离


    public bool isAltPressed = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        isAltPressed = Input.GetKey(KeyCode.LeftAlt);
        if (isAltPressed)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = -Input.GetAxis("Mouse Y") * sensitivity;

            transform.RotateAround(transform.position, Vector3.up, mouseX);
            transform.RotateAround(transform.position, transform.right, mouseY);


            // 鼠标滚轮控制缩放
            float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            transform.position += transform.forward * scroll;

            // 限制缩放范围
            if (transform.parent != null)
            {
                float distance = Vector3.Distance(transform.position, transform.parent.position);
                if (distance < minZoom)
                {
                    transform.position = transform.parent.position + transform.forward * minZoom;
                }
                else if (distance > maxZoom)
                {
                    transform.position = transform.parent.position + transform.forward * maxZoom;
                }
            }
        }
        else {
            // 获取WASD键的输入
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // 计算相机移动方向和距离
            Vector3 moveDirection = new(horizontal, vertical, 0f);
            float distance = moveSpeed * Time.deltaTime;

            // 移动相机
            transform.Translate(moveDirection * distance, Space.Self);
        }
      
    }

}
