using System;

namespace TP_Poo
{
    class Personaje
    {
        protected string nombre;
        protected int vida;

        public Personaje(string nombre, int vida)
        {
            this.nombre = nombre;
            this.vida = vida;
        }

        public virtual void Atacar(Personaje objetivo)
        {
            objetivo.RecibirDanio(10);
        }

        public void RecibirDanio(int cant)
        {
            vida -= cant;

            if (vida < 0)
            {
                vida = 0;
            }
        }

        public bool EstaVivo()
        {
            return vida > 0;
        }

        public void MostrarEstado()
        {
            Console.WriteLine(nombre + " - Vida: " + vida);
        }
    }


    class Guerrero : Personaje
    {
        private int fuerzaFisica;

        public Guerrero(string nombre, int vida, int fuerzaFisica)
            : base(nombre, vida)
        {
            this.fuerzaFisica = fuerzaFisica;
        }

        public override void Atacar(Personaje objetivo)
        {
            Console.WriteLine(nombre + " ataca con fuerza física.");

            objetivo.RecibirDanio(fuerzaFisica);
        }
    }


    class Mago : Personaje
    {
        private int mana;

        public Mago(string nombre, int vida, int mana)
            : base(nombre, vida)
        {
            this.mana = mana;
        }

        public override void Atacar(Personaje objetivo)
        {
            if (mana >= 10)
            {
                Console.WriteLine(nombre + " lanza un hechizo.");

                mana -= 10;
                objetivo.RecibirDanio(30);
            }
            else
            {
                Console.WriteLine(nombre + " no tiene suficiente maná y da un golpe débil.");

                objetivo.RecibirDanio(5);
            }
        }
    }


    class Program
    {
        static void Main()
        {
            Guerrero guerrero = new Guerrero("Joseph", 20, 20);
            Mago mago = new Mago("Zargothrax", 80, 30);

            Personaje[] grupo =
            {
            guerrero,
            mago
        };

            Console.WriteLine("=== ESTADO INICIAL ===");

            foreach (Personaje personaje in grupo)
            {
                personaje.MostrarEstado();
            }

            Console.WriteLine("\n=== COMBATE ===");

            guerrero.Atacar(mago);
            mago.Atacar(guerrero);

            Console.WriteLine("\n=== ESTADO FINAL ===");

            foreach (Personaje personaje in grupo)
            {
                personaje.MostrarEstado();

                Console.WriteLine(
                    personaje.EstaVivo()
                        ? "Está vivo"
                        : "Ha muerto"
                );
            }
        }
    }
}