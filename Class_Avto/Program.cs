using Class_Avto;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество топлива в баке (до 80): ");
        double topliva;
        while (!double.TryParse(Console.ReadLine(), out topliva) || topliva <= 0 || topliva > 80)
        {
            Console.WriteLine("Введите корректное количество топлива (от 0 до 80): ");
        }
        Console.WriteLine("Введите расход топлива на 100 км: ");
        double topliva_rasxod;
        while (!double.TryParse(Console.ReadLine(), out topliva_rasxod) || topliva_rasxod <= 0 || topliva_rasxod > 100)
        {
            Console.WriteLine("Введите корректный расход топлива (от 0 до 100): ");
        }
        Class_Auto[] m = new Class_Auto[3];
        Console.WriteLine("Выберите машину: ");
        Console.WriteLine("1. Mers-Benz");
        Console.WriteLine("2. BMW");
        Console.WriteLine("3. Трактор");

        int vibor;
        while (!int.TryParse(Console.ReadLine(), out vibor) || vibor < 1 || vibor > 3)
        {
            Console.WriteLine("Введите корректный номер машины (от 1 до 3): ");
        }

        int index = vibor - 1;
        m[index] = new Class_Auto("777", topliva, topliva_rasxod);

        Class_Auto car = m[index];

        while (true)
        {
            int distance = new Random().Next(1, 101);
            Console.WriteLine($"\nПри начальной скорости 60 км/ч - количество топлива в баке {topliva} л и расход {topliva_rasxod} л/100км.");
            Console.WriteLine("Увеличиваем скорость или тормозим? (для разгона введите положительное число, для торможения - отрицательное.)");

            double speedChange;
            while (!double.TryParse(Console.ReadLine(), out speedChange))
            {
                Console.WriteLine("Введите корректное значение для изменения скорости: ");
            }

            car.MOVE(distance);

            Console.WriteLine($"Путь до места назначения составил: {distance} км");

            Console.WriteLine("Поездка завершена. Желаете продолжить? (да/нет)");
            string continueTrip = Console.ReadLine();

            car.Proidenei_put(distance);

            if (continueTrip.ToLower() != "да")
            {
                Console.WriteLine($"Общий пробег: {car.Get_obshee_rasstoyanie()} км");
                break;
            }
        }
    }
}