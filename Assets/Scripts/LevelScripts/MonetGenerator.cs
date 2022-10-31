using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonetGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _monet;
    [SerializeField] private int _coinDensity;
    public int InstatiateMonets(int MonetsCount, int SizeX, int SizeZ)
    {
        GameObject TempMonet;
        for (int i = 0; i < MonetsCount*_coinDensity; i++)
        {
            TempMonet = Instantiate(_monet, transform);
            TempMonet.transform.position = new Vector3(Random.Range(1, SizeX), 0.6f, Random.Range(1, SizeZ));
        }
        return MonetsCount * _coinDensity;
    }
}
