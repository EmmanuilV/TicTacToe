using System;

namespace Documents
{
    class Field
    {
        public void PlayField(string[] pos)
        {
            Console.WriteLine("   {0} |  {1}  |  {2}   ", pos[0], pos[1], pos[2]);
            Console.WriteLine("--------------");
            Console.WriteLine("   {0} |  {1}  |  {2}   ", pos[3], pos[4], pos[5]);
            Console.WriteLine("--------------");
            Console.WriteLine("   {0} |  {1}  |  {2}   ", pos[6], pos[7], pos[8]);
        }
    }
}