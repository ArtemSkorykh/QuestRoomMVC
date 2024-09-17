namespace QuestRoomMVC.Models
{
    public class QuestRoom
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinAge { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int FearLevel { get; set; } 
        public int DifficultyLevel { get; set; } 
        public string Logo { get; set; } = string.Empty;
    }
}
