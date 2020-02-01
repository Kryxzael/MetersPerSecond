using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float Speed;

    private void Update()
    {
        transform.Rotate(Speed * Time.deltaTime);
    }
}