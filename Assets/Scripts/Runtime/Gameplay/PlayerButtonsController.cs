using System.Collections.Generic;
using Runtime.General;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay
{
	public class PlayerButtonsController : MonoBehaviour
	{
		[SerializeField] private Transform _contentWindow;

		[Inject] private PlayerButton.Factory _playerButtonFactory;

		private List<PlayerButton> _playerButtonsList;

		public void CreatePlayerButtonsList()
		{
			_playerButtonsList = new List<PlayerButton>();

			foreach (Player player in GameInfo.Instance.Players)
			{
				PlayerButton playerButton = _playerButtonFactory.Create();
				playerButton.transform.SetParent(_contentWindow);
				playerButton.Initialize(player.Name, player.Score);

				_playerButtonsList.Add(playerButton);
			}
		}

		public PlayerButton GetCurrentActivePlayerButton()
		{
			foreach (PlayerButton playerButton in _playerButtonsList)
			{
				if (playerButton.IsButtonActivate)
				{
					return playerButton;
				}
			}

			return null;
		}

		public void AddScoreToPlayerButtonList()
		{
			foreach (PlayerButton playerButton in _playerButtonsList)
			{
				playerButton.AddScoreToPlayerButton();
			}
		}

		public bool PresenceWinnerOfRoundCheck()
		{
			foreach (PlayerButton playerButton in _playerButtonsList)
			{
				if (playerButton.AddedScores == 0)
				{
					return false;
				}
			}

			return true;
		}
	}
}

