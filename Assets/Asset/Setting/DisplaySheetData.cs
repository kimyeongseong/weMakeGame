using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySheetData : MonoBehaviour
{
    public Text displayText;

    private void Start()
    {
        StartCoroutine(LoadAndDisplayData());
    }

    private IEnumerator LoadAndDisplayData()
    {
        yield return Framework.GameModule.TableManager.FetchSheetData();

        // Assuming we want to display the first row, second and third columns
        string firstColumn = Framework.GameModule.TableManager.GetData(0, 1);
        string secondColumn = Framework.GameModule.TableManager.GetData(0, 2);

        displayText.text = firstColumn + "\n" + secondColumn;
    }
}
