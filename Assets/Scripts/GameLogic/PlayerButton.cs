using UNOScoring.Controllers;
using UnityEngine;
using Zenject;
using TMPro;

namespace UNOScoring.GameLogic
{
	public class PlayerButton : MonoBehaviour
	{
		//public class Factory : PlaceholderFactory<PlayerButton> { }
		//[Inject] private AnimationController _animationController;

		//[SerializeField] private TMP_Text _name;
		//[SerializeField] private TMP_Text _score;

		//private int _addedScores;
		//private bool _isActive;
		//private Player _player;

		//public bool IsActive { get { return _isActive; } }

		//public int GetAddedScores { get { return _addedScores; } }

		//public Player GetPlayer { get { return _player; } }

		//public void Initialize(Player player)
		//{
		//	_player = player;
		//	ShowPlayerData();
		//}

		//public void ShowPlayerData()
		//{
		//	_name.text = _player.Name;
		//	_score.text = _player.Score.ToString();
		//}

		//public void ShowCountOfScoreToBeAdded(string scoreText)
		//{
		//	_score.text = $"{_player.Score} + {scoreText}";
		//	_addedScores = int.Parse(scoreText);
		//}

		//public void AddScoreToPlayer()
		//{
		//	_player.SetScores(_addedScores);
		//	_addedScores = 0;
		//}

		//public void IsActiveSwitcher()
		//{
		//	if (!_isActive)
		//	{
		//		_isActive = true;
		//	}
		//	else
		//	{
		//		_isActive = false;
		//	}
		//}

		//public void ActivateButton()
		//{
		//	_animationController.TurnToNextPage();
		//	IsActiveSwitcher();
		//}
	}
}
