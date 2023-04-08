using System;
using UnityEngine;

namespace Managers
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static readonly object Lock = new ();
        private static bool _isApplicationQuiting;

        public static T Instance
        {
            get
            {
                if (_isApplicationQuiting)
                {
                    return null;
                }
                
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        _instance = FindObjectOfType<T>();

                        if (_instance == null)
                        {
                            var singletonObject = new GameObject();
                            _instance = singletonObject.AddComponent<T>();
                            singletonObject.name = $"{typeof(T).ToString()} (Singleton)";
                            DontDestroyOnLoad(singletonObject);
                        }
                    }
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void OnApplicationQuit()
        {
            _isApplicationQuiting = true;
        }
    }
    
    
}