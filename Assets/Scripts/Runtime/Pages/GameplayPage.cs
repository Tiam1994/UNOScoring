using Runtime.General.Constants;
using Runtime.Utilities;
using Runtime.Gameplay;
using UnityEngine;
using Zenject;
using System;
using TMPro;

namespace Runtime.Pages
{
	public class GameplayPage : Page
	{
		[SerializeField] private TMP_Text _errorMessageForAddScores;

		[Inject] private PlayerButtonsController _playerButtonsController;

		public event Action OnRegistrationScoreCount;
		public event Action OnFinishRoundButtonSelected;

		public void AddScoresToCurrentActivePlayerButton()
		{
			if (ErrorChecker.CheckEmtyField(this))
			{
				ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
			}
			else if (ErrorChecker.CheckCorrectValue(InputFieldText))
			{
				ShowErrorMessage(ErrorConstants.ERROR_CAUSE_INCORRECT_VALUE);
			}
			else
			{
				OnRegistrationScoreCount?.Invoke();

				ClearInputField();
				HideErrorMessage();
			}
		}

		public void FinishRound()
		{
			if(_playerButtonsController.PresenceWinnerOfRoundCheck())
			{
				ShowErrorMessageForAddScores(ErrorConstants.ERROR_CAUSE_NO_WINNER);
			}
			else
			{
				HideErrorMessageForAddScores();
				OnFinishRoundButtonSelected?.Invoke();
			}
		}

		private void ShowErrorMessageForAddScores(string constanErrorCause)
		{
			_errorMessageForAddScores.gameObject.SetActive(true);
			_errorMessageForAddScores.text = constanErrorCause;
		}

		private void HideErrorMessageForAddScores()
		{
			_errorMessageForAddScores.text = "";
			_errorMessageForAddScores.gameObject.SetActive(false);
		}
	}
}
