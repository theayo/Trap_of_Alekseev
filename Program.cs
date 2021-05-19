using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;

namespace NoCap_nte_framework_
{
    class Program
    {
        private static char stage = ' ';
        private static int Health = 50;

        private const int ScreenWidth = 150;
        private const int ScreenHeight = 110;

        private const int MapHeight = 32;
        private const int MapWidth = 32;

        private const double Depth = 16;
        private const double Fov = Math.PI / 3.5;

        private static double _playerX = 1.0;
        private static double _playerY = 3.0;
        private static double _playerA = 1.5;

        private static readonly StringBuilder Map = new StringBuilder();

        static async Task Main()
        {
            //Console.Beep();
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.SetWindowSize(ScreenWidth, ScreenHeight);
            Console.SetBufferSize(ScreenWidth, ScreenHeight);

            Menu a = new Menu();
            
            SoundPlayer player = new SoundPlayer(@"C:\Users\bezzu\source\repos\NoCap(nte framework)\NoCap(nte framework)\CyberPunk.wav");
            player.Play();
            

            while (true)
            {
                string selectedMenuItem = a.drawMenu();//menu
                player.Stop();

                if (selectedMenuItem == "Start")
                {
                    InitMap();

                    var screen = new char[ScreenWidth * ScreenHeight];  //screen buffer

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

                            }       //control buttons

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

                        //Timer
                        date1 = date1.AddSeconds(0.005);
                        timeInGame = date1.ToString("mm:ss");

                        //Stats
                        char[] stats = $"Mode: {"Easy"},Menu: {"Escape"},Pashuk Health:{Health}, Time: {timeInGame}, A: {_playerA}, FPS: {(int)(1 / elapsedTime)},angel: {_playerA}"
                            .ToCharArray();
                        stats.CopyTo(screen, 0);

                        //Dialoge
                        stage = Map[(int)(_playerY + 1) * MapWidth + (int)_playerX];
                        switch (stage)
                        {
                            case '*':

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Ramzes v = new Ramzes();
                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                v.quest("2!", v);

                                _playerX = 12.0;
                                _playerY = 3.0;
                                break;
                            case '+':
                                _playerY = 9.0;
                                _playerX = 2.0;

                                Console.Clear();
                                Console.SetCursorPosition(0, 0);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.BackgroundColor = ConsoleColor.White;
                                break;
                            case '&':
                                _playerY = 14.0;
                                _playerX = 5.0;

                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.BackgroundColor = ConsoleColor.Blue;
                                break;
                            case '^':
                                Alekseev alex = new Alekseev();

                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                alex.quest("40 % pROCENT na?", alex);
                                break;
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
                }           //start
                else if (selectedMenuItem == "Settings")
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("SET");
                }       //set
                else if (selectedMenuItem == "Exit")
                {
                    Console.Clear();
                    Environment.Exit(0);
                }          //exit

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

                if (testX < 0 || testX >= Depth + _playerX || testY < 0 || testY >= Depth + _playerY) //Hit wall
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

            if (isBound)
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
                {
                    result[y * ScreenWidth + x] = ' ';
                }
                else if (y > ceiling && y <= floor)
                {
                    result[y * ScreenWidth + x] = wallShade;

                }
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
            Map.Append("#......##############......#####");
            Map.Append("#.....*#*...........#..#.++#..##");
            Map.Append("#....****................++...##");
            Map.Append("#.....*#*...........#....++#..##");
            Map.Append("#......##############......#####");
            Map.Append("################################");
            Map.Append("#.....^#^.........&&&...........");
            Map.Append("#.....^^^.........&&&...........");
            Map.Append("#.................&&&...........");
            Map.Append("################################");
            Map.Append("#..............................#");
            Map.Append("#####..##..#####################");
            Map.Append("#............##................#");
            Map.Append("#............##................#");
            Map.Append("#####..##..#####################");
            Map.Append("#..............................#");
            Map.Append("################################");
            Map.Append("#.................!!!..........#");
            Map.Append("#.................!!!...........");
            Map.Append("#.................!!!...........");
            Map.Append("################################");
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
