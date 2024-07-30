using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

/// <summary>
/// ���� �����ϴ� ������Ʈ
/// ���� �����ϴ� ��/��ֹ�/�Ʊ� ���� ��� �� CellObject�� ��ӹ޾ƾ� ��.
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
