using KobolduldozokLib.Entities;
using KobolduldozokLib.Entities.Characters;
using KobolduldozokLib.Entities.Objects;
using KobolduldozokLib.Helpers;

namespace KobolduldozokLib.UI.Simulation;

public class Matrix
{
    private const int MatrixHeight = 12;
    private const int MatrixWidth = 15;
    private IEntity?[,] _grid;
    private List<House> _houses;
    private List<Farmer> _farmers;
    private List<Kobold> _kobolds;
    private List<Angel> _angels;
    private List<Coin> _coins;
    private Random _random;
    private int _currentTargetHouseIndex;
    private bool _isSimulationRunning;
    private int _frameCount;

    public Statistics Statistics { get; private set; }
    public ActivityLog ActivityLog { get; private set; }

    public Matrix()
    {
        _grid = new IEntity?[MatrixHeight, MatrixWidth];
        _houses = new List<House>();
        _farmers = new List<Farmer>();
        _kobolds = new List<Kobold>();
        _angels = new List<Angel>();
        _coins = new List<Coin>();
        _random = new Random();
        _currentTargetHouseIndex = 0;
        _isSimulationRunning = false;
        _frameCount = 0;
        Statistics = new Statistics();
        ActivityLog = new ActivityLog();
    }

    public void Initialize()
    {
        ClearGrid();
        _houses.Clear();
        _farmers.Clear();
        _kobolds.Clear();
        _angels.Clear();
        _coins.Clear();
        _frameCount = 0;
        _currentTargetHouseIndex = 0;
        Kobold.CoinsCollected = 0;
        ActivityLog.Clear();

        //2 ház, minimum 4 tile távolságra
        SpawnHouses();

        //4 farmer házak mellé (2-2)
        SpawnFarmers();

        //4-8 cig minimum 3 tile távolságra a házaktól
        SpawnKobolds();

        //2 angyal balfelső sarokba
        SpawnAngels();

        //érmék random mindenhol a cigeknek
        SpawnCoins();

        _isSimulationRunning = true;
    }

    private void ClearGrid()
    {
        for (int y = 0; y < MatrixHeight; y++)
        {
            for (int x = 0; x < MatrixWidth; x++)
            {
                _grid[y, x] = null;
            }
        }
    }

    private void SpawnHouses()
    {
        Position house1Pos = GetRandomPosition(1, MatrixWidth - 2, 1, MatrixHeight - 2);
        House house1 = new House(house1Pos);
        _houses.Add(house1);
        PlaceEntity(house1, house1Pos);
        PlaceEntity(house1, new Position(house1Pos.X + 1, house1Pos.Y));

        Position house2Pos;
        int attempts = 0;
        do
        {
            house2Pos = GetRandomPosition(1, MatrixWidth - 2, 1, MatrixHeight - 2);
            attempts++;
            //ha 100 után sem jön össze ratyi, de nem szemeteli a memóriát
            if (attempts > 100) break;
        } while (house1Pos.ManhattanDistanceTo(house2Pos) < 4);

        House house2 = new House(house2Pos);
        _houses.Add(house2);
        PlaceEntity(house2, house2Pos);
        PlaceEntity(house2, new Position(house2Pos.X + 1, house2Pos.Y));
    }

    private void SpawnFarmers()
    {
        foreach (var house in _houses)
        {
            List<Position> adjacentPositions = GetAdjacentPositions(house.Position);
            int farmersSpawned = 0;

            foreach (var pos in adjacentPositions)
            {
                if (farmersSpawned >= 2) break;
                if (IsPositionValid(pos) && _grid[pos.Y, pos.X] == null)
                {
                    Farmer farmer = new Farmer(pos);
                    _farmers.Add(farmer);
                    PlaceEntity(farmer, pos);
                    farmersSpawned++;
                }
            }
        }
    }

