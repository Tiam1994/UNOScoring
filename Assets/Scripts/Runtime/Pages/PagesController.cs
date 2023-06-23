using Runtime.Animations;
using Runtime.Gameplay;
using Runtime.General;
using UnityEngine;
using Zenject;

namespace Runtime.Pages
{
	public class PagesController : MonoBehaviour
	{
		[Header("Pages")]
		[SerializeField] private NumberOfPlayerPage _numberOfPlayerPage;
		[SerializeField] private NumberOfScorePage _numberOfScorePage;
		[SerializeField] private NameOfPlayerPage _nameOfPlayerPage;
		[SerializeField] private GameplayPage _gameplayPage;
		[SerializeField] private GameOverPage _gameOverPage;

		[Inject] private PlayerButtonsController _playerButtonsController;
		[Inject] private AnimationController _animationController;

		private void OnEnable()
		{
			_numberOfPlayerPage.OnRegestrationNumberOfPlayers += RegistrationNumberOfPlayer;
			_numberOfScorePage.OnRegestrationNumberOfScore += RegistrationNumberOfScore;
			_nameOfPlayerPage.OnRegestrationPlayer += RegistrationPlayer;
			_gameplayPage.OnRegistrationScoreCount += RegistrationScoreCount;
			_gameplayPage.OnFinishRoundButtonSelected += FinishRound;
			_playerButtonsController.OnGamaFinished += GameOver;
		}

		private void OnDisable()
		{
			_numberOfPlayerPage.OnRegestrationNumberOfPlayers -= RegistrationNumberOfPlayer;
			_numberOfScorePage.OnRegestrationNumberOfScore -= RegistrationNumberOfScore;
			_nameOfPlayerPage.OnRegestrationPlayer -= RegistrationPlayer;
			_gameplayPage.OnRegistrationScoreCount -= RegistrationScoreCount;
			_gameplayPage.OnFinishRoundButtonSelected -= FinishRound;
			_playerButtonsController.OnGamaFinished -= GameOver;
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

			_nameOfPlayerPage.ShowPlayerNumber(1);
			GameInfo.Instance.InitializePlayersList();
		}

		private void RegistrationPlayer()
		{
			GameInfo.Instance.AddPlayer(_nameOfPlayerPage.InputFieldText);
			
			if(GameInfo.Instance.Players.Count == GameInfo.Instance.NumberOfPlayer)
			{
				_animationController.TurnToNextPage();
				_playerButtonsController.CreatePlayerButtonsList();
				return;
			}

			_nameOfPlayerPage.ShowPlayerNumber(GameInfo.Instance.Players.Count + 1);
		}

		private void RegistrationScoreCount()
		{
			PlayerButton currentActivePlayerButton = _playerButtonsController.GetCurrentActivePlayerButton();
			currentActivePlayerButton.ShowCountOfScoreToBeAdded(_gameplayPage.InputFieldText);
			currentActivePlayerButton.IsButtonActivate = false;

			_animationController.TurnToBackPage();
		}

		private void FinishRound()
		{
			_playerButtonsController.AddScoreToPlayerButtonList();
			_playerButtonsController.PresenceWinnerOfGameCheck(GameInfo.Instance.NumberOfScore);
		}

		public void ReturnPreviousPage(Page page)
		{
			page.ClearPage();
			_animationController.TurnToBackPage();
		}

		private void GameOver(string loseName, int score)
		{
			_animationController.ShowGameOverPanel();
			_gameOverPage.Name = loseName;
			_gameOverPage.Score = score.ToString();
		}
	}
}
