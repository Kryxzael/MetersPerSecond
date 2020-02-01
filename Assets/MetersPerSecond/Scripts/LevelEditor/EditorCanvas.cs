using Assets.MetersPerSecond.Scripts.LevelEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class EditorCanvas : MonoBehaviour
{

    private void Update()
    {
        //The OnMouseDown message does not handle right mouse clicks so we must do so manually
        if (Input.GetMouseButtonDown((int)MouseButton.RightMouse))
            OnMouseDown();
    }

    private void OnMouseDown()
    {
        EditorController ctrl = FindObjectOfType<EditorController>();

        Vector2 clickedPositionExact = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 clickedPosition = new Vector2((int)clickedPositionExact.x + 0.5f, (int)clickedPositionExact.y - 0.5f);
        Debug.Log(clickedPosition);

        AssetRepresentation clickedAsset = GetAssetAtPoint(clickedPosition);

        if (clickedAsset != null && !(ctrl.SelectedAsset.MayPlaceOver))
        {
            if (Input.GetMouseButtonDown((int)MouseButton.LeftMouse))
            {
                //Rotate it
                clickedAsset.transform.Rotate(90);
                FindObjectOfType<EditorController>().LastRotationAngle = clickedAsset.transform.eulerAngles.z;
            }
            else if (Input.GetMouseButtonDown((int)MouseButton.RightMouse))
            {
                //Delete it
                Destroy(clickedAsset.gameObject);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                EditorController c = FindObjectOfType<EditorController>();

                //Add asset
                Instantiate(c.SelectedAsset, clickedPosition, Quaternion.Euler(0, 0, c.LastRotationAngle));
            }
        }

    }

    public AssetRepresentation GetAssetAtPoint(Vector2 pos)
    {
        foreach (AssetRepresentation i in FindObjectsOfType<AssetRepresentation>())
        {
            if (i.transform.position == (Vector3)pos)
                return i;
        }

        return null;
    }
}
