using TMPro;
using UnityEngine;

public class CCreator : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;

    [SerializeField] private TextMeshProUGUI title = null;
    [SerializeField] private TextMeshProUGUI description = null;

    public string Title { get => title.text; }
    public string Description { get => description.text;}

    /// <summary>
    /// Очистка текстов
    /// </summary>
    public void Clear()
    {

    }
}
