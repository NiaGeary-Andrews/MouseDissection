using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI ContentText;


    public void updateTitleText(string text)
    {
        TitleText.text = text;
    }
}
