using Excecoes.Exceptions;

namespace Excecoes.Entities;

class Reservation
{
    public int RoomNumber { get; private set; }
    public DateTime CheckIn { get; private set; }
    public DateTime CheckOut { get; private set; }

    public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
    {
        if (checkOut <= checkIn)
        {
            throw new DomainException("Check-out date must be after check-in date.");
        }

        if (checkIn < DateTime.Now.Date || checkOut < DateTime.Now.Date)
        {
            throw new DomainException("Reservation dates must be future dates.");
        }

        RoomNumber = roomNumber;
        CheckIn = checkIn;
        CheckOut = checkOut;
    }
    public int Duration()
    {
        TimeSpan duration = CheckOut.Subtract(CheckIn);
        return (int)duration.TotalDays;
    }
    public void UpdateDates(DateTime checkIn, DateTime checkOut)
    {
        if (checkOut <= checkIn)
        {
            throw new DomainException("Check-out date must be after check-in date.");
        }

        if (checkIn < DateTime.Now.Date || checkOut < DateTime.Now.Date)
        {
            throw new DomainException("Reservation dates for update must be future dates.");
        }
        CheckIn = checkIn;
        CheckOut = checkOut;
    }
    public override string ToString()
    {
        return $"Room {RoomNumber}, Check-in: {CheckIn.ToShortDateString()}, Check-out: {CheckOut.ToShortDateString()}, Duration: {Duration()} nights";
    }
}
/*
try
        {
            Console.Write("Room number: ");
            int roomNumber = int.Parse(Console.ReadLine()!);
            Console.Write("Check-in date (dd/MM/yyyy): ");
            DateTime checkIn = DateTime.Parse(Console.ReadLine()!);
            Console.Write("Check-out date (dd/MM/yyyy): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine()!);
            Reservation reservation = new Reservation(roomNumber, checkIn, checkOut);
            Console.WriteLine("Reservation created: " + reservation);
            Console.WriteLine("Duration: " + reservation.Duration() + " nights");

            Console.WriteLine();
            Console.WriteLine("Enter new dates to update the reservation:");
            Console.Write("Check-in date (dd/MM/yyyy): ");
            checkIn = DateTime.Parse(Console.ReadLine()!);
            Console.Write("Check-out date (dd/MM/yyyy): ");
            checkOut = DateTime.Parse(Console.ReadLine()!);

            reservation.UpdateDates(checkIn, checkOut);
            Console.WriteLine("Reservation updated: " + reservation);
        }
        catch (DomainException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        */