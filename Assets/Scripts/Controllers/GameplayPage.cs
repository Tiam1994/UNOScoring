using UnityEngine;
using TMPro;

namespace UNOScoring.Controllers
{
	public class GameplayPage //: Page
	{
		[SerializeField] private TMP_Text _errorMessageForAddScores;

		public TMP_Text GetErrorMessageForAddScores { get { return _errorMessageForAddScores; } }

		public void ShowErrorMessageForAddScores(string constanErrorCause)
		{
			_errorMessageForAddScores.gameObject.SetActive(true);
			_errorMessageForAddScores.text = constanErrorCause;
		}

		public void HideErrorMessageForAddScores()
		{
			_errorMessageForAddScores.text = "";
			_errorMessageForAddScores.gameObject.SetActive(false);
		}
	}
}
