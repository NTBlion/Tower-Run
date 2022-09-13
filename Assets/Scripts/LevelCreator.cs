using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [Header("Tower")]
    [SerializeField] private Tower _towerTemplate;
    [SerializeField] private int _humanTowerCount;
    [Header("Wall")]
    [SerializeField] private Wall _wallTemplate;
    [SerializeField] private int _wallCount;
    [SerializeField] private float _offset;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        float roadLenght = _pathCreator.path.length;
        float distanceBetweenTower = roadLenght / _humanTowerCount;
        float distanceBetweenWall = roadLenght / _wallCount + _offset;

        float distanceTravelled = 0;
        Vector3 spawnPoint;

        for (int i = 0; i < _humanTowerCount; i++)
        {
            distanceTravelled += distanceBetweenTower;
            spawnPoint = _pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);

            Instantiate(_towerTemplate, spawnPoint, Quaternion.identity);
        }

        distanceTravelled = 0;

        for (int i = 0; i < _wallCount; i++)
        {
            distanceTravelled += distanceBetweenWall;
            spawnPoint = _pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);

            Instantiate(_wallTemplate, spawnPoint, Quaternion.identity);
        }
    }
}
