using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBST
{
    public Nodo Raiz;

    public Nodo Insertar(Nodo raiz, int valor)
    {
        if (raiz == null)
            return new Nodo(valor);

        if (valor < raiz.Valor)
            raiz.Izquierdo = Insertar(raiz.Izquierdo, valor);
        else if (valor > raiz.Valor)
            raiz.Derecho = Insertar(raiz.Derecho, valor);

        return raiz;
    }

    public bool Buscar(Nodo raiz, int valor)
    {
        if (raiz == null) return false;
        if (raiz.Valor == valor) return true;

        if (valor < raiz.Valor)
            return Buscar(raiz.Izquierdo, valor);
        else
            return Buscar(raiz.Derecho, valor);
    }

    public Nodo Minimo(Nodo raiz)
    {
        while (raiz.Izquierdo != null)
            raiz = raiz.Izquierdo;
        return raiz;
    }

    public Nodo Maximo(Nodo raiz)
    {
        while (raiz.Derecho != null)
            raiz = raiz.Derecho;
        return raiz;
    }

    public Nodo Eliminar(Nodo raiz, int valor)
    {
        if (raiz == null) return raiz;

        if (valor < raiz.Valor)
            raiz.Izquierdo = Eliminar(raiz.Izquierdo, valor);
        else if (valor > raiz.Valor)
            raiz.Derecho = Eliminar(raiz.Derecho, valor);
        else
        {
            if (raiz.Izquierdo == null && raiz.Derecho == null)
                return null;

            if (raiz.Izquierdo == null)
                return raiz.Derecho;
            else if (raiz.Derecho == null)
                return raiz.Izquierdo;

            Nodo temp = Minimo(raiz.Derecho);
            raiz.Valor = temp.Valor;
            raiz.Derecho = Eliminar(raiz.Derecho, temp.Valor);
        }

        return raiz;
    }

    public void InOrden(Nodo raiz)
    {
        if (raiz != null)
        {
            InOrden(raiz.Izquierdo);
            Console.Write(raiz.Valor + " ");
            InOrden(raiz.Derecho);
        }
    }

    public void PreOrden(Nodo raiz)
    {
        if (raiz != null)
        {
            Console.Write(raiz.Valor + " ");
            PreOrden(raiz.Izquierdo);
            PreOrden(raiz.Derecho);
        }
    }

    public void PostOrden(Nodo raiz)
    {
        if (raiz != null)
        {
            PostOrden(raiz.Izquierdo);
            PostOrden(raiz.Derecho);
            Console.Write(raiz.Valor + " ");
        }
    }

    public int Altura(Nodo raiz)
    {
        if (raiz == null) return -1;

        int izq = Altura(raiz.Izquierdo);
        int der = Altura(raiz.Derecho);

        return Math.Max(izq, der) + 1;
    }

    public void Limpiar()
    {
        Raiz = null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBST arbol = new ArbolBST();
        int opcion, valor;

        do
        {
            Console.WriteLine("\n--- MENÚ BST ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Recorridos");
            Console.WriteLine("5. Minimo, Maximo y Altura");
            Console.WriteLine("6. Limpiar árbol");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese valor: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Raiz = arbol.Insertar(arbol.Raiz, valor);
                    break;

                case 2:
                    Console.Write("Valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(arbol.Raiz, valor) ? "Encontrado" : "No encontrado");
                    break;

                case 3:
                    Console.Write("Valor a eliminar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Raiz = arbol.Eliminar(arbol.Raiz, valor);
                    break;

                case 4:
                    Console.WriteLine("InOrden:");
                    arbol.InOrden(arbol.Raiz);
                    Console.WriteLine("\nPreOrden:");
                    arbol.PreOrden(arbol.Raiz);
                    Console.WriteLine("\nPostOrden:");
                    arbol.PostOrden(arbol.Raiz);
                    break;

                case 5:
                    if (arbol.Raiz != null)
                    {
                        Console.WriteLine("Mínimo: " + arbol.Minimo(arbol.Raiz).Valor);
                        Console.WriteLine("Máximo: " + arbol.Maximo(arbol.Raiz).Valor);
                        Console.WriteLine("Altura: " + arbol.Altura(arbol.Raiz));
                    }
                    else
                    {
                        Console.WriteLine("Árbol vacío");
                    }
                    break;

                case 6:
                    arbol.Limpiar();
                    Console.WriteLine("Árbol limpiado");
                    break;
            }

        } while (opcion != 0);
    }
}