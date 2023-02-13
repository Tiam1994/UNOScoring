using System.Collections.Generic;
using UNOScoring.GameLogic;
using TMPro;

namespace UNOScoring.Controllers
{
	public static class ErrorsController
	{
		public static bool CheckCorrectValue(TMP_InputField inputField)
		{
			if(int.TryParse(inputField.text, out int number))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public static bool CheckEmtyField(Page page)
		{
			if (page.GetInputField.text == string.Empty)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool CheckMinimumValue(TMP_InputField inputField, int minimumValue)
		{
			int playersCount = int.Parse(inputField.text);

			if (playersCount <= minimumValue)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool CheckSameName(string name, List<Player> playersList)
		{
			foreach (Player player in playersList)
			{
				if (player.Name == name)
				{
					return true;
				}
			}

			return false;
		}

		public static bool CheckForWinnerOfRound(List<PlayerButton> playerButtonsList)
		{
			foreach(PlayerButton playerButton in playerButtonsList)
			{
				if(playerButton.GetAddedScores == 0)
				{
					return false;
				}
			}

			return true;
		}
	}
}
