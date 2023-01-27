namespace UNOScoring.PlayerLogic
{
	public class Player
	{
		private string _name;
		private int _score;

		public Player(string name, int score = 0)
		{
			_name = name;
			_score = score;
		}

		public string Name { get { return _name; } }

		public int Score { get { return _score; } set { _score = value; } }
	}
}
