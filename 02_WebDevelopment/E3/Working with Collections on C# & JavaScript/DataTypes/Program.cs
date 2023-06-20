using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Customer> customers = new List<Customer>();

            customers.Add(new Customer { Id = 1, Name = "Alfonso", Email = "alfonsoacosta207@gmail.com", fechaRegistro = DateTime.Now});
            customers.Add(new Customer { Id = 2, Name = "Diana", Email = "diana@gmail.com", fechaRegistro = new DateTime(2021, 02, 20)});
            customers.Add(new Customer { Id = 3, Name = "Jonathan", Email = "jonathan@gmail.com", fechaRegistro = new DateTime(2022, 04, 19) });
            customers.Add(new Customer { Id = 4, Name = "John", Email = "john@gmail.com", fechaRegistro = new DateTime(2022, 02, 20) });
            customers.Add(new Customer { Id = 6, Name = "Alice", Email = "alice@gmail.com" , fechaRegistro = new DateTime(2022, 03, 20) });
            customers.Add(new Customer { Id = 7, Name = "Bob", Email = "bob@gmail.com" , fechaRegistro = new DateTime(2023, 04, 12) });
            customers.Add(new Customer { Id = 8, Name = "Gina", Email = "gina@gmail.com" , fechaRegistro = new DateTime(2023, 05, 16) });
            customers.Add(new Customer { Id = 9, Name = "David", Email = "david@gmail.com" , fechaRegistro = new DateTime(2023, 06, 15) });
            customers.Add(new Customer { Id = 10, Name = "Luis", Email = "luis@gmail.com" , fechaRegistro = new DateTime(2023, 07, 26) });

            Console.WriteLine("BUCLE FOREACH");
            foreach(var customer in customers)
            {
                Console.WriteLine(customer.datos());
            }

            Console.WriteLine("\nBUCLE FOR");
            for(var i = 0; i < customers.Count; i++)
            {
                Console.WriteLine(customers[i].datos());
            }


            Console.WriteLine("\nBUCLE WHILE");
            int j = 0;
            while(j < customers.Count)
            {
                Console.WriteLine(customers[j].datos());
                j++;
            }

            j = 0;


            Console.WriteLine("\nBUCLE DO WHILE");

            do {

                Console.WriteLine(customers[j].datos());

                j++;
            } while (j < customers.Count);

            Console.ReadKey();
        }
    }
}