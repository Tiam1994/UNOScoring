using UNOScoring.Managers;
using UnityEngine;
using TMPro;

namespace UNOScoring.PlayerLogic
{
	public class PlayerButton : MonoBehaviour
	{
		[SerializeField] private TMP_Text _name;
		[SerializeField] private TMP_Text _score;

		private AnimationManager _animationManager;
		private Player _player;
		private bool _isActive;

		public bool IsActive { get { return _isActive; } }
		public Player Player { get { return _player; } }

		public void Initialize(Player player, AnimationManager animationManager)
		{
			_player = player;
			_animationManager = animationManager;
		}

		public void ComleteValues()
		{
			_name.text = _player.Name;
			_score.text = _player.Score.ToString();
		}

		public void OnButtonCliced()
		{
			SwitchIsActive();
			_animationManager.ShiftPanelsToLeftSide();
		}

		public void SwitchIsActive()
		{
			if(!_isActive)
			{
				_isActive = true;
			}
			else
			{
				_isActive = false;
			}
		}
	}
}
