namespace Runtime.General
{
	public class Player
	{
		public Player(string name)
		{
			_name = name;
			_score = 0;
		}

		private string _name;
		private int _score;

		public string Name { get { return _name; } }
		public int Score { get { return _score; } }
	}
}
