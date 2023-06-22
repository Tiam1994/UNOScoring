using UnityEngine;

namespace UNOScoring.GameLogic
{
	public class Player : MonoBehaviour
	{
		private string _name;
		private int _score;

		public string Name { get { return _name; } }
		public int Score { get { return _score; } }

		public void InitializePlayer(string name)
		{
			_name = name;
			_score = 0;
		}

		public void SetScores(int score)
		{
			_score += score;
		}
	}
}
