using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplayer : MonoBehaviour
{
    [SerializeField] private string textLabel = "Label";
    private TextMeshProUGUI textField = default;
    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Displays a piece of text based on the label and the included object's name or value.
    /// </summary>
    /// <param name="textObject"></param>
    public void DisplayText(object textObject)
    {
        textField.text = textLabel + " " + textObject.ToString();
    }
}
