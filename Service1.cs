using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ComplianceWakeUp
{
    public partial class ComplyWakeUp : ServiceBase
    {
        public Timer tiempo;
        public ComplyWakeUp()
        {
            InitializeComponent();

            // Create a Timer object that knows to call our TimerCallback
            // method once every 2000 milliseconds.
            tiempo = new Timer();
            tiempo.Interval = 20000;
            tiempo.Elapsed += tiempo_Elapsed;
            tiempo.Start();
            if (!EventLog.SourceExists("WakeUpComply"))
            {
                EventLog.CreateEventSource("WakeUpComply", "Application");
            }

            EvLog.WriteEntry("inicio");
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }

        void tiempo_Elapsed(object sender, ElapsedEventArgs e)
        {
            // x++;
            //DataAccess.CMDataAccessServiceClient svc = new DataAccess.CMDataAccessServiceClient();
            //var r = svc.Setting_SelectCommandByID(null, null, string.Empty);
            //svc.Close();

            EvLog.WriteEntry("Consulta Comply: " + DateTime.Now);

            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }
    }
}
