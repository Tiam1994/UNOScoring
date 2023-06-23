using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

namespace Runtime.Pages
{
	public class GameOverPage : MonoBehaviour
	{
		[SerializeField] private TMP_Text _nameText;
		[SerializeField] private TMP_Text _scoreText;

		public string Name { set { _nameText.text = value; } }
		public string Score { set { _scoreText.text = value; } }

		public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
