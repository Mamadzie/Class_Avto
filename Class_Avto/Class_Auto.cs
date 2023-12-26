using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Avto
{
    internal class Class_Auto
    {
        private string number;
        private double topliva;
        private double rasxod;
        private double Tekushee_rasstoyanie = 0; // для текущего пройденного пути

        public Class_Auto(string number, double topliva, double rasxod)
        {
            this.number = number;
            this.topliva = topliva;
            this.rasxod = rasxod;
        }

        public void info()
        {
            Console.WriteLine("Номер: " + number);
            Console.WriteLine("Топливо: " + topliva);
            Console.WriteLine("Расход: " + rasxod);
        }


        public void Zapravka(double top)
        {
            if (top > 0)
            {
                this.topliva += top;
                Console.WriteLine("Топливо успешно заправлено. Текущий бак: " + (this.topliva += top) + " л");
            }
            else
            {
                Console.WriteLine("Ошибка! Нельзя заправить отрицательное количество топлива.");
            }
        }


        public void Proidenei_put(double rasstoyanie)
        {
            this.Tekushee_rasstoyanie += rasstoyanie;
        }

        public void Otobrojenie_rasstoyanie()
        {
            Console.WriteLine("Текущий пробег: " + this.Tekushee_rasstoyanie + " км");
        }

        private void Move(int km)
        {
            double temp_Flow = this.rasxod;
            double rasstoyanie = km;

           double Ostavshie_topliva = this.topliva - (rasstoyanie * (this.rasxod) / 100);

            if (Ostavshie_topliva >= 0)
            {
                Console.WriteLine("Вы доехали!");
                this.Tekushee_rasstoyanie += rasstoyanie;

                // Обновляем оставшееся топливо
                this.topliva = Ostavshie_topliva;
            }
            else
            {
                Console.WriteLine("Если не хотите дальше пешком, введите, сколько литров вы хотите заправить: ");
                Zapravka(double.Parse(Console.ReadLine()));
                Ostavshie_topliva = this.topliva - (rasstoyanie * (this.rasxod) / 100);

                if (Ostavshie_topliva >= 0)
                {
                    Console.WriteLine("Вы смогли доехать до места назначения и в баке осталось: " + Ostavshie_topliva);
                }
                else
                {
                    double trebuyemaya_topliva = Math.Abs(Ostavshie_topliva);
                    Console.WriteLine("Вам не хватило топлива до места назначения. Вам нужно было заправить ещё  " + trebuyemaya_topliva + " литров");
                    this.Tekushee_rasstoyanie -= rasstoyanie;
                }
            }
            // Обновляем оставшееся топливо
            double update = this.topliva - (rasstoyanie * (this.rasxod) / 100);
            Console.WriteLine("Текущий топлива: " + update);

            this.Tekushee_rasstoyanie += rasstoyanie;
            if (update <= 0)
            {
                Console.WriteLine("Путишествие закончено.Всего Хорошего");
                Environment.Exit(0);
                Console.ReadKey();
            }
            
        }


        public void MOVE(int km)
        {
            Move(km);
        }

        public double Get_obshee_rasstoyanie()
        {
            return this.Tekushee_rasstoyanie;
        }
    }
}
