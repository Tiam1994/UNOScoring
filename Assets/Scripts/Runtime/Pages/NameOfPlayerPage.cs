using Runtime.General.Constants;
using Runtime.Utilities;
using UnityEngine;
using TMPro;
using Runtime.General;
using System;

namespace Runtime.Pages
{
	public class NameOfPlayerPage : Page
	{
		[SerializeField] private TMP_Text _playerNumber;

		public Action OnRegestrationPlayer;

		public void ShowPlayerNumber(int number)
		{
			_playerNumber.text = number.ToString();
		}

		public void RegestrationPlayer()
		{
			if (ErrorChecker.CheckEmtyField(this))
			{
				ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
			}
			else if (ErrorChecker.CheckSameName(InputFieldText))
			{
				ShowErrorMessage(ErrorConstants.ERROR_CAUSE_SAME_NAMES);
			}
			else
			{
				HideErrorMessage();
				ClearInputField();

				Debug.Log(InputFieldText);

				OnRegestrationPlayer?.Invoke();
			}
		}

		public override void ClearPage()
		{
			base.ClearPage();
			ShowPlayerNumber(0);
		}
	}
}
