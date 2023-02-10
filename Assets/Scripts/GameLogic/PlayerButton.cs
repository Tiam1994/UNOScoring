using UnityEngine;
using Zenject;
using TMPro;

namespace UNOScoring.GameLogic
{
	public class PlayerButton : MonoBehaviour
	{
		public class Factory : PlaceholderFactory<PlayerButton> { }

		[SerializeField] private TMP_Text _name;
		[SerializeField] private TMP_Text _score;

		private Player _player;

		public void Initialize(Player player)
		{
			_player = player;
			ShowPlayerData();
		}

		public void ShowPlayerData()
		{
			_name.text = _player.Name;
			_score.text = _player.Score.ToString();
		}
	}
}
