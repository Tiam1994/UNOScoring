using UNOScoring.GameLogic;
using UnityEngine;
using Zenject;

namespace UNOScoring.Controllers
{
	public class MenuController : MonoBehaviour
	{
		#region Refactoring
		//[SerializeField] private GameplayPage _gameplayPage;

		//[Inject] private PlayersManager _playersManager;

		//private PlayerButton _playerButton;

		//public void RegestrationNameOfPlayer()
		//{
		//	if (ErrorsController.CheckEmtyField(_nameOfPlayerPage))
		//	{
		//		_nameOfPlayerPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
		//	}
		//	else if (ErrorsController.CheckSameName(_nameOfPlayerPage.GetInputField.text, _playersManager.PlayersList))
		//	{
		//		_nameOfPlayerPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_SAME_NAMES);
		//	}
		//	else
		//	{
		//		if (_playersManager.PlayersList.Count + 1 == _playersManager.PlayersOfCount)
		//		{
		//			_playersManager.CreatePlayer(_nameOfPlayerPage.GetInputField.text);

		//			_nameOfPlayerPage.HideErrorMessage();
		//			_nameOfPlayerPage.ClearInputField();

		//			_animationController.TurnToNextPage();

		//			_playersManager.CreatePlayerButtonsList();

		//			return;
		//		}

		//		_playersManager.CreatePlayer(_nameOfPlayerPage.GetInputField.text);

		//		_playersManager.ShowActivePlayerNumber();

		//		_nameOfPlayerPage.HideErrorMessage();
		//		_nameOfPlayerPage.ClearInputField();
		//	}
		//}

		//public void AddScoreToPlayerButton()
		//{
		//	_playerButton = _playersManager.GetCurrentPlayerButton();

		//	if (ErrorsController.CheckEmtyField(_gameplayPage))
		//	{
		//		_gameplayPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
		//	}
		//	else if (ErrorsController.CheckCorrectValue(_gameplayPage.GetInputField))
		//	{
		//		_gameplayPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_INCORRECT_VALUE);
		//	}
		//	else
		//	{
		//		_playerButton.ShowCountOfScoreToBeAdded(_gameplayPage.GetInputField.text);
		//		_playerButton.IsActiveSwitcher();

		//		_gameplayPage.ClearInputField();
		//		_gameplayPage.HideErrorMessage();

		//		_animationController.TurnToBackPage();
		//	}
		//}

		//public void AddScore()
		//{
		//	_gameplayPage.HideErrorMessageForAddScores();

		//	if (ErrorsController.CheckForWinnerOfRound(_playersManager.PlayerButtonsList))
		//	{
		//		_gameplayPage.ShowErrorMessageForAddScores(ErrorConstants.ERROR_CAUSE_NO_WINNER);
		//	}
		//	else
		//	{
		//		_playersManager.AddScoresToPlayers();
		//	}
		//}

		//public void ReturnToBackAndSwitchActiveButton(Page page)
		//{
		//	ReturnToBack(page);

		//	if(_playerButton == null)
		//	{
		//		_playerButton = _playersManager.GetCurrentPlayerButton();
		//	}
		//	_playerButton.IsActiveSwitcher();
		//}
		#endregion
	}
}
