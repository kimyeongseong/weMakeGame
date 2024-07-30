using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage game field (Grid)

/// <summary>
/// 게임 필드의 한칸 한칸 정보
/// </summary>
public class FieldCell
{
    Vector3 cellPos;                //셀의 위치
    Vector2 cellSize;               //셀의 크기
    List<CellObject> objOnCell;     //셀 위에 존재하는 오브젝트
    bool isSpawn;                   //적 스폰 여부


    public void CreateCell(Vector3 pos, Vector3 size)
    {
        cellPos = pos;
        cellSize = size;
    }

    public void SetSpawn(bool spawn)
    {
        isSpawn = spawn;
    }
}


/// <summary>
/// 스테이지 필드 관리자
/// </summary>
public class FieldManager : MonoBehaviour
{
    /// <summary>
    /// 스테이지를 구성하는 셀들
    /// </summary>
    FieldCell[][] fieldCells;
    /// <summary>
    /// 어느위치에서 스폰하는지. true(1)이면 스폰, false(0)이면 스폰하지 않음
    /// </summary>
    bool[][] enemySpawnPoint;


    int rowSize = 10;    int colSize = 10; //스테이지의 행렬 크기.

    // Start is called before the first frame update
    void Start()
    {
        CreateField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetFieldSize(int row, int col)
    {
        rowSize = row;
        colSize = col;
        CreateField();  
    }

    /// <summary>
    /// 필드 생성
    /// </summary>
    void CreateField()
    {
        fieldCells = new FieldCell[rowSize][];
        enemySpawnPoint = new bool[rowSize][];

        SetField();
    }

    /// <summary>
    /// 필드 설정.
    /// </summary>
    void SetField()
    {
        //스프레드 시트 등에서 받아와서 적용. 
        enemySpawnPoint[0][0] = true; //임시

        //스폰여부 설정
        for (int i = 0; i < rowSize; i++)
        {
            for (int j = 0; j < colSize; j++)
            {
                if (enemySpawnPoint[i][j])
                    fieldCells[i][j].SetSpawn(true);
                else
                    fieldCells[i][j].SetSpawn(false);
            }
        }

    }
}
