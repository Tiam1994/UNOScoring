using Runtime.Animations;
using Runtime.Gameplay;
using UnityEngine;
using Zenject;

namespace Runtime.Installers
{
	public class MenuInstaller : MonoInstaller
	{
		[SerializeField] private AnimationController _animationController;
		[SerializeField] private PlayerButton _playerButtonPrefab;
		[SerializeField] private PlayerButtonsController _playerButtonsController;

		public override void InstallBindings()
		{
			Container.BindFactory<PlayerButton, PlayerButton.Factory>().FromComponentInNewPrefab(_playerButtonPrefab);

			Container.Bind<AnimationController>().FromComponentOn(_animationController.gameObject).AsSingle().NonLazy();
			Container.Bind<PlayerButtonsController>().FromComponentOn(_playerButtonsController.gameObject).AsSingle().NonLazy();
		}
	}
}
