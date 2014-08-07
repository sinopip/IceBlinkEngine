using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using IceBlinkCore;

namespace IceBlink
{
    enum SquareContent
    {
        Empty,
        Monster,
        Hero,
        Wall
    }

    class CompleteSquare
    {
        SquareContent _contentCode = SquareContent.Empty;
        public SquareContent ContentCode
        {
            get { return _contentCode; }
            set { _contentCode = value; }
        }

        int _distanceSteps = 10000; //Stores the number of steps needed for the monster to get to this square
        public int DistanceSteps
        {
            get { return _distanceSteps; }
            set { _distanceSteps = value; }
        }

        bool _isPath = false; //Boolean that says whether this is part of the best path from monster to hero
        public bool IsPath
        {
            get { return _isPath; }
            set { _isPath = value; }
        }

        public void FromChar(char charIn) //Translates a char from our file into an enum value for the ContentCode
        {
            switch (charIn)
            {
                case 'W':
                    _contentCode = SquareContent.Wall;
                    break;
                case 'H':
                    _contentCode = SquareContent.Hero;
                    break;
                case 'M':
                    _contentCode = SquareContent.Monster;
                    break;
                case ' ':
                default:
                    _contentCode = SquareContent.Empty;
                    break;
            }
        } 
    }

    class Pathfinder
    {
        Point[] _movements; // Movements is an array of various directions.
        Game pf_game;

        CompleteSquare[,] _squares; // Squares is an array of square objects.
        public CompleteSquare[,] Squares
        {
            get { return _squares; }
            set { _squares = value; }
        }

