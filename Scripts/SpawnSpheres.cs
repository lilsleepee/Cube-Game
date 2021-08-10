using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpheres : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    [SerializeField] private GameObject _plane;

    private float _sizeX, _sizeZ;

    void Start()
    {
        _sizeX = _plane.GetComponent<MeshFilter>().sharedMesh.bounds.size.x/2 - _sphere.GetComponent<MeshFilter>().sharedMesh.bounds.size.y * 1.5f;
        _sizeZ = _plane.GetComponent<MeshFilter>().sharedMesh.bounds.size.z/2 - _sphere.GetComponent<MeshFilter>().sharedMesh.bounds.size.z * 1.5f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var randomPosition = new Vector3(Random.Range(-_sizeX, _sizeX), 1, Random.Range(-_sizeZ, _sizeZ));
            Instantiate(_sphere, randomPosition, Quaternion.identity);
        }
    }
}
