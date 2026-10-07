using System;

namespace CofrePOO
{
    class Item
    {
        public string Nombre { get; set; }

        private float _peso;

        public float Peso
        {
            get
            {
                return _peso;
            }

            set
            {
                if (value <= 0)
                {
                    _peso = 0.5f;
                }
                else
                {
                    _peso = value;
                }
            }
        }

        public Item(string nombre, float peso)
        {
            this.Nombre = nombre;
            this.Peso = peso;
        }

        public virtual void Usar()
        {
            Console.WriteLine($"Se está usando {Nombre}.");
        }
    }


    class Pocion : Item
    {
        public int PuntosRecuperacion { get; set; }

        public Pocion(string nombre, float peso, int puntosRecuperacion)
            : base(nombre, peso)
        {
            this.PuntosRecuperacion = puntosRecuperacion;
        }

        public override void Usar()
        {
            Console.WriteLine(
                $"{Nombre} restaura {PuntosRecuperacion} puntos."
            );
        }
    }


    class ArmaEquipable : Item
    {
        public int Danio { get; set; }

        public ArmaEquipable(string nombre, float peso, int danio)
            : base(nombre, peso)
        {
            this.Danio = danio;
        }

        public override void Usar()
        {
            Console.WriteLine(
                $"Se equipa {Nombre} con {Danio} de poder de ataque."
            );
        }
    }


    class CofreBotin
    {
        private bool _abierto = false;
        private Item[] itemsContenidos = new Item[2];

        public CofreBotin(Item item1, Item item2)
        {
            itemsContenidos[0] = item1;
            itemsContenidos[1] = item2;
        }

        public void Abrir()
        {
            if (!_abierto)
            {
                _abierto = true;

                Console.WriteLine("Cofre abierto:");

                for (int i = 0; i < itemsContenidos.Length; i++)
                {
                    itemsContenidos[i].Usar();
                }
            }
            else
            {
                Console.WriteLine("El cofre ya está abierto.");
            }
        }
    }


    class Program
    {
        static void Main()
        {
            Pocion pocion = new Pocion(
                "Poción de vida",
                0.5f,
                50
            );

            ArmaEquipable espada = new ArmaEquipable(
                "Espada de hierro",
                3.5f,
                25
            );

            CofreBotin cofre = new CofreBotin(pocion, espada);

            cofre.Abrir();
        }
    }
}