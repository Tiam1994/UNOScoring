using UNOScoring.Controllers;
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
	[SerializeField] private AnimationController _animationController;

	public override void InstallBindings()
	{
		Container.Bind<AnimationController>().FromComponentOn(_animationController.gameObject).AsSingle().NonLazy();
	}
}
