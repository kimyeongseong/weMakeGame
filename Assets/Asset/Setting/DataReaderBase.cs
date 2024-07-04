using UnityEngine;

public abstract class DataReaderBase : ScriptableObject
{
    [Header("시트 주소")][SerializeField] public string associatedSheet = "1gxz5J8xEh3owhlCK_vSTWdRh-Cp5QKVgxX-HX1PhnbY";
    [Header("시트명")][SerializeField] public string associatedWorksheet = "config";
    [Header("최초 위치")][SerializeField] public int START_ROW_LENGTH = 2;
    [Header("마지막 위치")][SerializeField] public int END_ROW_LENGTH = 3;
}