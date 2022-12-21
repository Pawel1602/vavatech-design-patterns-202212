using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Threading;

namespace ObserverPattern
{
    public interface IObservationService
    {
        IEnumerable<Observation> Get();
    }

    public class FakeObservationService : IObservationService
    {
        public IEnumerable<Observation> Get()
        {
            yield return new Observation { Country = "China", Confirmed = 2 };
            yield return new Observation { Country = "Germany", Confirmed = 1 };
            yield return new Observation { Country = "China", Confirmed = 20 };
            yield return new Observation { Country = "Germany", Confirmed = 60, Recovered = 4, Deaths = 2 };
            yield return new Observation { Country = "Poland", Confirmed = 10, Recovered = 5 };
            yield return new Observation { Country = "China", Confirmed = 30 };
            yield return new Observation { Country = "Poland", Confirmed = 50, Recovered = 15 };
            yield return new Observation { Country = "US", Confirmed = 10, Recovered = 5, Deaths = 1 };
            yield return new Observation { Country = "US", Confirmed = 11, Recovered = 3, Deaths = 4 };
            yield return new Observation { Country = "Poland", Confirmed = 45, Recovered = 25 };
            yield return new Observation { Country = "Germany", Confirmed = 52, Recovered = 4, Deaths = 1 };
        }
    }

    public class Observation
    {
        public string Country { get; set; }
        public int Confirmed { get; set; }
        public int Recovered { get; set; }
        public int Deaths { get; set; }

        public override string ToString()
        {
            return $"{Country} {Confirmed}/{Recovered}/{Deaths}";
        }
    }

    // Hot source

    // Cold source
    public class Covid19ColdObservable : IObservable<Observation>
    {
        private List<IObserver<Observation>> observers;

        private IObservationService service;

        public Covid19ColdObservable(IObservationService service)
        {
            this.service = service;
        }

        public IDisposable Subscribe(IObserver<Observation> observer)
        {
            var observations = service.Get();

            foreach (var observation in observations)
            {
                observer.OnNext(observation);
            }

            return null;
           
        }
    }

    public class ConsoleObserver : IObserver<Observation>
    {
        public void OnCompleted()
        {
            Console.WriteLine("KONIEC.");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error.Message);
        }

        public void OnNext(Observation value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"ALERT {value}");
            Console.ResetColor();
            
        }
    }


    // RX Library

    // Reaktywne Programowanie


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Observer Pattern!");

            // ObserverCovid19Test();

            // Covid19Test();

            //  CpuTest();

            ObservableCpuTest();

            //  WheaterForecastTest();
        }

        private static void WheaterForecastTest()
        {
            WheaterForecast wheaterForecast = new WheaterForecast();

            while (true)
            {
                wheaterForecast.GetChanges();

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        #region COVID

        // button.mouseclick += (s, e.PressButton == LeftButton) => { ... }

        private static void ObserverCovid19Test()
        {
            IObservationService observationService = new FakeObservationService();
            var source = new Covid19ColdObservable(observationService);

            // dotnet add package System.Reactive.Linq
            var polandSource = source
                .Where(p=>p.Country == "Poland")
                .Where(p => p.Confirmed > 30);


            var germanySource = source
               .Where(p => p.Country == "Germany")
               .Where(p => p.Confirmed > 10);

            var observer1 = new ConsoleObserver();

            germanySource.Subscribe(observer1);

        }

        private static void Covid19Test()
        {
            IObservationService observationService = new FakeObservationService();

            var observations = observationService.Get();

            foreach (Observation observation in observations)
            {
                Console.WriteLine(observation);

                if (observation.Country == "Poland" && observation.Confirmed > 30)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Poland ALERT");
                    Console.ResetColor();
                }

                if (observation.Country == "Germany" && observation.Confirmed > 10)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Germany ALERT");
                    Console.ResetColor();
                }
                
            }
        }



       

       

        #endregion

        #region CPU
        private static void CpuTest()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            while (true)
            {
                float cpu = cpuCounter.NextValue();

                if (cpu < 30)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine($"CPU {cpu} %");
                    Console.ResetColor();
                }
                else
                if (cpu > 50)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"CPU {cpu} %");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"CPU {cpu} %");
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        private static void ObservableCpuTest()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            IObservable<float> source = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(p=>cpuCounter.NextValue());

            source.Where(cpu => cpu < 10)
                .Subscribe(new CpuConsoleObserver(ConsoleColor.Green));


            source.Where(cpu => cpu > 30)
                .Subscribe(new CpuConsoleObserver(ConsoleColor.Red));

            Console.ReadKey();


        }


        public class CpuConsoleObserver : IObserver<float>
        {
            private readonly ConsoleColor color;

            public CpuConsoleObserver(ConsoleColor color)
            {
                this.color = color;
            }

            public void OnCompleted()
            {
                throw new NotImplementedException();
            }

            public void OnError(Exception error)
            {
                throw new NotImplementedException();
            }

            public void OnNext(float value)
            {
                Console.BackgroundColor = color;
                Console.WriteLine($"CPU {value} %");
                Console.ResetColor();
            }
        }


        #endregion

        #region WheaterForecast

        public class WheaterForecast
        {
            private Random random = new Random();

            private int GetTemperature()
            {
                return random.Next(-20, 40);
            }

            private int GetPreasure()
            {
                return random.Next(900, 1200);
            }


            private double GetHumidity()
            {
                return random.NextDouble();
            }

            public void GetChanges()
            {
                int temperature = GetTemperature();
                int preasure = GetPreasure();
                double humidity = GetHumidity();

                DisplayCurrrent(temperature, preasure, humidity);
                DisplayForecast(temperature, preasure, humidity);
                DisplayStatistics(temperature, preasure, humidity);
            }

            private void DisplayCurrrent(int temperature, int preasure, double humidity)
            {
                System.Console.WriteLine($"Current Wheather: {temperature}C {preasure}hPa {humidity:P2}");
            }

            private void DisplayForecast(int temperature, int preasure, double humidity)
            {
                System.Console.WriteLine($"Statistics Wheather: {temperature}C {preasure}hPa {humidity:P2}");
            }

            private void DisplayStatistics(int temperature, int preasure, double humidity)
            {
                System.Console.WriteLine($"Statistics Wheather: {temperature}C {preasure}hPa {humidity:P2}");
            }


        }

        #endregion

    }



}
