using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _scorePerSphere = 1;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotation;
    [SerializeField] private GameObject _particle;
    [SerializeField] private float _viewAngle = 0.5f;
    [SerializeField] private string _findedObjectTag;

    private Rigidbody _rigidbody;
    private GameObject[] _findedSpheres;
    private GameObject _target;
    private bool _finded;
    private bool _move;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_target == null)
        {
            _move = false;
            _finded = false;
        }

        FindSphere();
        RotationToTarget();
        Move();
    }

    private void Move()
    {
        if (_move)
        {
            _rigidbody.velocity = transform.forward * _speedMove;
        }
    }

    private void RotationToTarget()
    {
        if (_finded)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_target.transform.position - transform.position), Time.deltaTime * _speedRotation);
            var angle = Vector3.Angle(_target.transform.position - transform.position, transform.forward);
            if (angle <= _viewAngle)
            {
                _move = true;
                _finded = false;
            }
        }
    }

    private void FindSphere()
    {
        if (_finded || _move)
        {
            return;
        }

        _findedSpheres = GameObject.FindGameObjectsWithTag(_findedObjectTag);

        var minIndex = 0;

        if(!_findedSpheres.Any())
        {
            _finded = false;
            return;
        }

        for (int j = 0; j < _findedSpheres.Length; j++)
        {
            if (Vector3.Distance(transform.position, _findedSpheres[minIndex].transform.position) > Vector3.Distance(transform.position, _findedSpheres[j].transform.position))
            {
                minIndex = j;
            }
        }

        _target = _findedSpheres[minIndex];
        _finded = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == _findedObjectTag)
        {
            Instantiate(_particle, collision.gameObject.transform.position, Quaternion.identity);
            Score.Instance.AddScore(_scorePerSphere);
            Destroy(collision.gameObject);
            _move = false;
        }
    }
}
