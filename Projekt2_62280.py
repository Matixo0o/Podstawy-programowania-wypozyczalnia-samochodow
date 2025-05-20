class Car:
    def __init__(self, brand, model, car_type, price_per_day):
        self.brand = brand
        self.model = model
        self.car_type = car_type
        self.price_per_day = price_per_day

    def __str__(self):
        return f"{self.brand} {self.model} ({self.car_type}) - {self.price_per_day} zł/dzień"


class Customer:
    def __init__(self, name):
        self.name = name

    def __str__(self):
        return f"{self.name}"


class Rental:
    def __init__(self, customer, car, days):
        self.customer = customer
        self.car = car
        self.days = days

    def calculate_cost(self):
        return self.days * self.car.price_per_day

    def reservation_summary(self):
        return (f"\n--- Podsumowanie Rezerwacji ---\n"
                f"Klient: {self.customer}\n"
                f"Samochód: {self.car}\n"
                f"Liczba dni: {self.days}\n"
                f"Koszt całkowity: {self.calculate_cost()} zł\n")


def show_menu(cars):
    print("=== Dostępne samochody ===")
    for idx, car in enumerate(cars):
        print(f"{idx + 1}. {car}")


def main():
    cars = [
        Car("AUDI", "RS3 8Y", "SEDAN", 899),
        Car("Mercedes", "A200", "SEDAN", 299),
        Car("Mercedes ", "G63 AMG", "SUV", 2799),
        Car("BMW", "M240i", "COUPE", 799),
        Car("BMW", "X7", "SUV", 1299),
        Car("Volkswagen", "Golf 7R", "Hatchback", 549)
    ]

    name = input("Podaj imię i nazwisko klienta: ")
    customer = Customer(name)

    show_menu(cars)
    choice = int(input("Wybierz numer samochodu: ")) - 1

    if choice < 0 or choice >= len(cars):
        print("Nieprawidłowy wybór.")
        return

    days = int(input("Podaj liczbę dni wynajmu: "))
    rental = Rental(customer, cars[choice], days)

    print(rental.reservation_summary())


if __name__ == "__main__":
    main()
