using System.Collections.Generic;
using System.Threading.Tasks;
using Runtime.Pages;
using UnityEngine;
using DG.Tweening;

namespace Runtime.Animations
{
	public class AnimationController : MonoBehaviour
	{
		[SerializeField] private GameObject _touchLockPanel;
		[SerializeField] private List<Page> _pages;

		private const float ANIMATION_DURATION = 0.8f;
		private const float PANEL_SHIFT = 1068f;

		public void TurnToNextPage()
		{
			TouchLockPanelActivate();

			foreach (Page page in _pages)
			{
				page.transform.DOLocalMoveX(page.transform.localPosition.x - PANEL_SHIFT, ANIMATION_DURATION);
			}
		}

		public void TurnToBackPage()
		{
			TouchLockPanelActivate();

			foreach (Page page in _pages)
			{
				page.transform.DOLocalMoveX(page.transform.localPosition.x + PANEL_SHIFT, ANIMATION_DURATION);
			}
		}

		private async void TouchLockPanelActivate()
		{
			_touchLockPanel.SetActive(true);
			await Task.Delay(800);
			_touchLockPanel.SetActive(false);
		}
	}
}
