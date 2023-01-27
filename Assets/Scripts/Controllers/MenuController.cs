using UNOScoring.PlayerLogic;
using UNOScoring.Managers;
using UNOScoring.Game;
using UnityEngine;
using Zenject;

namespace UNOScoring.Controllers
{
	public class MenuController : MonoBehaviour
	{
		[Header("Pages")]
		[SerializeField] private Page _startPage;
		[SerializeField] private Page _playersRegestrationPage;

		[Header("Managers")]
		[SerializeField] private GameSession _gameSession;
		[SerializeField] private PlayerManager _playerManager;
		[SerializeField] private ErrorsChecker _errorsChecker;

		[Inject] private AnimationManager _animationManager;

		public void NumberOfPlayersRegestration()
		{
			if(_errorsChecker.CheckEmtyField(_startPage))
			{
				_startPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_EMPTY_FIELD);
			}
			else
			{
				int playersCount = int.Parse(_startPage.PageInputField.text);

				if (playersCount <= 1)
				{
					_startPage.ShowErrorMessage(ErrorConstants.ERROR_CAUSE_FEW_PLAYERS);
				}
				else
				{
					_startPage.HideErrorMessage();
					_playerManager.InitializePlayers(_playersRegestrationPage, playersCount);
					_animationManager.ShiftPanelsToLeftSide();
				}
			}
		}

		public void PlayersNameRegestration()
		{
			_playerManager.AddPlayer(new Player(_playersRegestrationPage.PageInputField.text));
		}

		public void ReturnToStartPanel()
		{
			_playersRegestrationPage.HideErrorMessage();
			_playersRegestrationPage.ClearPageInputField();
			_animationManager.ShiftPanelsToRightSide();
		}

		public void AddScore()
		{
			_gameSession.AddScore();
			_animationManager.ShiftPanelsToRightSide();
		}

		public void ReturnToPlayersList()
		{
			_animationManager.ShiftPanelsToRightSide();
		}
	}
}