        public Pathfinder(Game g)
        {
            pf_game = g;
            _squares = new CompleteSquare[pf_game.currentCombatArea.MapSizeInSquares.Width, pf_game.currentCombatArea.MapSizeInSquares.Height];
            InitMovements(8);
            ClearSquares();
        }
        public void InitMovements(int movementCount)
        {
            /*
             * 
             * Just do some initializations.
             * 
             * */
            if (movementCount == 4)
            {
                _movements = new Point[]
                {
                    new Point(0, -1),
                    new Point(1, 0),
                    new Point(0, 1),
                    new Point(-1, 0)
                };
            }
            else
            {
                _movements = new Point[]
                {
                    new Point(-1, -1),
                    new Point(0, -1),
                    new Point(1, -1),
                    new Point(1, 0),
                    new Point(1, 1),
                    new Point(0, 1),
                    new Point(-1, 1),
                    new Point(-1, 0)
                };
            }
        }
        public void ClearSquares()
        {
            /*
             * 
             * Reset every square.
             * 
             * */
            foreach (Point point in AllSquares(pf_game))
            {
                _squares[point.X, point.Y] = new CompleteSquare();
            }
        }
        public void ClearLogic()
        {
            /*
             * 
             * Reset some information about the squares.
             * 
             * */
            foreach (Point point in AllSquares(pf_game))
            {
                int x = point.X;
                int y = point.Y;
                _squares[x, y].DistanceSteps = 10000;
                _squares[x, y].IsPath = false;
            }
        }
        public void Pathfind(Creature crt)
        {
            /*
             * 
             * Find path from hero to monster. First, get coordinates
             * of hero.
             * 
             * */
            Point startingPoint = FindCode(SquareContent.Hero);
            int heroX = startingPoint.X;
            int heroY = startingPoint.Y;
            if (heroX == -1 || heroY == -1)
            {
                return;
            }
            /*
             * 
             * Hero starts at distance of 0.
             * 
             * */
            _squares[heroX, heroY].DistanceSteps = 0;
            if (crt.Size == 2)
            {
                for (int x = heroX - 1; x < heroX + 2; x++)
                {
                    for (int y = heroY - 1; y < heroY + 2; y++)
                    {
                        if (Pathfinder.ValidCoordinates(x, y, pf_game))
                        {
                            _squares[x, y].DistanceSteps = 0;
                        }
                    }
                }
            }
            if (crt.Size == 3)
            {
                for (int x = heroX - 2; x <= heroX + 1; x++)
                {
                    for (int y = heroY - 2; y <= heroY + 1; y++)
                    {
                        if (Pathfinder.ValidCoordinates(x, y, pf_game))
                        {
                            _squares[x, y].DistanceSteps = 0;
                        }
                    }
                }
            }
            while (true)
            {
                bool madeProgress = false;

                /*
                 * 
                 * Look at each square on the board.
                 * 
                 * */
                foreach (Point mainPoint in AllSquares(pf_game))
                {
                    int x = mainPoint.X;
                    int y = mainPoint.Y;

                    /*
                     * 
                     * If the square is open, look through valid moves given
                     * the coordinates of that square.
                     * 
                     * */
                    if (SquareOpen(x, y, crt))
                    {
                        int passHere = _squares[x, y].DistanceSteps;

                        foreach (Point movePoint in ValidMoves(x, y, crt))
                        {
                            int newX = movePoint.X;
                            int newY = movePoint.Y;
                            int newPass = passHere + 1;

                            if (_squares[newX, newY].DistanceSteps > newPass)
                            {
                                _squares[newX, newY].DistanceSteps = newPass;
                                madeProgress = true;
                            }
                        }
                    }
                }
                if (!madeProgress)
                {
                    break;
                }
            }
        }
        public static bool ValidCoordinates(int x, int y, Game pf_game)
        {
            /*
             * 
             * Our coordinates are constrained between 0 and 14.
             * 
             * */
            if (x < 0)
            {
                return false;
            }
            if (y < 0)
            {
                return false;
            }
            if (x > (pf_game.currentCombatArea.MapSizeInSquares.Width - 2)) 
            {
                return false;
            }
            if (y > (pf_game.currentCombatArea.MapSizeInSquares.Height - 2))
            {
                return false;
            }
            return true;
        }
        private bool SquareOpen(int x, int y, Creature crt)
        {
            /*
             * 
             * A square is open if it is not a wall.
             * 
             * */
            if (crt.Size == 1)
            {
                if ((x > pf_game.currentCombatArea.MapSizeInSquares.Width - 2) || (y > pf_game.currentCombatArea.MapSizeInSquares.Height - 2))
                {
                    return false;
                }
                if ((_squares[x, y].ContentCode == SquareContent.Empty) || (_squares[x, y].ContentCode == SquareContent.Monster) || (_squares[x, y].ContentCode == SquareContent.Hero))
                {
                    return true;
                }
            }
            if (crt.Size == 2)
            {
                if ((x > pf_game.currentCombatArea.MapSizeInSquares.Width - 3) || (y > pf_game.currentCombatArea.MapSizeInSquares.Height - 3))
                {
                    return false;
                }
                if ((_squares[x, y].ContentCode == SquareContent.Empty) || (_squares[x, y].ContentCode == SquareContent.Monster) || (_squares[x, y].ContentCode == SquareContent.Hero))
                {
                    if ((_squares[x + 1, y].ContentCode == SquareContent.Empty) || (_squares[x + 1, y].ContentCode == SquareContent.Monster) || (_squares[x + 1, y].ContentCode == SquareContent.Hero))
                    {
                        if ((_squares[x, y + 1].ContentCode == SquareContent.Empty) || (_squares[x, y + 1].ContentCode == SquareContent.Monster) || (_squares[x, y + 1].ContentCode == SquareContent.Hero))
                        {
                            if ((_squares[x + 1, y + 1].ContentCode == SquareContent.Empty) || (_squares[x + 1, y + 1].ContentCode == SquareContent.Monster) || (_squares[x + 1, y + 1].ContentCode == SquareContent.Hero))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            if (crt.Size == 3)
            {
                if ((x > pf_game.currentCombatArea.MapSizeInSquares.Width - 4) || (y > pf_game.currentCombatArea.MapSizeInSquares.Height - 4))
                {
                    return false;
                }
                if ((_squares[x + 0, y + 0].ContentCode == SquareContent.Empty) || (_squares[x + 0, y + 0].ContentCode == SquareContent.Monster) || (_squares[x + 0, y + 0].ContentCode == SquareContent.Hero))
                {
                    if ((_squares[x + 1, y + 0].ContentCode == SquareContent.Empty) || (_squares[x + 1, y + 0].ContentCode == SquareContent.Monster) || (_squares[x + 1, y + 0].ContentCode == SquareContent.Hero))
                    {
                        if ((_squares[x + 2, y + 0].ContentCode == SquareContent.Empty) || (_squares[x + 2, y + 0].ContentCode == SquareContent.Monster) || (_squares[x + 2, y + 0].ContentCode == SquareContent.Hero))
                        {
                            if ((_squares[x + 0, y + 1].ContentCode == SquareContent.Empty) || (_squares[x + 0, y + 1].ContentCode == SquareContent.Monster) || (_squares[x + 0, y + 1].ContentCode == SquareContent.Hero))
                            {
                                if ((_squares[x + 2, y + 1].ContentCode == SquareContent.Empty) || (_squares[x + 2, y + 1].ContentCode == SquareContent.Monster) || (_squares[x + 2, y + 1].ContentCode == SquareContent.Hero))
                                {
                                    if ((_squares[x + 0, y + 2].ContentCode == SquareContent.Empty) || (_squares[x + 0, y + 2].ContentCode == SquareContent.Monster) || (_squares[x + 0, y + 2].ContentCode == SquareContent.Hero))
                                    {
                                        if ((_squares[x + 1, y + 2].ContentCode == SquareContent.Empty) || (_squares[x + 1, y + 2].ContentCode == SquareContent.Monster) || (_squares[x + 1, y + 2].ContentCode == SquareContent.Hero))
                                        {
                                            if ((_squares[x + 2, y + 2].ContentCode == SquareContent.Empty) || (_squares[x + 2, y + 2].ContentCode == SquareContent.Monster) || (_squares[x + 2, y + 2].ContentCode == SquareContent.Hero))
                                            {
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;

            //old stuff
            /*switch (_squares[x, y].ContentCode)
            {
                case SquareContent.Empty:
                    return true;
                case SquareContent.Hero:
                    return true;
                case SquareContent.Monster:
                    return true;
                case SquareContent.Wall:
                default:
                    return false;
            }*/
        }
        public Point FindCode(SquareContent contentIn)
        {
            /*
             * 
             * Find the requested code and return the point.
             * 
             * */
            foreach (Point point in AllSquares(pf_game))
            {
                if (_squares[point.X, point.Y].ContentCode == contentIn)
                {
                    return new Point(point.X, point.Y);
                }
            }
            return new Point(-1, -1);
        }
        public void HighlightPath(Creature crt)
        {
            /*
             * 
             * Mark the path from monster to hero.
             * 
             * */
            Point startingPoint = FindCode(SquareContent.Monster);
            int pointX = startingPoint.X;
            int pointY = startingPoint.Y;
            if (pointX == -1 && pointY == -1)
            {
                return;
            }

            while (true)
            {
                /*
                 * 
                 * Look through each direction and find the square
                 * with the lowest number of steps marked.
                 * 
                 * */
                Point lowestPoint = Point.Empty;
                int lowest = 10000;

                foreach (Point movePoint in ValidMoves(pointX, pointY, crt))
                {
                    int count = _squares[movePoint.X, movePoint.Y].DistanceSteps;
                    if (count < lowest)
                    {
                        lowest = count;
                        lowestPoint.X = movePoint.X;
                        lowestPoint.Y = movePoint.Y;
                    }
                }
                if (lowest != 10000)
                {
                    /*
                     * 
                     * Mark the square as part of the path if it is the lowest
                     * number. Set the current position as the square with
                     * that number of steps.
                     * 
                     * */
                    _squares[lowestPoint.X, lowestPoint.Y].IsPath = true;
                    pointX = lowestPoint.X;
                    pointY = lowestPoint.Y;
                }
                else
                {
                    break;
                }

                if (_squares[pointX, pointY].ContentCode == SquareContent.Hero)
                {
                    /*
                     * 
                     * We went from monster to hero, so we're finished.
                     * 
                     * */
                    break;
                }
            }
        }
        public static IEnumerable<Point> AllSquares(Game pf_game)
        {
            /*
             * 
             * Return every point on the board in order.
             * 
             * */
            for (int x = 0; x <= (pf_game.currentCombatArea.MapSizeInSquares.Width - 1); x++)
            {
                for (int y = 0; y <= (pf_game.currentCombatArea.MapSizeInSquares.Height - 1); y++)
                {
                    yield return new Point(x, y); //After the yield is reached, and the value is returned, the foreach calls the function again, but resumes where it left off.
                }
            }
        }
        public IEnumerable<Point> ValidMoves(int x, int y, Creature crt)
        {
            /*
             * 
             * Return each valid square we can move to.
             * 
             * */
            foreach (Point movePoint in _movements)
            {
                int newX = x + movePoint.X;
                int newY = y + movePoint.Y;
                //this may be the place to add the size check stuff
                if (ValidCoordinates(newX, newY, pf_game) && SquareOpen(newX, newY, crt))
                {
                    yield return new Point(newX, newY);
                }
            }
        }
    }
}