    private void SpawnKobolds()
    {
        int koboldCount = _random.Next(4, 9);
        Position spawnPos;
        int attempts = 0;

        //minimum 3 tile-ra a házaktól
        do
        {
            spawnPos = GetRandomPosition(0, MatrixWidth - 1, 0, MatrixHeight - 1);
            attempts++;
            if (attempts > 100) break;
        } while (!IsValidKoboldSpawnPosition(spawnPos));

        List<Position> groupPositions = GetGroupPositions(spawnPos, koboldCount);
        foreach (var pos in groupPositions)
        {
            if (IsPositionValid(pos) && _grid[pos.Y, pos.X] == null)
            {
                Kobold kobold = new Kobold(pos);
                _kobolds.Add(kobold);
                PlaceEntity(kobold, pos);
            }
        }
    }

    private void SpawnAngels()
    {
        Position angel1Pos = new Position(0, 0);
        Position angel2Pos = new Position(1, 0);

        if (_grid[angel1Pos.Y, angel1Pos.X] == null)
        {
            Angel angel1 = new Angel(angel1Pos);
            _angels.Add(angel1);
            PlaceEntity(angel1, angel1Pos);
        }

        if (_grid[angel2Pos.Y, angel2Pos.X] == null)
        {
            Angel angel2 = new Angel(angel2Pos);
            _angels.Add(angel2);
            PlaceEntity(angel2, angel2Pos);
        }
    }

    private void SpawnCoins()
    {
        int coinCount = _random.Next(4, 7);
        int spawned = 0;

        while (spawned < coinCount)
        {
            Position coinPos = GetRandomPosition(0, MatrixWidth - 1, 0, MatrixHeight - 1);
            if (IsPositionValid(coinPos) && _grid[coinPos.Y, coinPos.X] == null)
            {
                Coin coin = new Coin(coinPos);
                _coins.Add(coin);
                PlaceEntity(coin, coinPos);
                spawned++;
            }
        }
    }

    private bool IsValidKoboldSpawnPosition(Position pos)
    {
        foreach (var house in _houses)
        {
            if (pos.ManhattanDistanceTo(house.Position) < 3)
                return false;
        }
        return true;
    }

    private List<Position> GetGroupPositions(Position center, int count)
    {
        List<Position> positions = new List<Position> { center };
        List<Position> candidates = GetAdjacentPositions(center);

        foreach (var candidate in candidates)
        {
            if (positions.Count >= count) break;
            if (IsPositionValid(candidate))
            {
                positions.Add(candidate);
            }
        }

        return positions;
    }

    private List<Position> GetAdjacentPositions(Position pos)
    {
        return new List<Position>
        {
            new Position(pos.X - 1, pos.Y),
            new Position(pos.X + 1, pos.Y),
            new Position(pos.X, pos.Y - 1),
            new Position(pos.X, pos.Y + 1),
            new Position(pos.X - 1, pos.Y - 1),
            new Position(pos.X + 1, pos.Y - 1),
            new Position(pos.X - 1, pos.Y + 1),
            new Position(pos.X + 1, pos.Y + 1)
        };
    }

    private Position GetRandomPosition(int minX, int maxX, int minY, int maxY)
    {
        return new Position(_random.Next(minX, maxX + 1), _random.Next(minY, maxY + 1));
    }

    private bool IsPositionValid(Position pos)
    {
        return pos.X >= 0 && pos.X < MatrixWidth && pos.Y >= 0 && pos.Y < MatrixHeight;
    }

    private void PlaceEntity(IEntity entity, Position pos)
    {
        if (IsPositionValid(pos))
        {
            _grid[pos.Y, pos.X] = entity;
        }
    }

    private void RemoveEntity(Position pos)
    {
        if (IsPositionValid(pos))
        {
            _grid[pos.Y, pos.X] = null;
        }
    }

