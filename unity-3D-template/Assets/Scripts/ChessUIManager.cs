using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class ChessUIManager : MonoBehaviour
{
    [SerializeField] private GameObject UIParent;
    [SerializeField] private TextMeshProUGUI resultText;

    public void HideUI()
    {
        UIParent.SetActive(false);
    }

    public void OnGameFinished(string winner)
    {
        UIParent.SetActive(true);
        resultText.text = string.Format("{0} won", winner);
    }
}
