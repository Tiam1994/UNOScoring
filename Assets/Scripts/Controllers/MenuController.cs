using UNOScoring.Constants;
using UNOScoring.GameLogic;
using UnityEngine;
using Zenject;

namespace UNOScoring.Controllers
{
	public class MenuController : MonoBehaviour
	{
		[Header("Pages")]
		[SerializeField] private Page _countOfPlayerPage;
		[SerializeField] private Page _countOfScorePage;
		[SerializeField] private Page _nameOfPlayerPage;

		[Inject] private AnimationController _animationController;
		[Inject] private PlayersManager _playersManager;

		public void RegestrationCountOfPlayers()
		{
			if (ErrorsController.CheckEmtyField(_countOfPlayerPage))
			{
				_countOfPlayerPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
			}
			else if (ErrorsController.CheckCorrectValue(_countOfPlayerPage.GetInputField))
			{
				_countOfPlayerPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_INCORRECT_VALUE);
			}
			else if (ErrorsController.CheckMinimumValue(_countOfPlayerPage.GetInputField, 1))
			{
				_countOfPlayerPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_FEW_PLAYERS);
			}
			else
			{
				_playersManager.CreatePlayersList(_countOfPlayerPage.GetInputField.text);

				_countOfPlayerPage.HideErrorMessage();
				_animationController.TurnToNextPage();
			}
		}

		public void RegestrationCountOfScore()
		{
			if(ErrorsController.CheckEmtyField(_countOfScorePage))
			{
				_countOfScorePage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
			}
			else if (ErrorsController.CheckCorrectValue(_countOfScorePage.GetInputField))
			{
				_countOfScorePage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_INCORRECT_VALUE);
			}
			else if (ErrorsController.CheckMinimumValue(_countOfScorePage.GetInputField, 100))
			{
				_countOfScorePage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_FEW_SCORE);
			}
			else
			{
				_playersManager.ShowActivePlayerNumber();

				_countOfScorePage.HideErrorMessage();
				_animationController.TurnToNextPage();
			}
		}

		public void RegestrationNameOfPlayer()
		{
			if (ErrorsController.CheckEmtyField(_nameOfPlayerPage))
			{
				_nameOfPlayerPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
			}
			else if (ErrorsController.CheckSameName(_nameOfPlayerPage.GetInputField.text, _playersManager.PlayersList))
			{
				_nameOfPlayerPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_SAME_NAMES);
			}
			else
			{
				if (_playersManager.PlayersList.Count + 1 == _playersManager.PlayersOfCount)
				{
					_playersManager.CreatePlayer(_nameOfPlayerPage.GetInputField.text);

					_nameOfPlayerPage.HideErrorMessage();
					_nameOfPlayerPage.ClearInputField();

					_animationController.TurnToNextPage();

					_playersManager.ShowPlayerList();

					return;
				}

				_playersManager.CreatePlayer(_nameOfPlayerPage.GetInputField.text);

				_playersManager.ShowActivePlayerNumber();

				_nameOfPlayerPage.HideErrorMessage();
				_nameOfPlayerPage.ClearInputField();
			}
		}

		public void ReturnToBack()
		{
			_animationController.TurnToBackPage();
		}
	}
}
