using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.MetersPerSecond.Scripts
{
    public class LevelLoader : MonoBehaviour
    {
        public bool Playing { get; private set; }

        private GameObject[] _persistantObjects;

        public GameObject[] HideOnPlayObjects;

        public void PlayPause()
        {
            if (Playing)
                Pause();
            else
                Play();
        }

        public void Play()
        {
            _persistantObjects = FindObjectsOfType<GameObject>();
            AssetRepresentation[] assets = FindObjectsOfType<AssetRepresentation>();

            foreach (AssetRepresentation i in assets)
            {
                i.SpawnObject();
                i.gameObject.SetActive(false);
            }

            Playing = true;

            foreach (GameObject i in HideOnPlayObjects)
                i.SetActive(false);

        }

        public void Pause()
        {
            foreach (GameObject i in FindObjectsOfType<GameObject>())
            {
                if (!_persistantObjects.Contains(i))
                    Destroy(i);
            }

            foreach (GameObject i in _persistantObjects) 
                i.SetActive(true);

            Playing = false;

            foreach (GameObject i in HideOnPlayObjects)
                i.SetActive(true);
        }
    }
}
