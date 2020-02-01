using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MetersPerSecond.Scripts
{
    public class SyncPoint : Track
    {
        protected override void OnObjectEnter(TrackObject obj)
            => Debug.Log("Sync detected");
    }
}
