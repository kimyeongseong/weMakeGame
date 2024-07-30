using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage game field (Grid)

/// <summary>
/// ���� �ʵ��� ��ĭ ��ĭ(��)�� ����.
/// </summary>
public class FieldCell
{
    Vector3 cellPos;                //���� ��ġ
    Vector2 cellSize;               //�� �ϳ��� ũ��
    List<CellObject> objOnCell;     //�� ���� �����ϴ� ������Ʈ
    bool isSpawn;                   //�� ���� ���� �����ϴ��� ����


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
/// ���� �ʵ� (�׸���) ����. ���� ���ڷ� ������ ������ �������� ������.
/// </summary>
public class FieldManager : MonoBehaviour
{
    /// <summary>
    /// �� �ʵ��� ���� ĭ. �� ��ü�� �����Ѵ�.
    /// </summary>
    FieldCell[][] fieldCells;
    /// <summary>
    /// ���� �����ϴ� ��ġ. ũ��� �׻� fieldCells�� ������, true(1) �� ���� ����, false(0) �� �������� �ʴ´�.
    /// </summary>
    bool[][] enemySpawnPoint;


    int rowSize = 10;    int colSize = 10; //row ���ο� ����, col ���ο� ���� �� ����. ����Ʈ ��

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
        CreateField();  //����� �°� �� ���ڸ� ������
    }

    /// <summary>
    /// �� �ʵ带 ����
    /// </summary>
    void CreateField()
    {
        fieldCells = new FieldCell[rowSize][];
        enemySpawnPoint = new bool[rowSize][];

        SetField();
    }

    /// <summary>
    /// �������� ��Ʈ�� ��Ÿ ������ ���� �̸� ¥���� ���� ������ �����ϰ� �׿� ���� �ʵ带 ������
    /// </summary>
    void SetField()
    {
        //�̸� ¥���� ���� ���� ��������
        enemySpawnPoint[0][0] = true;

        //���� ������ ���� ���� ���� �Ϸ�
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
