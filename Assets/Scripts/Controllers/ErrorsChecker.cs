using System.Collections.Generic;
using UNOScoring.PlayerLogic;
using UnityEngine;

namespace UNOScoring.Controllers
{
	public class ErrorsChecker : MonoBehaviour
	{
		public bool CheckEmtyField(Page page)
		{
			if (page.PageInputField.text == string.Empty)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool CheckSameName(string name, List<Player> playersList)
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

		public bool CheckOnLastPlayerInPlayerList(List<Player> playersList, int playersCount)
		{
			if (playersList.Count == playersCount)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