    public void UpdateFrame()
    {
        if (!_isSimulationRunning) return;

        _frameCount++;

        //vége, ha kitisztították a matrixot a koboldoktól
        if (_kobolds.Count == 0)
        {
            _isSimulationRunning = false;
            ActivityLog.LogSimulationEnd();
            return;
        }

        //BUG: volt olyan végeredmény, ahol láthatólag minden kobold ki lett írtva, de nem ért véget a szimuláció
        //extra safety check, hogy téynleg eltűnt-e mind
        _kobolds.RemoveAll(k => _grid[k.Position.Y, k.Position.X] != k);

        if (_kobolds.Count == 0)
        {
            _isSimulationRunning = false;
            ActivityLog.LogSimulationEnd();
            return;
        }

        //ha koboldok házhoz értek bitorolni, megindulnak az angyalok
        if (!_angels[0].IsActive && _currentTargetHouseIndex < _houses.Count)
        {
            var targetHouse = _houses[_currentTargetHouseIndex];
            bool koboldsAtHouse = _kobolds.Any(k => k.Position.ManhattanDistanceTo(targetHouse.Position) <= 1);

            if (koboldsAtHouse)
            {
                ActivityLog.LogHouseArrival(_currentTargetHouseIndex + 1);
                ActivityLog.LogAngelsActivated();

                foreach (var angel in _angels)
                {
                    angel.Activate();
                }
            }
        }

        MoveKobolds();
        CollectCoins();
        SpawnNewKobolds(); //ha elég coint felszedtek osztódnak

        if (_angels.Count > 0 && _angels[0].IsActive)
        {
            MoveAngels();
        }

        DestroyKoboldsOnContact();
    }

    private void MoveKobolds()
    {
        if (_kobolds.Count == 0) return;

        //ha 4 vagy kevesebb kobold van, érmét keresnek először
        Position? targetPos = null;
        if (_kobolds.Count <= 4 && _coins.Count > 0)
        {
            var nearestCoin = FindNearestCoin(_kobolds[0].Position);
            if (nearestCoin != null)
            {
                targetPos = nearestCoin.Position;
            }
        }

        //ha nincs érme cél vagy elegen vannak, házat keresnek
        if (targetPos == null && _currentTargetHouseIndex < _houses.Count)
        {
            targetPos = _houses[_currentTargetHouseIndex].Position;
        }

        if (targetPos == null) return;

        //együtt mozognak
        foreach (var kobold in _kobolds.ToList())
        {
            RemoveEntity(kobold.Position);
            Position? nextPos = FindNextStep(kobold.Position, targetPos);

            if (nextPos != null && IsPositionValid(nextPos))
            {
                var entityAtPos = _grid[nextPos.Y, nextPos.X];
                if (entityAtPos == null || entityAtPos is Coin)
                {
                    kobold.MoveTo(nextPos);
                    PlaceEntity(kobold, nextPos);
                }
                else
                {
                    PlaceEntity(kobold, kobold.Position);
                }
            }
            else
            {
                PlaceEntity(kobold, kobold.Position);
            }
        }

        //elérték-e a házat
        if (_currentTargetHouseIndex < _houses.Count)
        {
            var targetHouse = _houses[_currentTargetHouseIndex];
            bool allReached = _kobolds.All(k => k.Position.ManhattanDistanceTo(targetHouse.Position) <= 1);
            if (allReached && _angels.Count > 0 && _angels[0].IsActive)
            {
                if (_currentTargetHouseIndex < _houses.Count - 1)
                {
                    _currentTargetHouseIndex++;
                }
            }
        }
    }

    private Coin? FindNearestCoin(Position from)
    {
        Coin? nearest = null;
        int minDistance = int.MaxValue;

        foreach (var coin in _coins)
        {
            int distance = from.ManhattanDistanceTo(coin.Position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = coin;
            }
        }

        return nearest;
    }

    private Position? FindNextStep(Position start, Position target)
    {
        return Position.FindPath(start, target, MatrixWidth, MatrixHeight, pos =>
        {
            var entityAtPos = _grid[pos.Y, pos.X];
            return entityAtPos == null || entityAtPos is Coin;
        });
    }

