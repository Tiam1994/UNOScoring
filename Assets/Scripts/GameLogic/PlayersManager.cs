using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

namespace UNOScoring.GameLogic
{
	public class PlayersManager : MonoBehaviour
	{
		[SerializeField] private TMP_Text _playerNumber;
		[SerializeField] private Transform _contentWindow;

		[Inject] private PlayerButton.Factory _playerButtonFactory;

		private List<PlayerButton> _playerButtonsList;
		private List<Player> _playersList;
		private int _playersOfCount;

		public List<Player> PlayersList { get { return _playersList; } }
		public int PlayersOfCount { get { return _playersOfCount; } }

		public void CreatePlayersList(string playersOfCount)
		{
			_playersList = new List<Player>();
			_playersOfCount = int.Parse(playersOfCount);
		}

		public void CreatePlayerButtonsList()
		{
			_playerButtonsList = new List<PlayerButton>();

			foreach (Player player in _playersList)
			{
				PlayerButton playerButton = _playerButtonFactory.Create();
				playerButton.transform.SetParent(_contentWindow);
				playerButton.Initialize(player);

				_playerButtonsList.Add(playerButton);
			}
		}

		public void CreatePlayer(string nameOfPlayer)
		{
			Player player = new Player();
			player.InitializePlayer(nameOfPlayer);
			_playersList.Add(player);
		}

		public void ShowActivePlayerNumber()
		{
			int playerNumber = _playersList.Count + 1;
			_playerNumber.text = playerNumber.ToString();
		}

		public PlayerButton GetCurrentPlayerButton()
		{
			foreach (PlayerButton playerButton in _playerButtonsList)
			{
				if (playerButton.IsActive)
				{
					return playerButton;
				}
			}
			return null;
		}
	}
}
