using UNOScoring.Constants;
using UnityEngine;
using Zenject;

namespace UNOScoring.Controllers
{
	public class MenuController : MonoBehaviour
	{
		[Header("Pages")]
		[SerializeField] private Page _countOfPlayerPage;
		[SerializeField] private Page _countOfScorePage;

		[Inject] private AnimationController _animationController;

		public void RegestrationCountOfPlayers()
		{
			if (ErrorsController.CheckEmtyField(_countOfPlayerPage))
			{
				_countOfPlayerPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_INCORRECT_VALUE);
			}
			else if (ErrorsController.CheckCorrectValue(_countOfPlayerPage.GetInputField))
			{
				_countOfPlayerPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
			}
			else if (ErrorsController.CheckMinimumValue(_countOfPlayerPage.GetInputField, 1))
			{
				_countOfPlayerPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_FEW_PLAYERS);
			}
			else
			{
				_countOfPlayerPage.HideErrorMessage();
				_animationController.TurnToNextPage();
			}
		}

		public void RegestrationCountOfScore()
		{
			if(ErrorsController.CheckEmtyField(_countOfScorePage))
			{
				_countOfScorePage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_INCORRECT_VALUE);
			}
			else if (ErrorsController.CheckCorrectValue(_countOfScorePage.GetInputField))
			{
				_countOfScorePage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
			}
			else if (ErrorsController.CheckMinimumValue(_countOfScorePage.GetInputField, 100))
			{
				_countOfScorePage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_FEW_SCORE);
			}
			else
			{
				_countOfScorePage.HideErrorMessage();
				_animationController.TurnToNextPage();
			}
		}
	}
}
