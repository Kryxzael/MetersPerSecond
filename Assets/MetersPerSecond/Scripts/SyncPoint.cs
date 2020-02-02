using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MetersPerSecond.Scripts
{
    public class SyncPoint : Track
    {
        private const float DROP_TIME = 0.25f;
        public static int SyncCount { get; set; }

        public static int TotalSyncPoints
        {
            get => FindObjectsOfType<SyncPoint>().Length;
        }

        public int Id
        {
            get => FindObjectsOfType<SyncPoint>().TakeWhile(i => i != this).Count();
        }


        protected override void OnObjectEnter(TrackObject obj)
        {
            SyncCount++;
            CancelInvoke(nameof(Drop));
            Pulse();

            if (SyncCount >= TotalSyncPoints)
            {
                FindObjectOfType<LevelClear>().Clear();
                SyncCount = 0;
                return;
            }

            Invoke(nameof(Drop), DROP_TIME);
        }

        public void Pulse()
        {
            GetComponentInChildren<Glow>().Pulse();
            FindObjectOfType<SoundManager>().PlaySFX((Id % 4) + 1);
        }

        private void Drop()
            => SyncCount = 0;
    }
}
