using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{

    private GameObject clone;
    private LineRenderer line;
    int i;

    //����LineRender����
    public GameObject target;

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //ʵ��������  
            clone = (GameObject)Instantiate(target, target.transform.position, Quaternion.identity);
            //��ø������ϵ�LineRender���  
            line = clone.GetComponent<LineRenderer>();
            //������ʼ�ͽ�������ɫ  
            //line.SetColors(Color.red, Color.blue);
            line.startColor = Color.red;
            line.endColor = Color.red;
            //������ʼ�ͽ����Ŀ��   
            //line.SetWidth(0.2f, 0.1f);
            line.startWidth = 0.1f;
            line.endWidth = 0.05f;
            //����   
            i = 0;
        }
        if (Input.GetMouseButton(0))
        {
            //ÿһ֡��⣬��������ʱ��Խ��������Խ��  
            i++;
            //���ö����� 
            //line.SetVertexCount(i);
            line.positionCount = i;
            //���ö���λ��(����������������������Ļ����ת��Ϊ��������)  
            line.SetPosition(i - 1, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5)));
        }
    }

}

