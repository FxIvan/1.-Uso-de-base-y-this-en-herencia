using System;

namespace HerenciaBaseThis
{
    // Clase base
    class Persona
    {
        public string Nombre { get; set; }

        public Persona(string nombre)
        {
            Nombre = nombre;
            Console.WriteLine("Constructor Persona");
        }

        ~Persona()
        {
            Console.WriteLine("Finalizador Persona");
        }

        public virtual void Mostrar()
        {
            Console.WriteLine($"Persona: {Nombre}");
        }
    }

    // Clase derivada
    class Estudiante : Persona
    {
        public int Edad { get; set; }

        // Constructor que usa base para inicializar desde la clase padre
        public Estudiante(string nombre, int edad) : base(nombre)
        {
            Edad = edad;
            Console.WriteLine("Constructor Estudiante");
        }

        ~Estudiante()
        {
            Console.WriteLine("Finalizador Estudiante");
        }

        // Sobrescribimos Mostrar y usamos base para reutilizar lógica del padre
        public override void Mostrar()
        {
            base.Mostrar(); // llama al método de Persona
            Console.WriteLine($"Edad: {Edad}");
        }

        // Uso de this
        public void CompararEdad(Estudiante otro)
        {
            if (this.Edad > otro.Edad) // this se refiere al objeto actual
                Console.WriteLine($"{this.Nombre} es mayor que {otro.Nombre}");
            else
                Console.WriteLine($"{otro.Nombre} es mayor o igual que {this.Nombre}");
        }
    }

    class Program
    {
        static void Main()
        {
            Estudiante e1 = new Estudiante("Ana", 20);
            Estudiante e2 = new Estudiante("Luis", 22);

            e1.Mostrar();
            e2.Mostrar();

            e1.CompararEdad(e2);
        }
    }
}
