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


        protected override void OnObjectEnter(TrackObject obj)
        {
            SyncCount++;
            CancelInvoke(nameof(Drop));

            if (SyncCount >= TotalSyncPoints)
            {
                //End the game maybe?
                Debug.Log("You did it bro and that is pretty cool");
                return;
            }

            Invoke(nameof(Drop), DROP_TIME);
        }

        private void Drop()
            => SyncCount = 0;
    }
}
