using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NoCap_3_5_6_8_
{

    class Program
    {
        private static int Health = 100;

        private const int ScreenWidth = 150;
        private const int ScreenHeight = 90;
        private const int MapHeight = 32;
        private const int MapWidth = 32;

        private const double Depth = 16;
        private const double Fov = Math.PI / 3.5;

        private static double _playerX = 2.0;
        private static double _playerY = 2.0;
        private static double _playerA ;

        private static readonly StringBuilder Map = new StringBuilder();

        static async Task Main()
        {
            //exepction esli console izmenayut

            Console.SetWindowSize(ScreenWidth, ScreenHeight);
            Console.SetBufferSize(ScreenWidth, ScreenHeight);

            Menu a = new Menu();
            while (true)
            {
                string selectedMenuItem = a.drawMenu();
                if (selectedMenuItem == "Start")
                {
                    InitMap();

                    var screen = new char[ScreenWidth * ScreenHeight];

                    DateTime dateTimeFrom = DateTime.Now;
                    DateTime date1 = new DateTime(0, 0);
                    String timeInGame;

                    while (true)
                    {
                        
                        //elapsed time
                        var dateTimeTo = DateTime.Now;
                        double elapsedTime = (dateTimeTo - dateTimeFrom).TotalSeconds;
                        dateTimeFrom = dateTimeTo;

                        if (Console.KeyAvailable)
                        {

                            ConsoleKey consoleKey = Console.ReadKey(true).Key;

                            switch (consoleKey)
                            {
                                case ConsoleKey.Escape:
                                    Console.Clear();
                                    break;
                                case ConsoleKey.A:
                                    _playerA += elapsedTime * 7;
                                    break;
                                case ConsoleKey.D:
                                    _playerA -= elapsedTime * 7;
                                    break;
                                case ConsoleKey.W:
                                    {
                                        _playerX += Math.Sin(_playerA) * 5 * elapsedTime;
                                        _playerY += Math.Cos(_playerA) * 5 * elapsedTime;

                                        if (Map[(int)_playerY * MapWidth + (int)_playerX] == '#')
                                        {
                                            _playerX -= Math.Sin(_playerA) * 5 * elapsedTime;
                                            _playerY -= Math.Cos(_playerA) * 5 * elapsedTime;
                                        }

                                        break;
                                    }

                                case ConsoleKey.S:
                                    {
                                        _playerX -= Math.Sin(_playerA) * 5 * elapsedTime;
                                        _playerY -= Math.Cos(_playerA) * 5 * elapsedTime;

                                        if (Map[(int)_playerY * MapWidth + (int)_playerX] == '#')
                                        {
                                            _playerX += Math.Sin(_playerA) * 5 * elapsedTime;
                                            _playerY += Math.Cos(_playerA) * 5 * elapsedTime;
                                        }

                                        break;
                                    }

                            }

                            if (consoleKey == ConsoleKey.Escape)
                            {
                                break;
                            }
                        }

                        //Ray Casting
                        var rayCastingTasks = new List<Task<Dictionary<int, char>>>();
                        for (int x = 0; x < ScreenWidth; x++)
                        {
                            var x1 = x;
                            rayCastingTasks.Add(Task.Run(() => CastRay(x1)));
                        }
                        foreach (Dictionary<int, char> dictionary in await Task.WhenAll(rayCastingTasks))
                        {
                            foreach (var key in dictionary.Keys)
                            {
                                screen[key] = dictionary[key];
                            }
                        }

                        date1 = date1.AddSeconds(0.005);
                        timeInGame = date1.ToString("mm:ss");

                        //Stats
                        char[] stats = $"Mode: {"Easy"},Menu: {"Escape"},Health:{Health}, Time: {timeInGame}, A: {_playerA}, FPS: {(int)(1 / elapsedTime)}"
                            .ToCharArray();
                        stats.CopyTo(screen, 0);

                        if (Map[(int)(_playerY + 1) * MapWidth + (int)_playerX] == '*')
                        {
                            Alekseev ramzes = new Alekseev();
                            ramzes.initClose();
                            ramzes.paintAlekseev();
                        }
                            

                        //map
                        for (int x = 0; x < MapWidth; x++)
                        {
                            for (int y = 0; y < MapHeight; y++)
                            {
                                screen[(y + 1) * ScreenWidth + x] = Map[y * MapWidth + x];
                            }
                        }

                        screen[(int)(_playerY + 1) * ScreenWidth + (int)_playerX] = 'P';


                        Console.SetCursorPosition(0, 0);
                        Console.Write(screen, 0, ScreenWidth * ScreenHeight);

                    }
                }
                else if (selectedMenuItem == "Settings")
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("SET");
                }
                else if (selectedMenuItem == "Exit")
                {
                    Console.Clear();
                    Environment.Exit(0);
                }

            }
         
        }

        public static Dictionary<int, char> CastRay(int x)
        {
            var result = new Dictionary<int, char>();

            double rayAngle = (_playerA + Fov / 2) - x * Fov / ScreenWidth;

            double distanceToWall = 0;
            bool hitWall = false;
            bool isBound = false;
            double wallSize = 1;

            double rayY = Math.Cos(rayAngle);
            double rayX = Math.Sin(rayAngle);

            while (!hitWall && distanceToWall < Depth)
            {
                distanceToWall += 0.1;

                int testX = (int)(_playerX + rayX * distanceToWall);
                int testY = (int)(_playerY + rayY * distanceToWall);

                if (testX < 0 || testX >= Depth + _playerX || testY < 0 || testY >= Depth + _playerY)
                {
                    hitWall = true;
                    distanceToWall = Depth;
                }
                else
                {
                    char testCell = Map[testY * MapWidth + testX];

                    if (testCell == '#' || testCell == 'B')
                    {
                        hitWall = true;

                        wallSize = testCell == '#' ? 1 : testCell == 'B' ? 1.2 : wallSize;

                        var boundsVectorsList = new List<(double X, double Y)>();

                        for (int tx = 0; tx < 2; tx++)
                        {
                            for (int ty = 0; ty < 2; ty++)
                            {
                                double vx = testX + tx - _playerX;
                                double vy = testY + ty - _playerY;

                                double vectorModule = Math.Sqrt(vx * vx + vy * vy);
                                double cosAngle = (rayX * vx / vectorModule) + (rayY * vy / vectorModule);
                                boundsVectorsList.Add((vectorModule, cosAngle));
                            }
                        }

                        boundsVectorsList = boundsVectorsList.OrderBy(v => v.X).ToList();

                        double boundAngle = 0.03 / distanceToWall;

                        if (Math.Acos(boundsVectorsList[0].Y) < boundAngle ||
                            Math.Acos(boundsVectorsList[1].Y) < boundAngle)
                            isBound = true;
                    }
                }
            }

            int ceiling = (int)(ScreenHeight / 2.0 - ScreenHeight * Fov / distanceToWall);
            int floor = ScreenHeight - ceiling;

            ceiling += (int)(ScreenHeight - ScreenHeight * wallSize);

            char wallShade;

            if(isBound)
                wallShade = '|';
            else if (distanceToWall <= Depth / 4.0)
                wallShade = '\u2588';
            else if (distanceToWall < Depth / 3.0)
                wallShade = '\u2593';
            else if (distanceToWall < Depth / 2.0)
                wallShade = '\u2592';
            else if (distanceToWall < Depth)
                wallShade = '\u2591';
            else
                wallShade = ' ';

            for (int y = 0; y < ScreenHeight; y++)
            {
                if (y < ceiling)
                    result[y * ScreenWidth + x] = ' ';
                else if (y > ceiling && y <= floor)
                    result[y * ScreenWidth + x] = wallShade;
                else
                {
                    char floorShade;
                    double b = 1.0 - (y - ScreenHeight / 2.0) / (ScreenHeight / 2.0);


                    if (b < 0.25)
                        floorShade = '#';
                    else if (b < 0.5)
                        floorShade = 'x';
                    else if (b < 0.75)
                        floorShade = '-';
                    else if (b < 0.9)
                        floorShade = '.';
                    else
                        floorShade = ' ';

                    result[y * ScreenWidth + x] = floorShade;
                }
            }

            return result;
        }

        public static void InitMap()
        {
            Map.Clear();
            Map.Append("################################");
            Map.Append("#****##......##........###.....#");
            Map.Append("#****##..##..##..####..###..#**#");
            Map.Append("#****.**.##......####..###..#**#");
            Map.Append("###########..########..###..#**#");
            Map.Append("#........##..#......#.......#**#");
            Map.Append("#..#..#..##..#...#..############");
            Map.Append("#..#..#..##..#...#.............#");
            Map.Append("#..####..##..#...############..#");
            Map.Append("#................############..#");
            Map.Append("#..............................#");
            Map.Append("#############################..#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#...........***................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("#..............................#");
            Map.Append("################################");
        }
    }
}
