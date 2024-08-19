using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    public enum KeyBinds
    {
        UpKey,
        DownKey,
        LeftKey,
        RightKey,
    }
    public class WinFormKeys
    {
        public Keys ToUp = Keys.W;
        public Keys ToLeft = Keys.A;
        public Keys ToDown = Keys.S;
        public Keys ToRight = Keys.D;
        public WinFormKeys(Keys W, Keys A, Keys S, Keys D)
        {
            ToUp = W;
            ToLeft = A;
            ToDown = S;
            ToRight = D;
        }
        public WinFormKeys()
        {
            ToUp = Keys.W;
            ToLeft = Keys.A;
            ToDown = Keys.S;
            ToRight = Keys.D;
        }
    }
    public class WinFormController : Direction // обработка нажатия клавиш
    {
        private WinFormKeys keyset;
        public WinFormController(Keys W, Keys A, Keys S, Keys D)
        {
            keyset = new WinFormKeys(W, A, S, D);
        }
        public WinFormController()
        {
            keyset = new WinFormKeys();
        }
        public void SetDirection(object sender, KeyEventArgs e)
        {
            if (!directionValues.SequenceEqual(new int[2] { 0, 0 }))
            {
                if (e.KeyCode == keyset.ToUp) directionValues = DetermineDirection(KeyBinds.UpKey);
                else if (e.KeyCode == keyset.ToLeft) directionValues = DetermineDirection(KeyBinds.LeftKey);
                else if (e.KeyCode == keyset.ToDown) directionValues = DetermineDirection(KeyBinds.DownKey);
                else if (e.KeyCode == keyset.ToRight) directionValues = DetermineDirection(KeyBinds.RightKey);
                else { }
            }
        }
    }
    public class Direction
    {
        protected int[] directionValues = new int[2] { 1, 0 };
        public int[] DetermineDirection(KeyBinds PressedKey)
        {
            if (PressedUpKey(PressedKey)) return new int[] { 0, -1 };
            else if (PressedDownKey(PressedKey)) return new int[] { 0, 1 };
            else if (PressedLeftKey(PressedKey)) return new int[] { -1, 0 };
            else if (PressedRightKey(PressedKey)) return new int[] { 1, 0 };
            else return new int[] { };
        }
        private bool PressedUpKey(KeyBinds PressedKey)
        {
            if (PressedKey == KeyBinds.UpKey) return true;
            else return false;
        }
        private bool PressedDownKey(KeyBinds PressedKey)
        {
            if (PressedKey == KeyBinds.DownKey) return true;
            else return false;
        }
        private bool PressedLeftKey(KeyBinds PressedKey)
        {
            if (PressedKey == KeyBinds.LeftKey) return true;
            else return false;
        }
        private bool PressedRightKey(KeyBinds PressedKey)
        {
            if (PressedKey == KeyBinds.RightKey) return true;
            else return false;
        }
        public int[] GetDirectionValues()
        {
            return directionValues;
        }
    }
    public enum MapCellType // карта
    {
        Empty,
        SnakeHead,
        SnakeTail,
        Stone,
        Fruit,
    }
    public class Map
    {
        public MapCell[][] MapCells { get; set; }
    }
    public class MapCell
    {
        public MapCellType CellType { get; set; }
        public MapCell(MapCellType mapCellType)
        {
            CellType = mapCellType;
        }
    }
    public class FieldDimensions // для записи параметров карты
    {
        public int Width { get; }
        public int Height { get; }
        public FieldDimensions(int width, int height)
        {
            if (width > 0 && height > 0)
            {
                Width = width;
                Height = height;
            }
            else
            {
                Width = 10;
                Height = 10;
            }
        }
    }
    public class GameSettings // для настройки скорости игры и границ карты
    {
        public bool BordersExist { get; }
        public int TimerSpeed { get; }
        public GameSettings(bool bordersExist, int timerSpeed)
        {
            BordersExist = bordersExist;
            if (timerSpeed > 0)
            {
                TimerSpeed = timerSpeed;
            }
            else
            {
                TimerSpeed = 100;
            }
        }
    }
    public class DataForMap : Direction
    {
        protected FieldDimensions field;
        protected GameSettings settings;
        public DataForMap(FieldDimensions fieldDimensions, GameSettings gameSettings)
        {
            field = fieldDimensions;
            settings = gameSettings;
        }
    }
    public class KeyElements : DataForMap
    {
        protected int[] fruitLocation;
        protected List<MapCell> snake;
        protected List<(int x, int y)> snakeSegmentsLocation;
        public KeyElements(FieldDimensions fieldDimensions, GameSettings gameSettings) : base(fieldDimensions, gameSettings)
        {
            field = fieldDimensions;
            settings = gameSettings;
        }
        protected void AddSnakeHead(Map map)
        {
            int x = field.Height / 2;
            int y = (field.Width / 2) - 1;
            map.MapCells[x][y].CellType = MapCellType.SnakeHead;
            snake.Add(new MapCell(MapCellType.SnakeHead));
            snakeSegmentsLocation.Add((x, y));
        }
        protected void GenerateFruit(Map map)
        {
            Random random = new Random();
            int x = random.Next(1, field.Width + 1);
            int y = random.Next(1, field.Height + 1);
            map.MapCells[x][y].CellType = MapCellType.Fruit;
            fruitLocation = new int[2] { x, y };
        }
    }
    public class MapCreation : KeyElements
    {
        public MapCreation(FieldDimensions fieldDimensions, GameSettings gameSettings) : base(fieldDimensions, gameSettings)
        {
            field = fieldDimensions;
            settings = gameSettings;
        }
        public void CreateMap(Map map)
        {
            for (int i = 0; i < field.Height + 2; i++)
            {
                map.MapCells[i] = new MapCell[field.Width + 2];
                for (int j = 0; j < field.Width + 2; j++)
                {
                    map.MapCells[i][j] = new MapCell(MapCellType.Empty);
                    if ((i == 0 || i == field.Height + 1 || j == 0 || j == field.Width + 1) && settings.BordersExist)
                    {
                        map.MapCells[i][j] = new MapCell(MapCellType.Stone);
                    }
                }
            }
            AddSnakeHead(map);
            GenerateFruit(map);
        }
    }
    public class SnakeMovement : MapCreation
    {
        public SnakeMovement(FieldDimensions fieldDimensions, GameSettings gameSettings) : base(fieldDimensions, gameSettings)
        {
            field = fieldDimensions;
            settings = gameSettings;
        }
        public void SnakeSegmentsMovement(Map map)
        {
            map.MapCells[snakeSegmentsLocation[snake.Count - 1].x][snakeSegmentsLocation[snake.Count - 1].y] = new MapCell(MapCellType.Empty);
            for (int i = snake.Count - 2; i >= 1; i--)
            {
                snakeSegmentsLocation[i] = snakeSegmentsLocation[i - 1];
                map.MapCells[snakeSegmentsLocation[i].x][snakeSegmentsLocation[i].y] = new MapCell(MapCellType.SnakeTail);
            }
            snakeSegmentsLocation[0] = (snakeSegmentsLocation[0].x + directionValues[0], snakeSegmentsLocation[0].y + directionValues[1]);
            map.MapCells[snakeSegmentsLocation[0].x][snakeSegmentsLocation[0].y] = new MapCell(MapCellType.SnakeHead);
        }
    }
    public class SnakeGrowth : SnakeMovement
    {
        public SnakeGrowth(FieldDimensions fieldDimensions, GameSettings gameSettings) : base(fieldDimensions, gameSettings)
        {
            field = fieldDimensions;
            settings = gameSettings;
        }
        public void AddSnakeTailSegment(Map map) // not ready yet
        {
            int snakeLocX = snakeSegmentsLocation[0].x;
            int snakeLocY = snakeSegmentsLocation[0].y;
            int fruitLocX = fruitLocation[0];
            int fruitLocY = fruitLocation[1];
            if (snakeLocX == fruitLocX && snakeLocY == fruitLocY)
            {
                snake.Add(new MapCell(MapCellType.SnakeTail));
                snakeSegmentsLocation.Add((snakeSegmentsLocation[snake.Count - 1].x, snakeSegmentsLocation[snake.Count - 1].y));
                GenerateFruit(map);
            }
        }
    }
    public class SelfEating : SnakeMovement
    {
        public SelfEating(FieldDimensions fieldDimensions, GameSettings gameSettings) : base(fieldDimensions, gameSettings)
        {
            field = fieldDimensions;
            settings = gameSettings;
        }

        public bool EatingTail()
        {
            if (snake.Count > 3)
            {
                for (int i = 3; i <= snake.Count - 1; i++)
                {
                    if (snakeSegmentsLocation[0].x == snakeSegmentsLocation[i].x && snakeSegmentsLocation[0].y == snakeSegmentsLocation[i].y)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
    }
    public class Borders : SelfEating
    {
        public Borders(FieldDimensions fieldDimensions, GameSettings gameSettings) : base(fieldDimensions, gameSettings)
        {
            field = fieldDimensions;
            settings = gameSettings;
        }
        private int[] CheckBorders(int i)
        {
            if (snakeSegmentsLocation[i].x == 0)
                return new int[] { field.Width, snakeSegmentsLocation[i].y };
            else if (snakeSegmentsLocation[i].x == field.Width + 1)
                return new int[] { 1, snakeSegmentsLocation[i].y };
            else if (snakeSegmentsLocation[i].y == 0)
                return new int[] { snakeSegmentsLocation[i].x, field.Height };
            else if (snakeSegmentsLocation[i].y == field.Height + 1)
                return new int[] { snakeSegmentsLocation[i].x, 1 };
            else
                return new int[] { };
        }
        public void CheckThroughBorder(Map map)
        {
            for (int i = 0; i < snake.Count; i++)
            {
                int[] newCoords = CheckBorders(i);
                if (!newCoords.SequenceEqual(Array.Empty<int>()))
                    snakeSegmentsLocation[i] = (newCoords[0], newCoords[1]);
            }
        }
        public bool CheckBorderStuck(Map map)
        {
            int[] newCoords = CheckBorders(0);
            if (!newCoords.SequenceEqual(Array.Empty<int>()))
                return true;
            return false;
        }
    }
    public class GameHandler : Borders
    {
        public GameHandler(FieldDimensions fieldDimensions, GameSettings gameSettings) : base(fieldDimensions, gameSettings)
        {
            field = fieldDimensions;
            settings = gameSettings;
        }
        public void GameEnd(Map map)
        {
            if (EatingTail() || settings.BordersExist ? CheckBorderStuck(map) : settings.BordersExist)
            {
                directionValues = new int[2] { 0, 0 };
            }
        }
    }
}
