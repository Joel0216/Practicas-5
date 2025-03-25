using System;
using System.IO;
using System.Collections.Generic;
class Productos
{
    public string nombreProducto { get; set; }
    public int CodigoProducto { get; set; }
    public int CantidadStock { get; set; }
    public double PrecioUnitario { get; set; }

    public Productos (string nombreProducto, int CodigoProducto, int CantidadStock, double PrecioUnitario)
    {
        this.nombreProducto = nombreProducto;
        this.CodigoProducto = CodigoProducto;
        this.CantidadStock = CantidadStock;
        this.PrecioUnitario = PrecioUnitario;
    }

}

class Registros
{
    private string _rutaArchivo;

    public Registros(string _rutaArchivo)
    {
        this._rutaArchivo = _rutaArchivo;
    }

    public void GuardarInventario(Productos productos)
    {
        using (StreamWriter sw = new StreamWriter(_rutaArchivo, true))
        {
            sw.WriteLine($"{productos.nombreProducto},{productos.CodigoProducto},{productos.CantidadStock},{productos.PrecioUnitario}");
        }
    }

    public void mostrarInfo()
    {
        if (File.Exists(_rutaArchivo))
        {
            string[] lineas = File.ReadAllLines(_rutaArchivo);
            foreach (var linea in lineas)
            {
                string[] datos = linea.Split(',');

                string nombreProducto = datos[0];
                int CodigoProducto = int.Parse(datos[1]);
                int CantidadStock = int.Parse(datos[2]);
                double PrecioUnitario = double.Parse(datos[3]); 

                Console.WriteLine($"Nombre del Producto: {nombreProducto}, codigo del producto: {CodigoProducto}, canotidad en stock: {CantidadStock}, precio unitario: {PrecioUnitario}");
            }
        }
        else
        {
            Console.WriteLine("No se encontrado el archivo");
        }
    }
}

partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido al inventario de productos (Escribe 'salir' en el nombre del producto para salir)");
        Registros miRegistro = new Registros("inventario.json");
        while (true)
        {
            Console.WriteLine("1. Añadir producto");
            string nombreProducto = Console.ReadLine() ?? string.Empty;
            if (nombreProducto == "salir")
            {
                break;
            }

            Console.WriteLine("2. Codigo del producto");
            Console.WriteLine("2. Codigo del producto");
            string? inputCodigoProducto = Console.ReadLine();
            if (!int.TryParse(inputCodigoProducto, out int CodigoProducto))
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
                continue;
            }

            Console.WriteLine("3. Cantidad de stock");
            string? inputCantidadStock = Console.ReadLine();
            if (!int.TryParse(inputCantidadStock, out int CantidadStock))
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
                continue;
            }

            Console.WriteLine("#4. PrecioUnitario");
            Console.WriteLine("#4. PrecioUnitario");
            string? inputPrecioUnitario = Console.ReadLine();
            if (!double.TryParse(inputPrecioUnitario, out double PrecioUnitario))
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
                continue;
            }

            Productos productos = new Productos(nombreProducto, CodigoProducto, CantidadStock, PrecioUnitario);
            miRegistro.GuardarInventario(productos);
        }

        miRegistro.mostrarInfo();
    }
}

class buscarProducto
{
    public void buscarProducto(Productos productos)
    {
        Console.WriteLine("Ingrese el nombre del producto a buscar");
        string nombreProducto = Console.ReadLine();
        if (productos.nombreProducto == nombreProducto)
        {
            Console.WriteLine($"Nombre del Producto: {productos.nombreProducto}, codigo del producto: {productos.CodigoProducto}, canotidad en stock: {productos.CantidadStock}, precio unitario: {productos.PrecioUnitario}");
        }
        else
        {
            Console.WriteLine("Producto no encontrado");
        }
    }
}

class pago
{
    public void Pago(Productos productos)
    {
        Console.WriteLine("Ingrese el nombre del producto a comprar");
        string nombreProducto = Console.ReadLine();
        if (productos.nombreProducto == nombreProducto)
        {
            Console.WriteLine("Ingrese la cantidad de productos a comprar");
            int cantidad = int.Parse(Console.ReadLine());
            if (productos.CantidadStock >= cantidad)
            {
                double total = cantidad * productos.PrecioUnitario;
                Console.WriteLine($"El total a pagar es: {total}");
            }
            else
            {
                Console.WriteLine("No hay suficiente stock");
            }
        }
        else
        {
            Console.WriteLine("Producto no encontrado");
        }
    }
}

class comprarProducto
{
    public void comprarProducto(Productos productos)
    {
        Console.WriteLine("Ingrese el nombre del producto a comprar");
        string nombreProducto = Console.ReadLine();
        if (productos.nombreProducto == nombreProducto)
        {
            Console.WriteLine("Ingrese la cantidad de productos a comprar");
            int cantidad = int.Parse(Console.ReadLine());
            if (productos.CantidadStock >= cantidad)
            {
                double total = cantidad * productos.PrecioUnitario;
                Console.WriteLine($"El total a pagar es: {total}");
            }
            else
            {
                Console.WriteLine("No hay suficiente stock");
            }
        }
        else
        {
            Console.WriteLine("Producto no encontrado");
        }
    }
}