using UnityEngine;
using TMPro;

namespace UNOScoring.Controllers
{
	public class Page : MonoBehaviour
	{
		[SerializeField] private TMP_InputField _inputField;
		[SerializeField] private TMP_Text _errorMessage;

		public TMP_InputField PageInputField { get { return _inputField; } }
		public TMP_Text PageErrorMessage { get { return _errorMessage; } }

		public void ShowErrorMessage(string errorCause)
		{
			_errorMessage.gameObject.SetActive(true);
			_errorMessage.text = errorCause;
		}

		public void HideErrorMessage()
		{
			_errorMessage.gameObject.SetActive(false);
		}

		public void ClearPageInputField()
		{
			_inputField.text = "";
		}
	}
}
