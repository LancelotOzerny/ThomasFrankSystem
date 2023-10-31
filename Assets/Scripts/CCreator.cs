using System.Collections;
using TMPro;
using UnityEngine;

public class CCreator : MonoBehaviour
{
    [SerializeField] private TMP_InputField title;
    [SerializeField] private TMP_InputField description = null;

    public string Title { get => title.text; }
    public string Description { get => description.text;}

    /// <summary>
    /// Очистка текстов
    /// </summary>
    public void Clear()
    {
        title.text = string.Empty;
        description.text = string.Empty;
    }
}
