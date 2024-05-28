using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab6CSharp
{
    // Інтерфейс для базових властивостей місця
    public interface ILocation
    {
        string Name { get; set; }
        void Show();
    }

    // Інтерфейс для областей
    public interface IRegion : ILocation
    {
        List<City> Cities { get; set; }
    }

    // Інтерфейс для міст
    public interface ICity : ILocation
    {
        int Population { get; set; }
    }

    // Інтерфейс для мегаполісів
    public interface IMetropolis : ICity
    {
        List<City> Cities { get; set; }
    }

    // Базовий клас для місця
    public class Place : ILocation
    {
        public string Name { get; set; }

        public Place(string name)
        {
            Name = name;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Place: {Name}");
        }
    }

    // Клас для областей
    public class Region : Place, IRegion
    {
        public List<City> Cities { get; set; }

        public Region(string name) : base(name)
        {
            Cities = new List<City>();
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Region contains cities:");
            foreach (var city in Cities)
            {
                Console.WriteLine($"  - {city.Name}");
            }
        }
    }

    // Клас для міст
    public class City : Place, ICity
    {
        public int Population { get; set; }

        public City(string name, int population) : base(name)
        {
            Population = population;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"City Population: {Population}");
        }
    }

    // Клас для мегаполісів
    public class Metropolis : City, IMetropolis
    {
        public List<City> Cities { get; set; }

        public Metropolis(string name, int population) : base(name, population)
        {
            Cities = new List<City>();
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Metropolis contains cities:");
            foreach (var city in Cities)
            {
                Console.WriteLine($"  - {city.Name} (Population: {city.Population})");
            }
        }
    }

    // Інтерфейс для телефонного довідника
    public interface IPhoneDirectory
    {
        void DisplayInfo();
        bool MatchesCriteria(string searchCriteria);
    }

    // Клас Персона
    public class Person : IPhoneDirectory
    {
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Person(string surname, string address, string phoneNumber)
        {
            Surname = surname;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Person: {Surname}, Address: {Address}, Phone: {PhoneNumber}");
        }

        public virtual bool MatchesCriteria(string searchCriteria)
        {
            return Surname.Contains(searchCriteria);
        }
    }

    // Клас Організація
    public class Organization : IPhoneDirectory
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }

        public Organization(string name, string address, string phoneNumber, string fax, string contactPerson)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Fax = fax;
            ContactPerson = contactPerson;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Organization: {Name}, Address: {Address}, Phone: {PhoneNumber}, Fax: {Fax}, Contact: {ContactPerson}");
        }

        public bool MatchesCriteria(string searchCriteria)
        {
            return Name.Contains(searchCriteria);
        }
    }

    // Клас Друг
    public class Friend : Person
    {
        public DateTime BirthDate { get; set; }

        public Friend(string surname, string address, string phoneNumber, DateTime birthDate)
            : base(surname, address, phoneNumber)
        {
            BirthDate = birthDate;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Friend: {Surname}, Address: {Address}, Phone: {PhoneNumber}, BirthDate: {BirthDate.ToShortDateString()}");
        }

        public override bool MatchesCriteria(string searchCriteria)
        {
            return base.MatchesCriteria(searchCriteria);
        }
    }

    ///3

    public class ITriangle : IEnumerable<int>
{
    // Поля
    protected int a; // Сторона основи
    protected int b; // Бічна сторона
    protected int color; // Колір

    // Конструктор
    public ITriangle(int baseSide, int side, int col)
    {
        a = baseSide;
        b = side;
        color = col;
    }

    // Методи
    public void PrintDimensions()
    {
        Console.WriteLine($"Сторона основи: {a}, Бічна сторона: {b}");
    }

    public int Perimeter()
    {
        return 2 * b + a;
    }

    public double Area()
    {
        return 0.5 * a * Math.Sqrt(Math.Pow(b, 2) - Math.Pow(a / 2.0, 2));
    }

    public bool IsEquilateral()
    {
        return a == b;
    }

    // Властивості
    public int BaseSide
    {
        get { return a; }
        set { a = value; }
    }

    public int Side
    {
        get { return b; }
        set { b = value; }
    }

    public int Color
    {
        get { return color; }
    }

