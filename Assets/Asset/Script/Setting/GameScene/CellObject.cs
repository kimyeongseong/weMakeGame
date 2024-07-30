using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

/// <summary>
/// 셀에 존재하는 오브젝트
/// 셀에 존재하는 적/장애물/아군 등은 모두 이 CellObject를 상속받아야 함.
/// </summary>
public class CellObject : MonoBehaviour 
{
    ObjectType myType;
    FieldCell mycell;

    CellObject(ObjectType type)
    {
        myType = type;
    }

    CellObject(ObjectType type, FieldCell cell)
    {
        myType = type;
        mycell = cell;
    }


    public void SetType(ObjectType type)
    {
        myType = type;
    }

    public void SetCell(FieldCell cell)
    {
        mycell = cell;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
