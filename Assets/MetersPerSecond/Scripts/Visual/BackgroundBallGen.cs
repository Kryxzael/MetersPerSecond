using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BackgroundBallGen : MonoBehaviour
{
    public GameObject Prefab;
    public Rect SpawnArea;

    public int InitalSpawnCountMin;
    public int InitalSpawnCountMax;

    public float SpawnChancePerFrame;

    public IEnumerator Start()
    {
        int initalSpawnCount = Random.Range(InitalSpawnCountMin, InitalSpawnCountMax);

        for (int i = 0; i < initalSpawnCount; i++)
        {
            SpawnAtRandom();
        }

        while (true)
        {
            if (Random.value <= SpawnChancePerFrame)
                SpawnAtRandom();

            yield return new WaitForEndOfFrame();
        }
    }

    private void SpawnAtRandom()
    {
        Instantiate(Prefab, new Vector2(Random.Range(SpawnArea.xMin, SpawnArea.xMax), Random.Range(SpawnArea.yMin, SpawnArea.yMax)), Quaternion.identity);
    }

}
