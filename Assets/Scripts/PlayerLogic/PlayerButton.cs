using UnityEngine;
using TMPro;

namespace UNOScoring.PlayerLogic
{
	public class PlayerButton : MonoBehaviour
	{
		[SerializeField] private TMP_Text _name;
		[SerializeField] private TMP_Text _score;

		private Player _player;

		public void Initialize(Player player)
		{
			_player = player;
		}

		public void ComleteValues()
		{
			_name.text = _player.Name;
		}
	}
}
