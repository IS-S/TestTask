// See https://aka.ms/new-console-template for more information

using TestTask;

Console.WriteLine("Hello, World!");

bool finish = false;

ConsoleKeyInfo choice, scenario;

while(!finish)
{
    Console.WriteLine("Choose car type(1, 2 or 3). Tap F to finish:\n1. Sportcar\n2. Cargo car\n3. Passenger car");
    choice = Console.ReadKey();
    Console.WriteLine("\n");

    if(choice.Key.ToString()!= "D1" && choice.Key.ToString() != "D2" && choice.Key.ToString() != "D3" && choice.Key.ToString() != "F")
    {

        Console.WriteLine("Enter valid car type!");
        continue;
    }
    if (choice.Key.ToString() == "F")
    {
        finish = true;
        continue;
    }

    int range = 0;

    while(true)
    {
        Console.WriteLine("\nChoose what you want to calculate:\n1. Range\n2. Time Estimated");
        scenario = Console.ReadKey();

        if (scenario.KeyChar.ToString() == "1" || scenario.KeyChar.ToString() == "2")
        {
            if(scenario.KeyChar.ToString() == "2")
            {
                Console.WriteLine("Enter Range to calculate: ");
                Int32.TryParse(Console.ReadLine(), out range);
            }
            break;
        }
        else
        {
            Console.WriteLine("Choose 1 or 2");
        }
    }

    Console.WriteLine("Enter params:\nAverage Speed:");
    Int32.TryParse(Console.ReadLine(), out int avSpeed);
    Console.WriteLine("Enter params:\nAverage Consumption:");
    float.TryParse(Console.ReadLine(), out float averageConsumption);
    Console.WriteLine("Enter params:\nFuel left (Press Enter to calculate with Full Tank):");
    var enterRes = Int32.TryParse(Console.ReadLine(), out int fuelLeft);

    switch (choice.Key.ToString())
    {
        case "D1":
            
            try
            {
                var a = new Sportcar(avSpeed, averageConsumption, enterRes ? fuelLeft : null);
                Console.WriteLine(scenario.KeyChar.ToString() == "1" ? "Range is: " + a.Range() : "Time Estimated: " + a.timeEstimated(range));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            break;
        case "D2":

            Console.WriteLine("Enter planned Capacity:");

            Int32.TryParse(Console.ReadLine(), out int capacity);
            try
            {
                var b = new CargoBob(avSpeed, averageConsumption, enterRes ? fuelLeft : null, capacity);
                Console.WriteLine(scenario.KeyChar.ToString() == "1" ? "Range is: " + b.Range() : "Time Estimated: " + b.timeEstimated(range));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            break;
        case "D3":
            Console.WriteLine("Enter planned number of passengers:");

            Int32.TryParse(Console.ReadLine(), out int passengers);
            try
            {
                var b = new PassengerCar(avSpeed, averageConsumption, enterRes ? fuelLeft : null, passengers);
                Console.WriteLine(scenario.KeyChar.ToString() == "1" ? "Range is: " + b.Range() : "Time Estimated: " + b.timeEstimated(range));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        default:
            Console.WriteLine("Enter valid car type!");
            break;
    }
}

