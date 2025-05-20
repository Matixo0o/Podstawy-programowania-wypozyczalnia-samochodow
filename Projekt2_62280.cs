using System;


public class Car
{
    public string Brand { get; }
    public string Model { get; }
    public string CarType { get; }
    public decimal PricePerDay { get; }

    public Car(string brand, string model, string carType, decimal pricePerDay)
    {
        Brand = brand;
        Model = model;
        CarType = carType;
        PricePerDay = pricePerDay;
    }

    public override string ToString()
    {
        return $"{Brand} {Model} ({CarType}) - {PricePerDay} zł/dzień";
    }
}

public class Customer
{
    public string Name { get; }

    public Customer(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}

public class Rental
{
    public Customer Customer { get; }
    public Car Car { get; }
    public int Days { get; }

    public Rental(Customer customer, Car car, int days)
    {
        Customer = customer;
        Car = car;
        Days = days;
    }

    public decimal CalculateCost()
    {
        return Days * Car.PricePerDay;
    }

    public void PrintSummary()
    {
        Console.WriteLine("\n--- Podsumowanie Rezerwacji ---");
        Console.WriteLine($"Klient: {Customer}");
        Console.WriteLine($"Samochód: {Car}");
        Console.WriteLine($"Liczba dni: {Days}");
        Console.WriteLine($"Koszt całkowity: {CalculateCost()} zł");
    }
}

class Program
{
    static void Main()
    {
        List<Car> cars = new List<Car>
        {
        new Car("AUDI", "RS3 8Y", "SEDAN", 899),
        new Car("Mercedes", "A200", "SEDAN", 299),
        new Car("Mercedes ", "G63 AMG", "SUV", 2799),
        new Car("BMW", "M240i", "COUPE", 799),
        new Car("BMW", "X7", "SUV", 1299),
        new Car("Volkswagen", "Golf 7R", "Hatchback", 549)
        };

        Console.Write("Podaj imię i nazwisko klienta: ");
        string name = Console.ReadLine();
        Customer customer = new Customer(name);

        Console.WriteLine("\n=== Dostępne samochody ===");
        for (int i = 0; i < cars.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {cars[i]}");
        }

        Console.Write("Wybierz numer samochodu: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice < 0 || choice >= cars.Count)
        {
            Console.WriteLine("Nieprawidłowy wybór.");
            return;
        }

        Console.Write("Podaj liczbę dni wynajmu: ");
        int days = int.Parse(Console.ReadLine());

        Rental rental = new Rental(customer, cars[choice], days);
        rental.PrintSummary();
    }
}
