using System.Collections.Generic;
using UNOScoring.PlayerLogic;
using UnityEngine;

namespace UNOScoring.Game
{
	public class GameSession : MonoBehaviour
	{
		[SerializeField] private PlayerButton _playerButtonPrefab;
		[SerializeField] private Transform _contentWindow;
		private List<Player> _players;

		public void Initialize(List<Player> players)
		{
			_players = players;
		}

		public void StartGameSession()
		{
			CreatePlayersList();
		}

		private void CreatePlayersList()
		{
			foreach (Player player in _players)
			{
				PlayerButton playerInformationConmponent = Instantiate(_playerButtonPrefab.gameObject, _contentWindow)
					.GetComponent<PlayerButton>();

				playerInformationConmponent.Initialize(player);
				playerInformationConmponent.ComleteValues();
			}
		}
	}
}
