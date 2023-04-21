using UnityEngine;
using TMPro;
namespace WhackAMole.Interface
{
    public class TextDisplayer : MonoBehaviour
    {
        #region Serialized Fields
        [SerializeField] private string textLabel = "Label";

        #endregion

        #region Private Fields
        private TextMeshProUGUI textField = default;

        #endregion

        #region Setup
        // Start is called before the first frame update
        void Awake()
        {
            textField = GetComponent<TextMeshProUGUI>();
        }

        #endregion

        #region Public

        /// <summary>
        /// Displays a piece of text based on the label and the included object's name or value.
        /// </summary>
        /// <param name="textObject"></param>
        public void DisplayText(object textObject)
        {
            textField.text = textLabel + " " + textObject.ToString();
        }

        #endregion
    }
}