using System;
using System.Collections.Generic;
using System.Linq; // Necesario para OrderBy

class Program
{
	static void Main(string[] args)
	{
		List<string> usuarios = new List<string> { "Ana", "Luis", "Maria", "Juan", "Pedro", "Sofia", "Carlos", "Lucia", "Miguel", "Elena" };

		// Mezclar la lista de usuarios aleatoriamente
		Random rnd = new Random();
		usuarios = usuarios.OrderBy(u => rnd.Next()).ToList();

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
			turnos.CompletarTurno();
		}
		Console.WriteLine("Todos los turnos han sido completados.");
	}
}
