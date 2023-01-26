using UNOScoring.PlayerLogic;
using UNOScoring.Constants;
using UNOScoring.Managers;
using UnityEngine;

namespace UNOScoring.Controllers
{
	public class MenuController : MonoBehaviour
	{
		[Header("Pages")]
		[SerializeField] private Page _startPage;
		[SerializeField] private Page _playersRegestrationPage;

		[Header("Managers")]
		[SerializeField] private AnimationManager _animationManager;
		[SerializeField] private PlayerManager _playerManager;
		[SerializeField] private ErrorsChecker _errorsChecker;

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
					_playerManager.InitializePlayers(_playersRegestrationPage, _animationManager, playersCount);
					_animationManager.ShiftPanelsToLeftSide();
				}
			}
		}

		public void PlayersNameRegestration()
		{
			_playerManager.AddPlayer(new Player(_playersRegestrationPage.PageInputField.text));
		}

		//—делать метод универсальным, что бы можно было возвращатьс€ на стартовую панель с любой кнопки
		public void ReturnToStartPanel()
		{
			_playersRegestrationPage.HideErrorMessage();
			_playersRegestrationPage.ClearPageInputField();
			_animationManager.ShiftPanelsToRightSide();
		}
	}
}
