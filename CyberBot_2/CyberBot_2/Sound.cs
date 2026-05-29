using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

public class Sound
{
    public static void Play()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("C:\\Users\\Student\\source\\repos\\CyberBot\\CyberBot\\greeting.wav");
            player.PlaySync();
        }
        catch (Exception ex)
        {
            {
                Console.WriteLine("(Sound file not playing :" + ex.Message);
            }
        }
    }
    public static void Stop()
    {
    }
}



