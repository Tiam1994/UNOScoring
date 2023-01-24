using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UNOScoring.PlayerLogic;

namespace UNOScoring.Game
{
	public class GameSession : MonoBehaviour
	{
		[SerializeField] private PlayerInformationConmponent _playerInformationComponentPrefab;
		[SerializeField] private Transform _contentWindow;
		private List<Player> _players;

		public void Initialize(List<Player> players)
		{
			_players = players;
			CreatePlayersList();
		}

		private void CreatePlayersList()
		{
			foreach (Player player in _players)
			{
				PlayerInformationConmponent playerInformationConmponent = Instantiate(_playerInformationComponentPrefab.gameObject, _contentWindow)
					.GetComponent<PlayerInformationConmponent>();

				playerInformationConmponent.Initialize(player);
				playerInformationConmponent.ComleteValues();
			}
		}
	}
}
