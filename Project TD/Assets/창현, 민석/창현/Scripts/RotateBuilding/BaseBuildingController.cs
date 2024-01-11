using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UIElements;

public class BaseBuildingController : MonoBehaviour
{
    public List<GameObject> buildings; // 건물 배열
    public List<float> buildingsPos;

    public Transform center;
    public float radius = 10.0f;

    private int clickCount = 0;
    private float rotationAngle = Mathf.PI / 2;
    private float zRotation = 0;
    private bool isRotating = false;

    void Start()
    {
        // 초기화 및 이벤트 등록
        Init();
    }

    private void Update()
    {
        
    }

    // 건물을 돌리는 함수
    void Init()
    {
        for (int i = 0; i < buildings.Count; i++)
        {
            zRotation = (rotationAngle + i * (Mathf.PI / 4)) * Mathf.Rad2Deg + 90; // 회전값
            buildingsPos.Add(rotationAngle + i * (Mathf.PI / 4));
            Vector3 SinCos = new Vector3(Mathf.Cos(buildingsPos[i]), Mathf.Sin(buildingsPos[i]), 0); // Adjust the calculation for SinCos
            buildings[i].transform.position = center.position + SinCos * radius;
            buildings[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
        }
    }

    IEnumerator RotateBuildingsRight() // 인덱스 마다 위치가 있음
    {
        isRotating = true;

        for(float j = Mathf.PI / 2; j <= Mathf.PI / 2 + Mathf.PI / 4; j += Mathf.PI / 256) //초기 값이 pi여야 딱 맞아 떨어지기 가능 0이면 오차 생김
        {
            for (int i = 0; i < buildings.Count; i++)
            {
                buildingsPos[i] -= Mathf.PI / 256;
                zRotation = buildingsPos[i] * Mathf.Rad2Deg + 90;
                Vector3 SinCos = new Vector3(Mathf.Cos(buildingsPos[i]), Mathf.Sin(buildingsPos[i]),0); // Adjust the calculation for SinCos
                buildings[i].transform.position = center.position + SinCos * radius;
                buildings[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
            }

            yield return new WaitForSeconds(0.01f); // 델타 타임으로 고칠 필요 보임
        }

        
        isRotating = false;
    }

    IEnumerator RotateBuildingsLeft() // 인덱스 마다 위치가 있음
    {
        isRotating = true;

        for (float j = Mathf.PI / 2; j <= Mathf.PI / 2 + Mathf.PI / 4; j += Mathf.PI / 256)
        {
            for (int i = 0; i < buildings.Count; i++)
            {
                buildingsPos[i] += Mathf.PI / 256;
                zRotation = buildingsPos[i] * Mathf.Rad2Deg + 90;
                Vector3 SinCos = new Vector3(Mathf.Cos(buildingsPos[i]), Mathf.Sin(buildingsPos[i]), 0); // Adjust the calculation for SinCos
                buildings[i].transform.position = center.position + SinCos * radius;
                buildings[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
            }
            yield return new WaitForSeconds(0.01f); // 델타 타임으로 고칠 필요 보임
        }
        isRotating = false;
    }


    // 버튼 클릭 시 호출될 함수, 
    public void OnButtonClickRight()
    {
        //마지막에서 하나 전에 차례가 되면 첫번째가 뒤로 복사되고 
        if (!isRotating)
        {
            if (buildings.Count <= clickCount+1)
                return; // 클릭 횟수가 길이보다 길면 못넘어감
            clickCount++;
            Debug.Log("RightClick");
            StartCoroutine(RotateBuildingsRight());
        }
    }

    public void OnButtonClickLeft()
    {
        //마지막에서 하나 전에 차례가 되면 첫번째가 뒤로 복사되고 
        if (!isRotating)
        {
            if (clickCount<=0)
                return; // 클릭 횟수가 길이보다 길면 못넘어감
            clickCount--;
            Debug.Log("LeftClick");
            StartCoroutine(RotateBuildingsLeft());
        }
    }
}
