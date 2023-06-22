using UnityEngine;
using TMPro;

namespace Runtime.Pages
{
	public class Page : MonoBehaviour
	{
		[SerializeField] protected TMP_InputField _inputField;
		[SerializeField] protected TMP_Text _errorMessage;

		public string InputFieldText { get { return _inputField.text; } }

		protected void ShowErrorMessage(string constanErrorCause)
		{
			_errorMessage.gameObject.SetActive(true);
			_errorMessage.text = constanErrorCause;
		}

		protected void HideErrorMessage()
		{
			_errorMessage.text = "";
			_errorMessage.gameObject.SetActive(false);
		}

		protected void ClearInputField() => _inputField.text = "";

		public virtual void ClearPage()
		{
			ClearInputField();
			HideErrorMessage(); 
		}
	}
}
