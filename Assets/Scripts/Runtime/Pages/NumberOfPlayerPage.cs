using Runtime.General.Constants;
using Runtime.Utilities;
using System;

namespace Runtime.Pages
{
	public class NumberOfPlayerPage : Page
	{
		private int _numberOfPlayer;

		public Action<int> OnRegestrationNumberOfPlayers;

		public void RegestrationNumberOfPlayers()
		{
			if (ErrorChecker.CheckEmtyField(this))
			{
				ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
			}
			else if (ErrorChecker.CheckCorrectValue(InputFieldText))
			{
				ShowErrorMessage(ErrorConstants.ERROR_CAUSE_INCORRECT_VALUE);
			}
			else if (ErrorChecker.CheckMinimumValue(this, 1))
			{
				ShowErrorMessage(ErrorConstants.ERROR_CAUSE_FEW_PLAYERS);
			}
			else
			{
				_numberOfPlayer = int.Parse(InputFieldText);
				OnRegestrationNumberOfPlayers?.Invoke(_numberOfPlayer);

				HideErrorMessage();
			}
		}
	}
}
