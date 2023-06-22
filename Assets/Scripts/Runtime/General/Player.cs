using UnityEngine;

namespace Runtime.General
{
	[System.Serializable]
	public class Player
	{
		public Player(string name)
		{
			_name = name;
			//_score = 0;
		}

		private string _name;
		//private int _score;

		public string Name { get { return _name; } }
		//public int Score { get { return _score; } }

		//public void SetScores(int score)
		//{
		//	_score += score;-
		//}
	}
}