    private void CollectCoins()
    {
        foreach (var kobold in _kobolds.ToList())
        {
            Coin? coinAtPosition = _coins.FirstOrDefault(c => c.Position == kobold.Position);
            if (coinAtPosition != null)
            {
                _coins.Remove(coinAtPosition);
                RemoveEntity(coinAtPosition.Position);
                Kobold.CoinsCollected++;
                ActivityLog.LogCoinPickup(_kobolds.Count);
            }
        }
    }

    private void SpawnNewKobolds()
    {
        if (Kobold.CoinsCollected >= 2)
        {
            int newKobolds = _random.Next(2, 5); //2-4 új kobold
            Kobold.CoinsCollected -= 2;

            //Spawn közel valahova a meglévőekhez
            if (_kobolds.Count > 0)
            {
                var parentKobold = _kobolds[_random.Next(_kobolds.Count)];
                var adjacentPositions = GetAdjacentPositions(parentKobold.Position);

                int spawned = 0;
                foreach (var pos in adjacentPositions)
                {
                    if (spawned >= newKobolds) break;
                    if (IsPositionValid(pos) && _grid[pos.Y, pos.X] == null)
                    {
                        Kobold newKobold = new Kobold(pos);
                        _kobolds.Add(newKobold);
                        PlaceEntity(newKobold, pos);
                        spawned++;
                    }
                }

                if (spawned > 0)
                {
                    ActivityLog.LogReproduction(spawned, _kobolds.Count);
                }
            }
        }
    }

    private void MoveAngels()
    {
        if (_kobolds.Count == 0) return;

        foreach (var angel in _angels.ToList())
        {
            //legközelebbi kobold keresése (saját relatív pozícióhoz képest)
            Kobold? nearestKobold = null;
            int minDistance = int.MaxValue;

            foreach (var kobold in _kobolds)
            {
                int distance = angel.Position.ManhattanDistanceTo(kobold.Position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestKobold = kobold;
                }
            }

            if (nearestKobold == null) continue;

            RemoveEntity(angel.Position);
            Position? nextPos = FindNextStep(angel.Position, nearestKobold.Position);

            if (nextPos != null && IsPositionValid(nextPos))
            {
                var entityAtPos = _grid[nextPos.Y, nextPos.X];
                if (entityAtPos == null || entityAtPos is Kobold || entityAtPos is Coin)
                {
                    angel.MoveTo(nextPos);
                    PlaceEntity(angel, nextPos);
                }
                else
                {
                    PlaceEntity(angel, angel.Position);
                }
            }
            else
            {
                PlaceEntity(angel, angel.Position);
            }
        }
    }

    private void DestroyKoboldsOnContact()
    {
        foreach (var angel in _angels)
        {
            //csak közvetlen szomszédként tudja kiírtani
            var koboldsToDestroy = _kobolds.Where(k =>
                k.Position.ManhattanDistanceTo(angel.Position) == 1
            ).ToList();

            if (koboldsToDestroy.Count > 0)
            {
                var kobold = koboldsToDestroy[0];

                //eltávolítás a grid-ről és a listáról
                if (_grid[kobold.Position.Y, kobold.Position.X] == kobold)
                {
                    _grid[kobold.Position.Y, kobold.Position.X] = null;
                }
                _kobolds.Remove(kobold);
                ActivityLog.LogKoboldEliminated(_kobolds.Count);
            }
        }
    }

    public void UpdateStatistics()
    {
        bool angelsActive = _angels.Count > 0 && _angels[0].IsActive;

        Statistics.Update(
            _frameCount,
            _kobolds.Count,
            _angels.Count,
            angelsActive,
            _coins.Count,
            Kobold.CoinsCollected,
            _currentTargetHouseIndex,
            _houses.Count
        );
    }

    public IEntity?[,] GetGrid() => _grid;

    public bool IsRunning()
    {
        return _isSimulationRunning;
    }

    public int GetKoboldCount()
    {
        return _kobolds.Count;
    }

    public int GetFrameCount()
    {
        return _frameCount;
    }
}
