using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MetersPerSecond.Scripts.LevelEditor
{
    public class EditorButton : MonoBehaviour
    {
        public AssetRepresentation Asset;

        

        public void OnClick()
        {
            FindObjectOfType<EditorController>().SelectedAsset = Asset;
        }
    }
}
