using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_lesson2
{
    public abstract class MusicalInstrument
    {
        protected string _name;
        protected string _description;

        public MusicalInstrument(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public abstract void Show();

        public abstract void Desc();

        public abstract void History();

        public abstract void Sound();

        public void DisplayInfo()
        {
            Show();
            Desc();
            Sound();
            History();
        }
    }

    public class Violin : MusicalInstrument
    {
        public Violin() : base("Violin", "[Violin description]")
        {

        }

        public override void Show()
        {
            Console.WriteLine($"Instrument: {base._name}");
        }

        public override void Desc()
        {
            Console.WriteLine($"Description: {base._description}");
        }


        public override void Sound()
        {
            Console.WriteLine("Sound: [Violin sound]");
        }

        public override void History()
        {
            Console.WriteLine("Histoty: [Violin histrory]");
        }
    }

    public class Trombone : MusicalInstrument
    {
        public Trombone() : base("Trombone", "[Trombone description]")
        {

        }

        public override void Show()
        {
            Console.WriteLine($"Instrument: {base._name}");
        }

        public override void Desc()
        {
            Console.WriteLine($"Description: {base._description}");
        }

        public override void Sound()
        {
            Console.WriteLine("Sound: [Trombone sound]");
        }

        public override void History()
        {
            Console.WriteLine("Histoty: [Trombone hisrtoy]");
        }
    }

    public class Ukulele : MusicalInstrument
    {
        public Ukulele() : base("Ukulele", "[Ukulele description]")
        {

        }

        public override void Show()
        {
            Console.WriteLine($"Instrument: {base._name}");
        }

        public override void Desc()
        {
            Console.WriteLine($"Description: {base._description}");
        }

        public override void Sound()
        {
            Console.WriteLine("Sound: [Ukulele sound]");
        }

        public override void History()
        {
            Console.WriteLine("Histoty: [Ukulele hisrtoy]");
        }
    }

    public class Cello : MusicalInstrument
    {
        public Cello() : base("Cello", "[Cello description]")
        {

        }

        public override void Show()
        {
            Console.WriteLine($"Instrument: {base._name}");
        }

        public override void Desc()
        {
            Console.WriteLine($"Description: {base._description}");
        }

        public override void Sound()
        {
            Console.WriteLine("Sound: [Cello sound]");
        }

        public override void History()
        {
            Console.WriteLine("Histoty: [Cello history]");
        }
    }

    public static class TaskTest2
    {
        public static void StartTest()
        {

            MusicalInstrument violin = new Violin();
            violin.DisplayInfo();

            Console.WriteLine();

            MusicalInstrument trombone = new Trombone();
            trombone.DisplayInfo();

            Console.WriteLine();

            MusicalInstrument ukulele = new Ukulele();
            ukulele.DisplayInfo();

            Console.WriteLine();

            MusicalInstrument cello = new Cello();
            cello.DisplayInfo();

        }
    }
}
