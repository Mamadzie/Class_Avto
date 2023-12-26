using System;

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
                Console.WriteLine($"Топливо успешно заправлено. Текущий бак: {this.topliva:f2}  л");
            }
            else
            {
                Console.WriteLine("Ошибка! Нельзя заправить отрицательное количество топлива или ничего не ввести.");
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
            Console.Clear();
            double rasstoyanie = km;
            double Ostavshie_topliva = this.topliva - (rasstoyanie * this.rasxod / 100);

            if (Ostavshie_topliva >= 0)
            {
                Console.WriteLine("Вы доехали!");
                this.Tekushee_rasstoyanie += rasstoyanie;
                this.topliva = Ostavshie_topliva;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Если вы хотите продолжить путишествие, введите, сколько литров вы хотите заправить: ");
                double additionalFuel = 0;
                if (double.TryParse(Console.ReadLine(), out additionalFuel))
                {
                    if (additionalFuel >= 0)
                    {
                        Zapravka(additionalFuel);
                        Ostavshie_topliva = this.topliva - (rasstoyanie * this.rasxod / 100);

                        if (Ostavshie_topliva >= 0)
                        {
                            Console.WriteLine($"Вы смогли доехать до места назначения и в баке осталось: { Ostavshie_topliva}");
                            this.topliva = Ostavshie_topliva;
                        }
                        else
                        {
                            double trebuyemaya_topliva = Math.Abs(Ostavshie_topliva);
                            Console.WriteLine($"Вам не хватило топлива до места назначения. Вам нужно было заправить ещё {trebuyemaya_topliva:f2} литров");
                            this.Tekushee_rasstoyanie -= rasstoyanie;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Нельзя заправить отрицательное количество топлива.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Некорректный ввод.");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Текущий топлива: {this.topliva:f2}");
            Console.ForegroundColor = ConsoleColor.White;
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