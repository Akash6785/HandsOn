using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Timers;
//using Timer = System.Timers.Timer;

namespace WindowsServiceHandsOn
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        Log log = new Log();
        DateTime selected_time;
        //readonly DateTime selected_time;
        // Timer timer = new Timer();

        public Service1()
        {
            InitializeComponent();
            selected_time = DateTime.Now.AddSeconds(15);
        }

        protected override void OnStart(string[] args)
        {
            

            log.writeEventLog("Activity started at at " + DateTime.Now.ToString());
            
            this.timer.Elapsed += new ElapsedEventHandler(this.timer_tick);

            this.timer.Interval = 10000;

            this.timer.Enabled = true;


        }

        private void timer_tick(object sender, ElapsedEventArgs e)
        {
            
            if (DateTime.Now > selected_time)
            {

                log.writeEventLog("Activity Resumed at " + DateTime.Now.ToString());
            }
           
        }


        protected override void OnStop()
        {
            timer.Stop();
            timer = null;
        }
    }
}

