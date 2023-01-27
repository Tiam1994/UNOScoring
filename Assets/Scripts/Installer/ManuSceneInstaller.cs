using UNOScoring.Managers;
using UnityEngine;
using Zenject;

namespace UNOScoring.Installer
{
	public class ManuSceneInstaller : MonoInstaller
	{
		[SerializeField] private AnimationManager _animationManager;

		public override void InstallBindings()
		{
			Container.Bind<AnimationManager>().FromComponentOn(_animationManager.gameObject).AsSingle().NonLazy();
		}
	}
}
