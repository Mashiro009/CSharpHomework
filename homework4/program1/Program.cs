using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace program1
{
    //声明事件参数类型
    public class ClockEventArgs : EventArgs
    {

    }

    //声明委托类型
    public delegate void ClockEventHandler(object sender, ClockEventArgs e);
    //定义闹钟
    public class AlarmClock
    {
        //声明事件
        public event ClockEventHandler Alarm;

        public void DoAlarm()
        {
            if (Alarm != null)
            {
                ClockEventArgs clock = new ClockEventArgs();
                Alarm(this, clock);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DateTime Alarm = input();
            DateTime now = DateTime.Now;
            //Console.WriteLine("现在是:" + now.ToShortTimeString().ToString());
            while (now < Alarm) 
            {
                Thread.Sleep(6000);//六秒刷新一次
                now = DateTime.Now;
                //Console.WriteLine("现在是:" + now.ToShortTimeString().ToString());
            }
            AlarmClock alarmClock = new AlarmClock();
            alarmClock.Alarm += alarm;
            alarmClock.DoAlarm();
            Console.ReadKey();
        }

        public static void alarm(object sender, ClockEventArgs e)
        {
            Console.WriteLine("Ring!!!!");
        }

        public static DateTime input()
        {

            Console.Write("请输入闹钟的小时：");
            int h = Int32.Parse(Console.ReadLine());
            while (h < 0 || h > 23)
            {
                Console.Write("你输入有误请重新输入小时：");
                h = Int32.Parse(Console.ReadLine());
            }
            Console.Write("请输入闹钟的分钟：");
            int min = Int32.Parse(Console.ReadLine());
            while (min < 0 || min > 59)
            {
                Console.Write("你输入有误请重新输入分钟：");
                min = Int32.Parse(Console.ReadLine());
            }
            string str = h.ToString() + ":" + min.ToString();
            DateTime dateTime = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dateTime += new TimeSpan(h, min, 0);
            Console.WriteLine("闹钟的时间是：" + dateTime.ToShortTimeString().ToString());
            return dateTime;
        }

    }
    
}
