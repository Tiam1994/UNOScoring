using Runtime.General.Constants;
using Runtime.Utilities;
using System;

namespace Runtime.Pages
{
	public class NumberOfScorePage : Page
	{
		private int _numberOfScore;

		public Action<int> OnRegestrationNumberOfScore;

		public void RegestrationCountOfScore()
		{
			if (ErrorChecker.CheckEmtyField(this))
			{
				ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
			}
			else if (ErrorChecker.CheckCorrectValue(InputFieldText))
			{
				ShowErrorMessage(ErrorConstants.ERROR_CAUSE_INCORRECT_VALUE);
			}
			else if (ErrorChecker.CheckMinimumValue(this, 99))
			{
				ShowErrorMessage(ErrorConstants.ERROR_CAUSE_FEW_SCORE);
			}
			else
			{
				_numberOfScore = int.Parse(InputFieldText);
				OnRegestrationNumberOfScore?.Invoke(_numberOfScore);

				HideErrorMessage();
			}
		}
	}
}
