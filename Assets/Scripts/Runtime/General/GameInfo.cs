using System.Collections.Generic;
using Patterns;

namespace Runtime.General
{
	public class GameInfo : DOLSingleton<GameInfo>
	{
		private List<Player> _players;
		private int _numberOfPlayer;
		private int _numberOfScore;

		public int NumberOfPlayer { get { return _numberOfPlayer; } set { _numberOfPlayer = value; } }
		public int NumberOfScore { get { return _numberOfScore; } set { _numberOfScore = value; } }

		public List<Player> Players { get { return _players; } set { _players = value; } }

		public void InitializePlayersList() => _players = new List<Player>();

		public void AddPlayer(string playerName) => _players.Add(new Player(playerName));
	}
}
