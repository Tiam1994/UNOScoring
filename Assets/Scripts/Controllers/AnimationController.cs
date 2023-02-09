using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace UNOScoring.Controllers
{
	public class AnimationController : MonoBehaviour
	{
		[SerializeField] private List<GameObject> _pages;

		private const float ANIMATION_DURATION = 0.8f;
		private const float PANEL_SHIFT = 1068f;

		public void TurnToNextPage()
		{
			foreach (GameObject page in _pages)
			{
				page.transform.DOLocalMoveX(page.transform.localPosition.x - PANEL_SHIFT, ANIMATION_DURATION);
			}
		}

		public void TurnToBackPage()
		{
			foreach (GameObject page in _pages)
			{
				page.transform.DOLocalMoveX(page.transform.localPosition.x + PANEL_SHIFT, ANIMATION_DURATION);
			}
		}

	}
}
