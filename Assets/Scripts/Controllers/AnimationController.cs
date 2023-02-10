using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace UNOScoring.Controllers
{
	public class AnimationController : MonoBehaviour
	{
		[SerializeField] private GameObject _keylockPanel;
		[SerializeField] private List<GameObject> _pages;

		private const float ANIMATION_DURATION = 0.8f;
		private const float PANEL_SHIFT = 1068f;
		private Coroutine _waitCoroutine;

		public void TurnToNextPage()
		{
			_waitCoroutine = StartCoroutine(KeylockActivate());

			foreach (GameObject page in _pages)
			{
				page.transform.DOLocalMoveX(page.transform.localPosition.x - PANEL_SHIFT, ANIMATION_DURATION);
			}
		}

		public void TurnToBackPage()
		{
			_waitCoroutine = StartCoroutine(KeylockActivate());

			foreach (GameObject page in _pages)
			{
				page.transform.DOLocalMoveX(page.transform.localPosition.x + PANEL_SHIFT, ANIMATION_DURATION);
			}
		}

		private IEnumerator KeylockActivate()
		{
			_keylockPanel.SetActive(true);

			yield return new WaitForSeconds(ANIMATION_DURATION);

			_keylockPanel.SetActive(false);

			KillCoroutine();
		}

		private void KillCoroutine()
		{
			if(_waitCoroutine != null)
			{
				StopCoroutine(_waitCoroutine);
			}

			_waitCoroutine = null;
		}
	}
}
