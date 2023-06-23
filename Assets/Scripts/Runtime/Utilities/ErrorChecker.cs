using Runtime.General;
using Runtime.Pages;

namespace Runtime.Utilities
{
	public static class ErrorChecker
	{
		public static bool CheckCorrectValue(string InputFieldText)
		{
			if (int.TryParse(InputFieldText, out int number))
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
			if (page.InputFieldText == string.Empty)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool CheckMinimumValue(Page page, int minimumValue)
		{
			int playersCount = int.Parse(page.InputFieldText);

			if (playersCount <= minimumValue)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool CheckSameName(string name)
		{
			foreach (Player player in GameInfo.Instance.Players)
			{
				if (player.Name == name)
				{
					return true;
				}
			}

			return false;
		}
	}
}
