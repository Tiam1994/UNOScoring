using UnityEngine;

namespace Patterns
{
	public abstract class DOLSingleton<T> : MonoBehaviour where T : DOLSingleton<T>
	{
		private static T _instance = null;

		public static T Instance { get { return _instance; } }

		private void Awake()
		{
			if (_instance == null)
			{
				_instance = (T)this;
			}
			else
			{
				Destroy(_instance);
			}
		}
	}
}
