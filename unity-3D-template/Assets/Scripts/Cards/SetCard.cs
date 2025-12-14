using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
//using static System.Net.Mime.MediaTypeNames;

public class SetCard : MonoBehaviour
{
    public CardData cardData;
    public Image cardArt;
    public TextMeshProUGUI textDesc;
    public bool cardSet;

    private void Start()
    {
        cardArt = this.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
        textDesc = this.transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(!cardSet)
        {
            cardArt.sprite = cardData.image;
            textDesc.text = cardData.cardDesc;
            cardSet = !cardSet;
        }
    }
}
