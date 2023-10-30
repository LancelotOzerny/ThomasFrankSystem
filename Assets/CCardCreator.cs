using TMPro;
using UnityEngine;

public class CCardCreator : MonoBehaviour
{
    [SerializeField] private CCard manager = null;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;

    public void CreateCard()
    {
        CardInfo cardInfo = new CardInfo(title.text, description.text);
        bool result = manager.createCard(cardInfo);
        if (result)
        {
            title.ClearMesh();
            description.ClearMesh();
        }
    }
}
