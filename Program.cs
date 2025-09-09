using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		List<string> usuarios = new List<string> { "Ana", "Luis", "Maria", "Juan", "Pedro", "Sofia", "Carlos", "Lucia", "Miguel", "Elena" };

		Random rnd = new Random();
		List<string> usuariosOrdenados = usuarios.OrderBy(u => rnd.Next()).ToList();
		List<Ticket> atendidos = new List<Ticket>();

		List<Ticket> tickets = new List<Ticket>();
		Turnos turnos = new Turnos();

		for (int i = 0; i < usuarios.Count; i++)
		{
			Ticket ticket = new Ticket(i + 1, usuarios[i]);
			tickets.Add(ticket);
			turnos.AgregarTurno(ticket);
			Console.WriteLine($"Ticket generado: {ticket.Numero} para {ticket.Usuario}");
		}

		Console.WriteLine("\n--- Gestión de Turnos ---");
		while (turnos.TurnosRestantes() > 0)
		{
			Ticket siguiente = turnos.SiguienteTurno();
			Console.WriteLine($"Turno actual: {siguiente.Numero} - Usuario: {siguiente.Usuario}");
			Console.WriteLine("Presiona Enter para completar el turno...");
			Console.ReadLine();
			Ticket atendido = turnos.CompletarTurno();
			if (atendido != null)
				atendidos.Add(atendido);
		}
		   Console.WriteLine("Todos los turnos han sido completados.\n");

		   List<Ticket> atendidosOrdenados = CountingSortPorNombre(atendidos);
		   Console.WriteLine("--- Lista de Atendidos Ordenada por Nombre (Counting Sort) ---");
		   foreach (var t in atendidosOrdenados)
		   {
			   Console.WriteLine($"{t.Usuario} (Ticket {t.Numero})");
		   }
	   }

	static List<Ticket> CountingSortPorNombre(List<Ticket> lista)
	{
		if (lista.Count == 0) return new List<Ticket>();

		// Encontrar la longitud máxima de los nombres
		int maxLen = 0;
		foreach (var t in lista)
			if (t.Usuario.Length > maxLen) maxLen = t.Usuario.Length;

		List<Ticket> resultado = new List<Ticket>(lista);
		for (int pos = maxLen - 1; pos >= 0; pos--)
		{
			resultado = CountingSortChar(resultado, pos);
		}
		return resultado;
	}

	static List<Ticket> CountingSortChar(List<Ticket> lista, int pos)
	{
		int k = 256;
		int[] count = new int[k + 1];
		List<Ticket> output = new List<Ticket>(new Ticket[lista.Count]);

		foreach (var t in lista)
		{
			int c = pos < t.Usuario.Length ? (int)char.ToUpperInvariant(t.Usuario[pos]) : 0;
			count[c + 1]++;
		}
		for (int i = 1; i < count.Length; i++)
			count[i] += count[i - 1];

		foreach (var t in lista)
		{
			int c = pos < t.Usuario.Length ? (int)char.ToUpperInvariant(t.Usuario[pos]) : 0;
			output[count[c]++] = t;
		}
		return output;
	}
}
