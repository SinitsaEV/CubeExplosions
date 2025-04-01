using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _spawnChanсe = 100;
    private float _chanceMultiplier = 0.5f;

    private Renderer _renderer;
    private Rigidbody _rigidbody;

    public Action<Cube> Clicked;

    public Renderer Renderer => _renderer;
    public Rigidbody Rigidbody => _rigidbody;
    public float SpawnChanсe => _spawnChanсe;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ReduceСhance(float parentSpawnChanсe)
    {
        _spawnChanсe = parentSpawnChanсe * _chanceMultiplier;
    }
}
