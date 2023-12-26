using Class_Avto;
using System;


class Program
{
    static void Main(string[] args)
    {
        double topliva;
        Console.WriteLine("Введите количество топлива в баке до(80): ");
        double.TryParse(Console.ReadLine(), out topliva);

        while (topliva <= 0 || topliva > 80)
        {
            Console.WriteLine("Введите заново(больше 80 нельзя)");
            double.TryParse(Console.ReadLine(), out topliva);
        }

        double topliva_rasxod;
        Console.WriteLine("Введите расход топлива на 100км:");
        double.TryParse(Console.ReadLine(), out topliva_rasxod);

        while (topliva_rasxod <= 0 || topliva_rasxod > 100)
        {
            Console.WriteLine("Введите заново(больше 100 нельзя)");
            double.TryParse(Console.ReadLine(), out topliva_rasxod);
        }
        Class_Auto[] m = new Class_Auto[3];

        Console.WriteLine("  Выберите машину: ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("1.Mers-Benz");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("2.BMW");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("3.Трактор");
        Console.ForegroundColor = ConsoleColor.White;

        int vibor = Convert.ToInt32(Console.ReadLine());
        int index = 0;
        switch (vibor)
        {
            case 1:
                m[0] = new Class_Auto("777", topliva, topliva_rasxod);
                index = 0;
                break;
            case 2:
                m[1] = new Class_Auto("666", topliva, topliva_rasxod);
                index = 1;
                break;
            case 3:
                m[2] = new Class_Auto("555", topliva, topliva_rasxod);
                index = 2;
                break;
        }

        Class_Auto car = m[index];

        while (true)
        {
            double speed = 60;
            Console.WriteLine("\n");
            Console.WriteLine($"При начальном скоросте {speed} км/ч - количество топлива в баке {topliva}л и  расход {topliva_rasxod} л/100км.");
            Console.WriteLine("Увеличиваем скорость или тормозим? (для разгона введите положительное число, для торможения - отрицательное.)");
            double speed_Chang = double.Parse(Console.ReadLine());

            double Potreblenie = topliva_rasxod; // начальный расход

            if (speed_Chang > 0)
            {
                // Увеличиваем скорость
                while (speed < (60 + speed_Chang))
                {
                    speed += 1;
                    Potreblenie += 0.1;
                    Console.Clear();
                    Console.WriteLine("Скорость: " + speed);
                }
            }
            else if (speed_Chang < 0)
            {
                // Уменьшаем скорость
                while (speed > (60 + speed_Chang))
                {
                    if (speed <= 1)
                    {
                        Console.WriteLine("Ошибка в торможении. Скорость не может быть меньше 1. Считаем, что вы ввели 0.");
                        speed = 0.1;
                        Potreblenie = 4;
                        break;
                    }
                    else
                    {
                        speed -= 1;
                        Potreblenie -= 0.1;
                        Console.Clear();
                        Console.WriteLine("Скорость: " + speed);
                    }
                }
            }

            Random random = new Random();
            int rasstoyanie = random.Next(1, 100); // Случайное расстояние от 1 до 100 км
            Console.WriteLine("Путь до места назначения составило: " + rasstoyanie + " km");

            car.MOVE(rasstoyanie);

            Console.WriteLine("Поездка завершена. Желаете продолжить? (да/нет)");
            string continueTrip = Console.ReadLine();

            car.Proidenei_put(rasstoyanie);

            if (continueTrip.ToLower() == "нет")
            {
                Console.WriteLine("Общий пробег: " + car.Get_obshee_rasstoyanie() + " km");
                break;
            }

        }
    }
}