using Runtime.Animations;
using UnityEngine;
using Zenject;

namespace Runtime.Installers
{
	public class MenuInstaller : MonoInstaller
	{
		[SerializeField] private AnimationController _animationController;
		//[SerializeField] private PlayersManager _playersManager;
		//[SerializeField] private PlayerButton _playerButtonPrefab;

		public override void InstallBindings()
		{
			//	Container.BindFactory<PlayerButton, PlayerButton.Factory>().FromComponentInNewPrefab(_playerButtonPrefab);

			Container.Bind<AnimationController>().FromComponentOn(_animationController.gameObject).AsSingle().NonLazy();
			//	Container.Bind<PlayersManager>().FromComponentOn(_playersManager.gameObject).AsSingle().NonLazy();
		}
	}
}
