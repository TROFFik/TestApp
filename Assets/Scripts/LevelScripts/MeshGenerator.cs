using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class MeshGenerator : MonoBehaviour
{
    [SerializeField] private int _xSize = 20;
    [SerializeField] private int _zSize = 20;

    private MeshCollider collider;
    private Mesh meshMap;
    private Vector3[] vertices;
    private int[] triangles;

    public void StartGaneration()
    {
        CreateMesh();
        UpdateMesh();
    }

    public int GetSizeX
    {
        get { return _xSize; }
    }

    public int GetSizeZ
    {
        get { return _zSize; }
    }
    private void CreateMesh()
    { 
        vertices = new Vector3[8];

        for (int i = 0, z = 0; z < 2; z++)
        {
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    vertices[i] = new Vector3(x * _xSize, y, z * _zSize);
                    i++;
                }
            }
        }

        triangles = new int[]
        {
            0, 1, 5,
            0, 5, 4,
            0, 3, 1,
            0, 2, 3,
            0, 4, 2,
            6, 2, 4,
            6, 4, 5,
            6, 5, 7,
            6, 3, 2,
            6, 7, 3
        };
    }

    private void UpdateMesh()
    {
        meshMap = new Mesh();
        GetComponent<MeshFilter>().mesh = meshMap;
        collider = GetComponent<MeshCollider>();
        meshMap.Clear();

        meshMap.vertices = vertices;
        meshMap.triangles = triangles;
        meshMap.RecalculateNormals();

        collider.sharedMesh = meshMap;
    }
}
