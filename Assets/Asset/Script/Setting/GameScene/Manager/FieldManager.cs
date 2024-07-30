using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage game field (Grid)

/// <summary>
/// 게임 필드의 한칸 한칸(셀)을 지정.
/// </summary>
public class FieldCell
{
    Vector3 cellPos;                //셀의 위치
    Vector2 cellSize;               //셀 하나의 크기
    List<CellObject> objOnCell;     //셀 위에 존재하는 오브젝트
    bool isSpawn;                   //이 셀에 적이 스폰하는지 여부


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
/// 게임 필드 (그리드) 관리. 맵을 격자로 나누어 각자의 포지션을 지정함.
/// </summary>
public class FieldManager : MonoBehaviour
{
    /// <summary>
    /// 맵 필드의 격자 칸. 맵 전체를 포함한다.
    /// </summary>
    FieldCell[][] fieldCells;
    /// <summary>
    /// 적이 스폰하는 위치. 크기는 항상 fieldCells와 같으며, true(1) 시 적이 스폰, false(0) 시 스폰하지 않는다.
    /// </summary>
    bool[][] enemySpawnPoint;


    int rowSize = 10;    int colSize = 10; //row 가로열 길이, col 세로열 길이 를 지정. 디폴트 값

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
        CreateField();  //사이즈에 맞게 맵 격자를 재지정
    }

    /// <summary>
    /// 맵 필드를 생성
    /// </summary>
    void CreateField()
    {
        fieldCells = new FieldCell[rowSize][];
        enemySpawnPoint = new bool[rowSize][];

        SetField();
    }

    /// <summary>
    /// 스프레드 시트나 기타 수단을 통해 미리 짜여진 스폰 구역을 지정하고 그에 맞춰 필드를 세팅함
    /// </summary>
    void SetField()
    {
        //미리 짜여진 스폰 구역 지정받음
        enemySpawnPoint[0][0] = true;

        //스폰 구역에 따라 스폰 설정 완료
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
