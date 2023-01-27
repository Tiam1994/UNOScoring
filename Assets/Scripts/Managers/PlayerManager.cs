using System.Collections.Generic;
using UNOScoring.Controllers;
using UNOScoring.PlayerLogic;
using UNOScoring.Game;
using UnityEngine;
using Zenject;
using TMPro;

namespace UNOScoring.Managers
{
	public class PlayerManager : MonoBehaviour
	{
		[SerializeField] private GameSession _gameSession;
		[SerializeField] private ErrorsChecker _errorsChecker;
		[SerializeField] private TMP_Text _playerNumber;
		[Inject] private AnimationManager _animationManager;

		private List<Player> _playersList;
		private Page _playersRegestrationPage;
		private int _playersCount;

		public void InitializePlayers(Page playersRegestrationPage, int playersCount)
		{
			_playersList = new List<Player>();

			_playersRegestrationPage = playersRegestrationPage;
			_playersCount = playersCount;

			ShowActivePlayerNumber();
		}

		public void AddPlayer(Player player)
		{
			_playersRegestrationPage.HideErrorMessage();

			if(_errorsChecker.CheckEmtyField(_playersRegestrationPage))
			{
				_playersRegestrationPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
				return;
			}

			if(_errorsChecker.CheckSameName(player.Name, _playersList))
			{
				_playersRegestrationPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_SAME_NAMES);
				return;
			}

			_playersList.Add(player);
			Debug.Log($"Player {player.Name} was added");

			if(_errorsChecker.CheckOnLastPlayerInPlayerList(_playersList, _playersCount))
			{
				StartGameSession();
				Debug.Log("The players list is full");
			}
			else
			{
				ShowActivePlayerNumber();
				_playersRegestrationPage.ClearPageInputField();
			}
		}

		private void ShowActivePlayerNumber()
		{
			int playerNumber = _playersList.Count + 1;
			_playerNumber.text = playerNumber.ToString();
		}

		private void StartGameSession()
		{
			_animationManager.ShiftPanelsToLeftSide();
			_playersRegestrationPage.HideErrorMessage();
			_playersRegestrationPage.ClearPageInputField();

			_gameSession.Initialize(_playersList);

			_gameSession.StartGameSession();
		}
	}
}
