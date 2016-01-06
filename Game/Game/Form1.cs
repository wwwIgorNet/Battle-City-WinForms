using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        BattleCity battleCity;
        public Form1()
        {
            InitializeComponent();

            battleCity = new BattleCity(this);
            battleCity.Play();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Left)
                Keyboard.Left = true;
            else if (e.KeyCode == Keys.Right)
                Keyboard.Right = true;
            else if (e.KeyCode == Keys.Up)
                Keyboard.Up = true;
            else if (e.KeyCode == Keys.Down)
                Keyboard.Down = true;
            else if (e.KeyCode == Keys.Space)
                Keyboard.Space = true;
            else if (e.KeyCode == Keys.Enter)
                Keyboard.Enter = true;
            else if (e.KeyCode == Keys.Escape)
                Keyboard.Escape = true;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyCode == Keys.Left)
                Keyboard.Left = false;
            else if (e.KeyCode == Keys.Right)
                Keyboard.Right = false;
            else if (e.KeyCode == Keys.Up)
                Keyboard.Up = false;
            else if (e.KeyCode == Keys.Down)
                Keyboard.Down = false;
            else if (e.KeyCode == Keys.Space)
                Keyboard.Space = false;
            else if (e.KeyCode == Keys.Enter)
                Keyboard.Enter = false;
            else if (e.KeyCode == Keys.Escape)
                Keyboard.Escape = false;
        }
    }
}
