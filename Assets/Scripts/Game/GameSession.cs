using System.Collections.Generic;
using UNOScoring.Controllers;
using UNOScoring.PlayerLogic;
using UNOScoring.Managers;
using UnityEngine;

namespace UNOScoring.Game
{
	public class GameSession : MonoBehaviour
	{
		[SerializeField] private Page _gamePage;
		[SerializeField] private PlayerButton _playerButtonPrefab;
		[SerializeField] private Transform _contentWindow;

		private AnimationManager _animationManager;
		private List<Player> _players;
		private List<PlayerButton> _playerButtons = new List<PlayerButton>();

		public void Initialize(List<Player> players, AnimationManager animationManager)
		{
			_players = players;
			_animationManager = animationManager;
		}

		public void StartGameSession()
		{
			CreatePlayersList();
		}

		private void CreatePlayersList()
		{
			foreach (Player player in _players)
			{
				PlayerButton playerButton = Instantiate(_playerButtonPrefab.gameObject, _contentWindow).GetComponent<PlayerButton>();
				playerButton.Initialize(player, _animationManager);
				playerButton.ComleteValues();

				_playerButtons.Add(playerButton);
			}
		}

		public void AddScore()
		{
			PlayerButton activePlayerButton = new PlayerButton();

			activePlayerButton = GetActivePlayerButton();

			activePlayerButton.Player.Score = int.Parse(_gamePage.PageInputField.text);
			activePlayerButton.SwitchIsActive();
			activePlayerButton.ComleteValues();

			_gamePage.ClearPageInputField();
		}

		private PlayerButton GetActivePlayerButton()
		{
			foreach (PlayerButton playerButton in _playerButtons)
			{
				if(playerButton.IsActive)
				{
					return playerButton;
				}
			}
			return null;
		}
	}
}