    // Індексатор
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return a;
                case 1:
                    return b;
                case 2:
                    return color;
                default:
                    throw new IndexOutOfRangeException("Недопустимий індекс");
            }
        }
        set
        {
            switch (index)
            {
                case 0:
                    a = value;
                    break;
                case 1:
                    b = value;
                    break;
                case 2:
                    color = value;
                    break;
                default:
                    throw new IndexOutOfRangeException("Недопустимий індекс");
            }
        }
    }

    // Перевантаження операції ++ і --
    public static ITriangle operator ++(ITriangle triangle)
    {
        triangle.a++;
        triangle.b++;
        return triangle;
    }

    public static ITriangle operator --(ITriangle triangle)
    {
        triangle.a--;
        triangle.b--;
        return triangle;
    }

    // Перевантаження операції *
    public static ITriangle operator *(ITriangle triangle, int scalar)
    {
        return new ITriangle(triangle.a * scalar, triangle.b * scalar, triangle.color);
    }

    // Перевантаження true і false
    public static bool operator true(ITriangle triangle)
    {
        return triangle.a > 0 && triangle.b > 0 && triangle.a < 2 * triangle.b;
    }

    public static bool operator false(ITriangle triangle)
    {
        return !(triangle.a > 0 && triangle.b > 0 && triangle.a < 2 * triangle.b);
    }

    // Перетворення типу ITriangle в string
    public static explicit operator string(ITriangle triangle)
    {
        return $"Сторона основи: {triangle.a}, Бічна сторона: {triangle.b}, Колір: {triangle.color}";
    }

    // Перетворення типу string в ITriangle
    public static explicit operator ITriangle(string str)
    {
        var parts = str.Split(',');
        int a = int.Parse(parts[0].Split(':')[1].Trim());
        int b = int.Parse(parts[1].Split(':')[1].Trim());
        int color = int.Parse(parts[2].Split(':')[1].Trim());
        return new ITriangle(a, b, color);
    }

    // Реалізація IEnumerable<int>
    public IEnumerator<int> GetEnumerator()
    {
        yield return a;
        yield return b;
        yield return color;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            static void task1()
            {
                // Створення місця
                Place place = new Place("Some Place");
                place.Show();
                Console.WriteLine();

                // Створення міста
                City city = new City("Small Town", 50000);
                city.Show();
                Console.WriteLine();

                // Створення області
                Region region = new Region("Region X");
                region.Cities.Add(city);
                region.Show();
                Console.WriteLine();

                // Створення мегаполісу
                Metropolis metropolis = new Metropolis("Mega City", 1000000);
                metropolis.Cities.Add(city);
                metropolis.Cities.Add(new City("Another Town", 75000));
                metropolis.Show();
            }

            static void task2()
            {
                List<IPhoneDirectory> directory = new List<IPhoneDirectory>
                {
                    new Person("Ivanov", "Street 1", "123456"),
                    new Organization("TechCorp", "Avenue 2", "654321", "654123", "Petrov"),
                    new Friend("Sidorov", "Boulevard 3", "789012", new DateTime(1990, 5, 20))
                };

                // Виведення всієї інформації з бази
                foreach (var entry in directory)
                {
                    entry.DisplayInfo();
                }

                Console.WriteLine();

                // Пошук за критерієм
                string searchCriteria = "Ivanov";
                Console.WriteLine($"Search results for '{searchCriteria}':");
                foreach (var entry in directory)
                {
                    if (entry.MatchesCriteria(searchCriteria))
                    {
                        entry.DisplayInfo();
                    }
                }
            }

            static void task3() {
                ITriangle triangle = new ITriangle(3, 4, 5);
                foreach (var value in triangle)
                {
                    Console.WriteLine(value);
                }
             }

            while (true)
            {
                Console.WriteLine("  ****  Lab 6  ****  \n\n");
                Console.Write("Press 0 to exit\n");
                Console.Write("Which task would you like to review? (1-3) : ");
                string? str = Console.ReadLine();
                if (str == "0") break;
                if (str != null && short.TryParse(str, out short ans))
                {
                    switch (ans)
                    {
                        case 1: { task1(); break; }
                        case 2: { task2(); break; }
                        case 3: { task3(); break; }
                        default: { Console.WriteLine("Put the correct number"); break; }
                    }
                }
            }
        }
    }
}
