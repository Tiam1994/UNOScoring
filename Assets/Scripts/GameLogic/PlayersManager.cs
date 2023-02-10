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

		private List<Player> _playersList;
		private int _playersOfCount;

		public List<Player> PlayersList { get { return _playersList; } }
		public int PlayersOfCount { get { return _playersOfCount; } }

		public void CreatePlayersList(string playersOfCount)
		{
			_playersList = new List<Player>();
			_playersOfCount = int.Parse(playersOfCount);
		}

		public void ShowPlayerList()
		{
			foreach (Player player in _playersList)
			{
				PlayerButton playerButton = _playerButtonFactory.Create();
				playerButton.transform.SetParent(_contentWindow);
				playerButton.Initialize(player);
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
	}
}
