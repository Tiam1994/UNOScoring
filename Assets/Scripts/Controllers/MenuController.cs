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
		[SerializeField] private GameplayPage _gameplayPage;

		[Inject] private AnimationController _animationController;
		[Inject] private PlayersManager _playersManager;

		private PlayerButton _playerButton;

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
			else if (ErrorsController.CheckMinimumValue(_countOfScorePage.GetInputField, 99))
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

					_playersManager.CreatePlayerButtonsList();

					return;
				}

				_playersManager.CreatePlayer(_nameOfPlayerPage.GetInputField.text);

				_playersManager.ShowActivePlayerNumber();

				_nameOfPlayerPage.HideErrorMessage();
				_nameOfPlayerPage.ClearInputField();
			}
		}

		public void AddScoreToPlayerButton()
		{
			_playerButton = _playersManager.GetCurrentPlayerButton();

			if (ErrorsController.CheckEmtyField(_gameplayPage))
			{
				_gameplayPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
			}
			else if (ErrorsController.CheckCorrectValue(_gameplayPage.GetInputField))
			{
				_gameplayPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_INCORRECT_VALUE);
			}
			else
			{
				_playerButton.ShowCountOfScoreToBeAdded(_gameplayPage.GetInputField.text);
				_playerButton.IsActiveSwitcher();

				_gameplayPage.ClearInputField();
				_gameplayPage.HideErrorMessage();

				_animationController.TurnToBackPage();
			}
		}

		public void AddScore()
		{
			_gameplayPage.HideErrorMessageForAddScores();

			if (ErrorsController.CheckForWinnerOfRound(_playersManager.PlayerButtonsList))
			{
				_gameplayPage.ShowErrorMessageForAddScores(ErrorConstants.ERROR_CAUSE_NO_WINNER);
			}
			else
			{
				_playersManager.AddScoresToPlayers();
			}
		}

		public void ReturnToBack(Page page)
		{
			page.ClearInputField();
			page.HideErrorMessage();
			_animationController.TurnToBackPage();
		}

		public void ReturnToBackAndSwitchActiveButton(Page page)
		{
			ReturnToBack(page);

			if(_playerButton == null)
			{
				_playerButton = _playersManager.GetCurrentPlayerButton();
			}
			_playerButton.IsActiveSwitcher();
		}
	}
}
