namespace Locaserv.Bdv.Api.Models
{
    public class Course
    {
        public Course(string name, string code, Conductor conductor, Vehicle vehicle, Position initial, decimal initialKm)
        {
            Name = name;
            Code = code;
            Conductor = conductor;
            Vehicle = vehicle;
            Initial = initial;
            InitialKm = initialKm;
        }

        public string Name { get; }
        public string Code { get; }
        public Conductor Conductor { get; }
        public Vehicle Vehicle { get; }
        public Position Initial { get; }
        public Position Final { get; set; }
        public decimal InitialKm { get; private set; }
        public decimal FinalKm { get; private set; }
        public List<Occurrence> Occurrences { get; set; } = new List<Occurrence>();

        public void AddOccurrence(Occurrence occurrence)
        {
            Occurrences.Add(occurrence);
        }

        public void Finalize(Position final, decimal finalKm)
        {
            Final = final;
            FinalKm = finalKm;
        }
    }
}