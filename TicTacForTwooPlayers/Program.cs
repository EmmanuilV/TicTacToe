using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Documents
{
    class Program
    {

        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                IPAddress localAddr = IPAddress.Parse(args[0]);
                Int32 port = Int32.Parse(args[1]);

                server = new TcpListener(localAddr, port);

                server.Start();


                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    TcpClient client1 = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    TcpClient client2 = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    Game game = new Game();
                    Field field = new Field();
                    string[] positions = new string[9] { "", "", "", "", "", "", "", "", "" };
                    while (game.Checking)
                    {
                        NetworkStream stream = client1.GetStream();
                        StreamReader reader = new StreamReader(stream);
                        StreamWriter writer = new StreamWriter(stream);
                        writer.AutoFlush = true;

                        writer.WriteLine("Enter the position number: ");
                        int chooseCell = int.Parse(reader.ReadLine());

                        if (chooseCell < 0 || chooseCell > 8)
                        {
                            while (true)
                            {
                                writer.WriteLine("Enter number from 0 to 8");
                                chooseCell = int.Parse(reader.ReadLine());
                                if (chooseCell >= 0 && chooseCell <= 8)
                                {
                                    game.Choose(positions, chooseCell);
                                    game.RenamePlayer();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            game.Choose(positions, chooseCell);
                            game.RenamePlayer();
                        }
                        field.PlayField(positions);
                        game.RenamePlayer();
                        writer.WriteLine(game.WinCheck(positions));
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();

        }

    }
}

