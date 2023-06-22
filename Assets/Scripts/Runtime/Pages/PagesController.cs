using Runtime.Animations;
using Runtime.General;
using UnityEngine;
using Zenject;

namespace Runtime.Pages
{
	public class PagesController : MonoBehaviour
	{
		[Header("Pages")]
		[SerializeField] private NumberOfPlayerPage _numberOfPlayer;
		[SerializeField] private NumberOfScorePage _numberOfScore;
		[SerializeField] private NameOfPlayerPage _nameOfPlayer;

		[Inject] private AnimationController _animationController;

		private void OnEnable()
		{
			_numberOfPlayer.OnRegestrationNumberOfPlayers += RegistrationNumberOfPlayer;
			_numberOfScore.OnRegestrationNumberOfScore += RegistrationNumberOfScore;
			_nameOfPlayer.OnRegestrationPlayer += RegistrationPlayer;
		}

		private void OnDisable()
		{
			_numberOfPlayer.OnRegestrationNumberOfPlayers -= RegistrationNumberOfPlayer;
			_numberOfScore.OnRegestrationNumberOfScore -= RegistrationNumberOfScore;
			_nameOfPlayer.OnRegestrationPlayer -= RegistrationPlayer;
		}

		private void RegistrationNumberOfPlayer(int numberOfPlayers)
		{
			GameInfo.Instance.NumberOfPlayer = numberOfPlayers;
			_animationController.TurnToNextPage();
		}

		private void RegistrationNumberOfScore(int numberOfScores)
		{
			GameInfo.Instance.NumberOfScore = numberOfScores;
			_animationController.TurnToNextPage();

			_nameOfPlayer.ShowPlayerNumber(1);
			GameInfo.Instance.InitializePlayersList();
		}

		private void RegistrationPlayer()
		{
			GameInfo.Instance.AddPlayer(_nameOfPlayer.InputFieldText);
			_nameOfPlayer.ShowPlayerNumber(GameInfo.Instance.Players.Count + 1);

			if(GameInfo.Instance.Players.Count == GameInfo.Instance.NumberOfPlayer)
			{
				_animationController.TurnToNextPage();
			}
		}

		public void ReturnPreviousPage(Page page)
		{
			page.ClearPage();
			_animationController.TurnToBackPage();
		}
	}
}
