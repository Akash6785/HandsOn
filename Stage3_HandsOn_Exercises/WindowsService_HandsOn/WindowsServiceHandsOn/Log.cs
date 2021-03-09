using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceHandsOn
{

    public class Log
    {
        
        public void writeEventLog(String Message)
        {
            StreamWriter s = null;
          //  StreamWriter t = null;
            {
                try
                {
                    string Date = System.DateTime.Now.ToString("dd-MM-yyy");
                    
                    s = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\File\\WindowsServiceHandsOn.txt", true);
                   // if (DateTime.Now >= selected_time)
                        s.WriteLine(Message);
                    
                        s.Flush();
                        s.Close();
                    }
                



                catch (Exception)
                {

                }
            }
        }
    }
}

       

