using System.Collections.Generic;
using UNOScoring.Controllers;
using UNOScoring.PlayerLogic;
using UNOScoring.Constants;
using UnityEngine;
using TMPro;

namespace UNOScoring.Managers
{
	public class PlayerManager : MonoBehaviour
	{
		[SerializeField] private TMP_Text _playerNumber;

		private List<Player> _playersList;
		private Page _playersReservation;
		private int _playersCount;

		public void InitializePlayers(Page playersReservation, int playersCount)
		{
			_playersList = new List<Player>();

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
				//Тут будет переход в следующее меню
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
	}
}
