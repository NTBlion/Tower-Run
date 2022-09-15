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

    private List<Wall> _walls;

    private Vector3 _offsetY = new Vector3(0, 0.5f, 0);

    private void Start()
    {
        _walls = new List<Wall>();
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        float roadLenght = _pathCreator.path.length;
        float distanceBetweenTower = roadLenght / _humanTowerCount;
        float distanceBetweenWall = roadLenght / _wallCount;

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

            _walls.Add(Instantiate(_wallTemplate, spawnPoint + _offsetY, Quaternion.identity));
        }

        _walls[_walls.Count - 1].gameObject.SetActive(false);
    }
}
