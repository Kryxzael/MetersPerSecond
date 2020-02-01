using CleanNodeTree;
using SFB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MetersPerSecond.Scripts.LevelEditor
{
    public class EditorController : MonoBehaviour
    {
        public AssetRepresentation[] KnownAssets;

        public AssetRepresentation SelectedAsset;
        public float LastRotationAngle = 0;

        public void Save()
        {
            string path = StandaloneFileBrowser.SaveFilePanel("Save map file", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "file.clhier", "clhier");

            if (path == null)
                return;

            try
            {
                HierarchyNode node = Serialize();
                node.ToFile(path);
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
        }

        public void Load() 
        {
            string path = StandaloneFileBrowser.OpenFilePanel("Open a map file", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), new ExtensionFilter[] { new ExtensionFilter("Map files", "clhier") }, false).FirstOrDefault();

            if (path == null)
                return;

            foreach (AssetRepresentation i in FindObjectsOfType<AssetRepresentation>())
                Destroy(i.gameObject);

            try
            {
                HierarchyNode node = HierarchyNode.FromFile(path);
                Deserialize(node);
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }

        }

        public HierarchyNode Serialize()
        {
            HierarchyNode node = new HierarchyNode("mpsMap");

            foreach (AssetRepresentation i in FindObjectsOfType<AssetRepresentation>())
            {
                i.Serialize(node.Add(i.Id));
            }

            return node;
        }

        public void Deserialize(HierarchyNode n)
        {
            foreach (HierarchyNode i in n.Children)
            {
                AssetRepresentation asset = KnownAssets.SingleOrDefault(o => o.Id == i.Name);

                if (asset == null)
                {
                    Debug.LogWarning("Could not find asset with id: " + i.Name);
                    continue;
                }

                asset = Instantiate(asset, Vector3.zero, Quaternion.identity);
                asset.Deserialize(i);
            }
        }
    }
}
