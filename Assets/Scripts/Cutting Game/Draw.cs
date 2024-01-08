using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{

    private GameObject clone;
    private LineRenderer line;
    int i;

    //带有LineRender物体
    public GameObject target;

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //实例化对象  
            clone = (GameObject)Instantiate(target, target.transform.position, Quaternion.identity);
            //获得该物体上的LineRender组件  
            line = clone.GetComponent<LineRenderer>();
            //设置起始和结束的颜色  
            //line.SetColors(Color.red, Color.blue);
            line.startColor = Color.red;
            line.endColor = Color.red;
            //设置起始和结束的宽度   
            //line.SetWidth(0.2f, 0.1f);
            line.startWidth = 0.1f;
            line.endWidth = 0.05f;
            //计数   
            i = 0;
        }
        if (Input.GetMouseButton(0))
        {
            //每一帧检测，按下鼠标的时间越长，计数越多  
            i++;
            //设置顶点数 
            //line.SetVertexCount(i);
            line.positionCount = i;
            //设置顶点位置(顶点的索引，将鼠标点击的屏幕坐标转换为世界坐标)  
            line.SetPosition(i - 1, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5)));
        }
    }

}

