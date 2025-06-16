using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Board : Form
    {
        /*
            Minesweeper by Kyle
            2/11/2025
            A minesweeper copy with customizeable board size and numbers of mines
            Max board size = 30/30
            Min board size = 6/6
            Max mines = 5 less than total tiles
        */

        //Tile setup
        public class Tile
        {
            public enum Type
            {
                Mine,
                Empty,
                Number,
            }

            public int posX;
            public int posY;
            public Type type;
            public bool exploded;
            public bool revealed;
            public bool flagged;
            public int number;
        }

        //More variables
        public int timer;
        public int width = 16;
        public int height = 16;
        public int mineNums = 35;
        public int totalMines;
        public bool boardEnabled;
        public int boardWidth;
        public int boardHeight;
        public Tile[,] state;
        public Button[,] cells;

        public Board()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlaceUI();
            GenerateBoard();
            LoadBoard();
        }

        //Initializes the board
        private void GenerateBoard()
        {
            NewGame.BackgroundImage = Properties.Resources.Smiley;
            boardEnabled = true;
            state = new Tile[width, height];

            //Sets up the empty board
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile cell = new Tile();
                    cell.posX = x;
                    cell.posY = y;
                    cell.type = Tile.Type.Empty;
                    cell.exploded = false;
                    cell.revealed = false;
                    cell.flagged = false;
                    state[x, y] = cell;
                }
            }

            //Places UI
            PlaceUI();

            //Places mines
            PlaceMines();

            //Places numbers
            PlaceNumbers();

            return;
        }

        //Places mines
        private void PlaceMines()
        {
            Random rnd = new Random();
            for (int i = 0; i < mineNums; i++)
            {
                
                int rndX = rnd.Next(0, width);
                int rndY = rnd.Next(0, height);

                //Moves the mine if placed on another mine
                while (state[rndX, rndY].type == Tile.Type.Mine)
                {
                    rndX++;

                    if (rndX >= width)
                    {
                        rndX = 0;
                        rndY++;
                    }
                    if (rndY >= height)
                    {
                        rndY = 0;
                    }
                }

                state[rndX, rndY].type = Tile.Type.Mine;
            }

            return;
        }

        //Places numbers
        private void PlaceNumbers()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //Checks surrounding squares for mines
                    if (state[x, y].type != Tile.Type.Mine)
                    {
                        int mines = 0;

                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                if ((0 <= (x + i) && (x + i) < width) && (0 <= (y + j) && (y + j) < height)) {
                                    if (state[x + i, y + j].type == Tile.Type.Mine)
                                    {
                                        mines++;
                                    }
                                }
                            }
                        }

                        if (mines != 0)
                        {

                            state[x, y].number = mines;
                            state[x, y].type = Tile.Type.Number;
                        }
                    }
                }
            }
            return;
        }

        //Places UI
        private void PlaceUI()
        {
            boardWidth = width;
            boardHeight = height;
            totalMines = mineNums;
            NewGame.Location = new Point((width) * 32 + 64, (height * 32 / 2) - 88);

            MinesLabel.Location = new Point((width) * 32 + 24, (height * 32 / 2) - 44);
            XLabel.Location = new Point((width) * 32 + 24, (height * 32 / 2) + 20);
            YLabel.Location = new Point((width) * 32 + 24, (height * 32 / 2) - 12);
            RemainingLabel.Location = new Point((width) * 32 + 24, (height * 32 / 2) + 52);


            MineNum.Location = new Point((width) * 32 + 100, (height * 32 / 2) - 44);
            MineNum.Text = mineNums.ToString();
            SizeY.Location = new Point((width) * 32 + 100, (height * 32 / 2) - 12);
            SizeY.Text = height.ToString();
            SizeX.Location = new Point((width) * 32 + 100, (height * 32 / 2) + 20);
            SizeX.Text = width.ToString();
            RemainingMines.Location = new Point((width) * 32 + 100, (height * 32 / 2) + 52);
            RemainingMines.Text = totalMines.ToString();

            timer = 0;
            TimerUI.Text = timer.ToString();
            TimerUI.Location = new Point((width) * 32 + 24, (height * 32 / 2) + 84);

            this.Size = new Size((boardWidth * 32) + 172, boardHeight * 32);
        }

        //Loads the Board
        private void LoadBoard()
        {
            cells = new Button[width, height];
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile cell = state[x, y];
                    cells[x, y] = new Button();
                    cells[x, y].BackgroundImage = GetImage(cell);
                    cells[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    cells[x, y].Size = new Size(32, 32);
                    cells[x, y].Location = new Point(cell.posX*32, cell.posY*32);
                    cells[x, y].FlatAppearance.BorderSize = 0;
                    cells[x, y].FlatStyle = FlatStyle.Flat;
                    cells[x, y].Margin = new Padding(0, 0, 0, 0);
                    cells[x, y].MouseDown += ButtonPressed;
                    Controls.Add(cells[x, y]);
                }
            }
        }

        //Stuff that happens after a button is pressed
        private void ButtonPressed(object sender, MouseEventArgs e)
        {
            if (boardEnabled) {
                //Starts the timer
                if (!time.Enabled)
                {
                    time.Enabled = true;
                }

                Button pressedButton = sender as Button;
                int locX = (pressedButton.Location.X / 32);
                int locY = (pressedButton.Location.Y / 32);
                Tile pressedTile = state[locX, locY];


                if (e.Button == MouseButtons.Left && !pressedTile.revealed && !pressedTile.flagged)
                {
                    //Checks for mines
                    if (pressedTile.type == Tile.Type.Mine)
                    {
                        pressedTile.exploded = true;
                        Lose();
                        return;
                    }
                    //Checks for Empty Tiles
                    if (pressedTile.type == Tile.Type.Empty)
                    {
                        RevealMore(pressedTile);
                    }
                    pressedTile.revealed = true;

                    WinCheck();
                }
                //Flagging
                else if (e.Button == MouseButtons.Right && !pressedTile.revealed)
                {
                    if (pressedTile.flagged)
                    {
                        pressedTile.flagged = false;
                        totalMines++;
                    }
                    else
                    {
                        pressedTile.flagged = true;
                        totalMines--;
                    }
                    RemainingMines.Text = totalMines.ToString();
                }

                //Changes tile image
                state[locX, locY] = pressedTile;
                cells[locX, locY].BackgroundImage = GetImage(state[locX, locY]);
            }
        }

        //Ends the game after loss
        private void Lose()
        {
            NewGame.BackgroundImage = Properties.Resources.Deady;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    state[x, y].revealed = true;
                    cells[x, y].BackgroundImage = GetImage(state[x, y]);
                }
            }
            time.Enabled = false;
            totalMines = 0;
            RemainingMines.Text = totalMines.ToString();
            boardEnabled = false;
        }

        //reveals all  surrounding 
        private void RevealMore(Tile tile)
        {
            int locX = tile.posX;
            int locY = tile.posY;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (locX + i >= 0 && locX + i < width && locY + j >= 0 && locY + j < height) {
                        Tile cell = state[locX + i, locY + j];

                        if (!cell.revealed && !cell.flagged)
                        {
                            cell.revealed = true;

                            if (cell.type == Tile.Type.Empty)
                            {
                                RevealMore(cell);
                            }
                        }

                        state[locX + i, locY + j] = cell;
                        cells[locX + i, locY + j].BackgroundImage = GetImage(state[locX + i, locY + j]);
                    }
                }
            }
        }

        //Checks if you've won
        private void WinCheck()
        {
            //Checks if all non mines are revealed
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (state[x, y].type != Tile.Type.Mine && !state[x, y].revealed)
                    {
                        return;
                    }
                }
            }

            //Flags all the mines
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (state[x, y].type == Tile.Type.Mine)
                    {
                        state[x, y].flagged = true;
                        cells[x, y].BackgroundImage = GetImage(state[x, y]);
                    }
                }
            }

            totalMines = 0;
            RemainingMines.Text = totalMines.ToString();

            time.Enabled = false;
            NewGame.BackgroundImage = Properties.Resources.Cooly;
            boardEnabled = false;
        }

        //Checks what image a tile should be
        private Image GetImage(Tile tile)
        {
            //Number tile images
            Image Tile1 = Properties.Resources.Tile1;
            Image Tile2 = Properties.Resources.Tile2;
            Image Tile3 = Properties.Resources.Tile3;
            Image Tile4 = Properties.Resources.Tile4;
            Image Tile5 = Properties.Resources.Tile5;
            Image Tile6 = Properties.Resources.Tile6;
            Image Tile7 = Properties.Resources.Tile7;
            Image Tile8 = Properties.Resources.Tile8;

            //Other tile images
            Image TileUnknown = Properties.Resources.TileUnknown;
            Image TileEmpty = Properties.Resources.TileEmpty;
            Image TileFlag = Properties.Resources.TileFlag;
            Image TileMine = Properties.Resources.TileMine;
            Image TileExploded = Properties.Resources.TileExploded;


            Tile cell = tile;

            //Assigns each cell an image
            if (cell.revealed)
            {
                switch (cell.type)
                {
                    case Tile.Type.Empty: return TileEmpty;
                    case Tile.Type.Mine:
                        if (cell.exploded)
                        {
                            return TileExploded; 
                        }
                        else
                        {
                            return TileMine;
                        }
                    case Tile.Type.Number:
                        switch (cell.number)
                        {
                            case 1: return Tile1;
                            case 2: return Tile2;
                            case 3: return Tile3;
                            case 4: return Tile4;
                            case 5: return Tile5;
                            case 6: return Tile6;
                            case 7: return Tile7;
                            case 8: return Tile8;
                            default: return TileEmpty;
                        }
                    default: return TileEmpty;
                }
            }
            else if (cell.flagged)
            {
                return TileFlag;
            }
            else 
            {
                return TileUnknown;
            }
        }

        //New game button
        private void NewGame_Click(object sender, EventArgs e)
        {
            time.Enabled = false;
            bool valid = true;
            int inputMines = 0;
            int inputY = 0;
            int inputX = 0;

            //Makes sure inputted width length and # of mines are allowed
            if (!Int32.TryParse(SizeY.Text, out inputY) || inputY > 30 || inputY < 6)
            {
                valid = false;
                SizeY.Text = "NO";
            }
            if (!Int32.TryParse(SizeX.Text, out inputX) || inputX > 30 || inputX < 6)
            {
                valid = false;
                SizeX.Text = "NO";
            }
            if (!Int32.TryParse(MineNum.Text, out inputMines) || inputMines > (inputX * inputY) - 5 || inputMines < 1)
            {
                valid = false;
                MineNum.Text = "NO";
            }

            //Starts a new minesweeper game with chosen customizations
            if (valid)
            {
                width = inputX;
                height = inputY;
                mineNums = inputMines;

                for (int x = 0; x < boardWidth; x++)
                {
                    for (int y = 0; y < boardHeight; y++)
                    {
                        this.Controls.Remove(cells[x, y]);
                    }
                }
                GenerateBoard();
                LoadBoard();
            }
        }

        private void time_Tick(object sender, EventArgs e)
        {
            timer++;
            TimerUI.Text = timer.ToString();
        }
    }
}
