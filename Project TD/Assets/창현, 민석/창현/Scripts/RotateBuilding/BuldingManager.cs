using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BuldingManager : MonoBehaviour
{
    public Vector3 Size { get; private set; }

    public void SetSize(Vector3 newSize)
    {
        Size = newSize;
        Debug.Log("건물의 크기가 설정되었습니다. 크기: " + Size);
    }

    // 건물의 크기를 가져오는 메서드
    public Vector3 GetSize()
    {
        return Size;
    }


}
