using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundBall : MonoBehaviour
{
    public float MinAngle;
    public float MaxAngle;

    public float MinSpeed;
    public float MaxSpeed;

    public float MinSize;
    public float MaxSize;

    public float MinOpacity;
    public float MaxOpacity;

    public float MaxY;

    public void Start()
    {
        transform.Rotate(Random.Range(MinAngle, MaxAngle));
        GetComponent<MovementController>().Speed = Random.Range(MinSpeed, MaxSpeed);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Random.Range(MinOpacity, MaxOpacity));

        float size = Random.Range(MinSize, MaxSize);
        transform.localScale = new Vector3(size, size, 1f);
    }

    private void Update()
    {
        if (transform.position.y >= MaxY)
            Destroy(gameObject);
    }
}
