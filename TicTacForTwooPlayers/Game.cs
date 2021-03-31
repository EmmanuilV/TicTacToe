using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Documents
{
    class Game
    {
        private const string O = "O";
        private const string X = "X";
        private string xo = O;
        private bool checking = true;

        public bool Checking
        {
            get
            {
                return checking;
            }
        }

/*         public void ChoosePlayer(NetworkStream stream1, NetworkStream stream2)
        {
            stream1 = 
        } */
        public string WinCheck(string[] pos)
        {
            string status = $"{xo} Win!";

            if (pos[0] == pos[1] && pos[0] == pos[2] && pos[0] != "")
            {
                checking = false;
            }
            else if (pos[0] == pos[4] && pos[0] == pos[8] && pos[0] != "")
            {
                checking = false;
            }
            else if (pos[0] == pos[3] && pos[0] == pos[6] && pos[0] != "")
            {
                checking = false;
            }
            else if (pos[8] == pos[7] && pos[8] == pos[6] && pos[8] != "")
            {
                checking = false;
            }
            else if (pos[2] == pos[4] && pos[2] == pos[6] && pos[2] != "")
            {
                checking = false;
            }
            else if (pos[1] == pos[4] && pos[1] == pos[7] && pos[1] != "")
            {
                checking = false;
            }
            else if (pos[3] == pos[4] && pos[3] == pos[5] && pos[3] != "")
            {
                checking = false;
            }
            else if (pos.Length == 9)
            {
                int sum = 0;
                for (int i = 0; i < pos.Length; i++)
                {
                    if (pos[i] == "")
                    {
                        sum += 1;
                    }
                    else
                    {
                        continue;
                    }

                }
                if (sum == 0)
                {
                    status = "Draw!!";
                    checking = false;
                }
                else
                {
                    status = "The game continues!";
                }
            }
            else
            {
                status = "The game continues!";
            }

            return status;
        }
        public void RenamePlayer()
        {
            if (xo == X)
            {
                xo = O;
            }
            else
            {
                xo = X;
            }
        }
        public void Choose(string[] pos, int choose)
        {
            if (pos[choose] == "")
            {
                RenamePlayer();
                pos[choose] = xo;
            }
        }
    }
}