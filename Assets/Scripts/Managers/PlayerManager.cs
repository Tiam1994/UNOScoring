using System.Collections.Generic;
using UNOScoring.Controllers;
using UNOScoring.PlayerLogic;
using UNOScoring.Constants;
using UNOScoring.Managers;
using UnityEngine;
using TMPro;
using UNOScoring.Game;

namespace UNOScoring.Managers
{
	public class PlayerManager : MonoBehaviour
	{
		[SerializeField] private GameSession _gameSession;
		[SerializeField] private TMP_Text _playerNumber;

		private AnimationManager _animationManager;
		private List<Player> _playersList;
		private Page _playersReservation;
		private int _playersCount;

		public void InitializePlayers(Page playersReservation, AnimationManager animationManager, int playersCount)
		{
			_playersList = new List<Player>();

			_animationManager = animationManager;
			_playersReservation = playersReservation;
			_playersCount = playersCount;

			ShowActivePlayerNumber();
		}

		public void AddPlayer(Player player)
		{
			_playersReservation.HideErrorMessage();

			if(CheckEmtyField())
			{
				_playersReservation.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
				return;
			}

			if (CheckSameName(player.Name))
			{
				_playersReservation.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_SAME_NAMES);
				return;
			}

			_playersList.Add(player);
			Debug.Log($"Player {player.Name} was added");

			if (CheckOnLastPlayer())
			{
				StartGameSession();
				Debug.Log("The players list is full");
			}
			else
			{
				ShowActivePlayerNumber();
				_playersReservation.ClearPageInputField();
			}
		}

		private void ShowActivePlayerNumber()
		{
			int playerNumber = _playersList.Count + 1;
			_playerNumber.text = playerNumber.ToString();
		}

		private bool CheckOnLastPlayer()
		{
			if(_playersList.Count == _playersCount)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool CheckEmtyField()
		{
			if (_playersReservation.PageInputField.text == string.Empty)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool CheckSameName(string name)
		{
			foreach (Player player in _playersList)
			{
				if (player.Name == name)
				{
					return true;
				}
			}

			return false;
		}

		private void StartGameSession()
		{
			_animationManager.ShiftPanelsToLeftSide();
			_playersReservation.HideErrorMessage();
			_playersReservation.ClearPageInputField();

			_gameSession.Initialize(_playersList);
		}
	}
}
