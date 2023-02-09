using UnityEngine;
using TMPro;

namespace UNOScoring.Controllers
{
	public class Page : MonoBehaviour
	{
		[SerializeField] private TMP_InputField _inputField;
		[SerializeField] private TMP_Text _errorMessage;

		public TMP_InputField GetInputField { get { return _inputField; } }
		public TMP_Text GetErrorMessage { get { return _errorMessage; } }

		public void ClearInputField() => _inputField.text = "";

		public void ShowErrorMessage(string constanErrorCause)
		{
			_errorMessage.gameObject.SetActive(true);
			_errorMessage.text = constanErrorCause;
		}

		public void HideErrorMessage()
		{
			_errorMessage.text = "";
			_errorMessage.gameObject.SetActive(false);
		}
	}
}
