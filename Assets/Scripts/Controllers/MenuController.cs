using UNOScoring.PlayerLogic;
using UNOScoring.Constants;
using UNOScoring.Managers;
using UnityEngine;

namespace UNOScoring.Controllers
{
	public class MenuController : MonoBehaviour
	{
		[Header("Pages")]
		[SerializeField] private Page _playersCount;
		[SerializeField] private Page _playersReservation;

		[Header("Managers")]
		[SerializeField] private AnimationManager _animationManager;
		[SerializeField] private PlayerManager _playerManager;

		public void NumberOfPlayersCheck()
		{
			if (_playersCount.PageInputField.text == string.Empty)
			{
				_playersCount.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
			}
			else
			{
				int playersCount = int.Parse(_playersCount.PageInputField.text);

				if (playersCount <= 1)
				{
					_playersCount.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_FEW_PLAYERS);
				}
				else
				{
					_playersCount.HideErrorMessage();
					_playerManager.InitializePlayers(_playersReservation, playersCount);
					_animationManager.ShiftPanelsToLeftSide();
				}
			}
		}

		public void CreatePlayer()
		{
			_playerManager.AddPlayer(new Player(_playersReservation.PageInputField.text));
		}

		public void BackToStartPanel()
		{
			_playersReservation.HideErrorMessage();
			_playersReservation.ClearPageInputField();
			_animationManager.ShiftPanelsToRightSide();
		}
	}
}
