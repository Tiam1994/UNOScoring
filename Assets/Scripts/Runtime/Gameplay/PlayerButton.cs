using Runtime.Animations;
using UnityEngine;
using Zenject;
using TMPro;

namespace Runtime.Gameplay
{
	public class PlayerButton : MonoBehaviour
	{
		public class Factory : PlaceholderFactory<PlayerButton> { }

		[SerializeField] private TMP_Text _nameText;
		[SerializeField] private TMP_Text _scoreText;

		[Inject] private AnimationController _animationController;

		private int _addedScores;
		private int _score;

		public int AddedScores { get { return _addedScores; } }
		public bool IsButtonActivate { get; set; }

		public void Initialize(string playerName, int playerScore)
		{
			_nameText.text = playerName;
			_score = playerScore;
			_scoreText.text = playerScore.ToString();
		}

		public void SelectButton()
		{
			_animationController.TurnToNextPage();
			IsButtonActivate = true;
		}

		public void ShowCountOfScoreToBeAdded(string scoreText)
		{
			_scoreText.text = $"{_score} + {scoreText}";
			_addedScores = int.Parse(scoreText);
		}

		public void AddScoreToPlayerButton()
		{
			_score = _score + _addedScores;
			_scoreText.text = _score.ToString();
			_addedScores = 0;
		}
	}
}
