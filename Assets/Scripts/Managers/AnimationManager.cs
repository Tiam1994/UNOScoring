using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace UNOScoring.Managers
{
	public class AnimationManager : MonoBehaviour
	{
		[SerializeField] private List<GameObject> _pages;

		private const float PANEL_SHIFT = 1068f;
		private const float ANIMATION_DURATION = 0.8f;

		public void ShiftPanelsToLeftSide()
		{
			foreach (GameObject page in _pages)
			{
				page.transform.DOLocalMoveX(page.transform.localPosition.x - PANEL_SHIFT, ANIMATION_DURATION);
			}
		}

		public void ShiftPanelsToRightSide()
		{
			foreach (GameObject page in _pages)
			{
				page.transform.DOLocalMoveX(page.transform.localPosition.x + PANEL_SHIFT, ANIMATION_DURATION);
			}
		}
	}
}
