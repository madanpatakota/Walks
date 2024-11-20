namespace ProWalks.DomainModels
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public double Length { get; set; }   //11.90

        public Guid RegionId { get; set; }

        public Guid WalkDifficultyId { get; set; }

        public Region Region { get; set; }

        public WalkDifficulty walkDifficulty { get; set; }




    }
}


//Hands on the Exp

