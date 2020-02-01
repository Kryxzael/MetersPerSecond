using CleanNodeTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AssetRepresentation : MonoBehaviour
{
    public string Id;

    public GameObject RealWorldObject;

    public bool MayPlaceOver;

    public virtual void Serialize(HierarchyNode n)
    {
        n.Add("x", (int)(transform.position.x + 0.5f));
        n.Add("y", (int)(transform.position.y - 0.5f));
        n.Add("r", (int)transform.eulerAngles.z);
    }

    public virtual void Deserialize(HierarchyNode n)
    {
        transform.position = new Vector2(n["x"].Int - 0.5f, n["y"].Int + 0.5f);
        transform.SetEuler2D(n["r"].Int);
    }

    public virtual void SpawnObject()
    {
        GameObject obj = Instantiate(RealWorldObject, transform.position, transform.rotation);
    }
}
