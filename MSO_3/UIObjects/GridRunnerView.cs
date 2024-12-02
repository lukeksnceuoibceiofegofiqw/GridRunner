using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridRunner.Program;

namespace MSO_3
{   
    internal class GridRunnerView : Label
    {
        UIMediator med;
        public GridRunnerView(UIMediator med)
        {
            this.BackColor = Color.AntiqueWhite;
            this.med = med;
            Paint += (object? o, PaintEventArgs pea) => { Draw(pea.Graphics); };
        }

        void Draw(Graphics g)
        {
            State s = med.state;
            World w = s.world;
            int tileSize = Math.Min((Size.Width-1) / w.width, (Size.Height-1) / w.height);

            DrawSquares(g, tileSize, w);
            DrawLines(g, tileSize, w);
            DrawPath(g, s.path, tileSize);
            DrawCollision(g, s.error, tileSize);
            DrawGuy(g, s.guy, s.dir, tileSize);
            DrawFinish(g, s.Target(), tileSize);

        }

        void DrawSquares(Graphics g, int tileSize, World w)
        {


            for (int x = 0; x < w.width; x++) 
            {
                for (int y = 0; y < w.height; y++)
                {
                    int lightness = x % 2 + y % 2;
                    Color grass = Color.FromArgb(30+lightness*10, 160+lightness*30, 40+lightness*15);
                    g.FillRectangle(new SolidBrush(grass), x*tileSize, y*tileSize, tileSize, tileSize);
                    
                    if (w.obstructions[x, y])
                    {
                        g.DrawImage(AssetRepository.obstacle, new Rectangle(new(tileSize*x + (int)(0.05*tileSize),tileSize*y), new((int)(tileSize*0.9),tileSize)));
                    }
                }
            }
        }

        void DrawLines(Graphics g, int tileSize, World w)
        {
            for (int x = 0; x <= w.width; x++)
            {
                g.DrawLine(Pens.Black, new(tileSize * x, 0), new(tileSize * x, tileSize * w.height));
            }

            for (int y = 0; y <= w.height; y++)
            {
                g.DrawLine(Pens.Black, new(0, tileSize * y), new(tileSize * w.width, tileSize * y));
            }
        }

        void DrawGuy(Graphics g, Position p, Direction d, int tileSize)
        {
            int guySize = (int)(tileSize * 0.8);
            int guyoffset = (int)(0.1 * tileSize);
            int guyx = tileSize * p.x + guyoffset;
            int guyy = tileSize * p.y + guyoffset;
            Rectangle guyBoundingbox = new(new(guyx, guyy), new(guySize, guySize));
            g.FillEllipse(new SolidBrush(Color.FromArgb(30,30,200)), guyBoundingbox);

            int handSize = guySize / 3;
            Point hand1Pos = new Point();
            Point hand2Pos = new Point();

            switch (d.direction)
            {
                case "north":
                    {
                        hand1Pos = new Point(guyx,guyy);
                        hand2Pos = new Point(guyx + guySize-handSize,guyy);
                        break;
                    }
                case "east":
                    {
                        hand1Pos = new Point(guyx + guySize - handSize, guyy);
                        hand2Pos = new Point(guyx + guySize - handSize, guyy + guySize - handSize);
                        break;
                    }
                case "south":
                    {
                        hand1Pos = new Point(guyx + guySize - handSize, guyy + guySize - handSize);
                        hand2Pos = new Point(guyx, guyy + guySize - handSize);
                        break;
                    }
                case "west":
                    {
                        hand1Pos = new Point(guyx, guyy + guySize - handSize);
                        hand2Pos = new Point(guyx, guyy);
                        break;
                    }
                default:
                    {
                        throw new Exception("wtf, direction not directioning");
                    }
            }
            g.FillEllipse(Brushes.Black, new(hand1Pos, new(handSize, handSize)));
            g.FillEllipse(Brushes.Black, new(hand2Pos, new(handSize, handSize)));

        }

        void DrawFinish(Graphics g, Position p, int tileSize)
        {
             
            Point place = new(tileSize * p.x, tileSize * p.y);

            g.DrawImage(AssetRepository.Flag, new Rectangle(place, new(tileSize, tileSize)));
        }

        void DrawPath(Graphics g, List<Position> ps, int tileSize)
        {
            if (ps.Count < 2) return;
            Point[] ls = new Point[ps.Count];
            for (int i = 0; i < ps.Count;i++)
            {
                ls[i] = new Point(ps[i].x*tileSize + tileSize/2, ps[i].y*tileSize + tileSize/2);
            }
            
            g.DrawLines(new Pen(Color.Purple,5), ls);
        }


        void DrawCollision(Graphics g, RunError? err, int tileSize)
        {
            if (err == null) return;
            if (!(err is CollisionError)) return;

            Position pos = ((CollisionError)err).beforeCollisionPosition;
            Direction dir = ((CollisionError)err).beforeCollisionDirection;

            Point p = new();

            switch ( dir.direction )
            {
                case "north":
                    {
                        p = new(pos.x*tileSize,pos.y*tileSize - tileSize/2);
                    }
                    break;
                case "east":
                    {
                        p = new(pos.x * tileSize + tileSize/2, pos.y * tileSize);
                    }
                    break;
                case "south":
                    {
                        p = new(pos.x * tileSize, pos.y * tileSize + tileSize/2);
                    }
                    break;
                case "west":
                    {
                        p = new(pos.x * tileSize - tileSize/2, pos.y * tileSize);
                    }
                    break;
                default:
                    {
                        throw new Exception("not a valid direction");
                    }
            }


            g.DrawImage(AssetRepository.Biem, new Rectangle(p, new(tileSize,tileSize)));



        }

    }
}

