namespace SchoolFaceRecognition.Core.Abstractions
{
    public interface IEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string CreaterUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string? UpdaterUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? RemoverUser { get; set; }
        public DateTime? RemovingDate { get; set; }
    }
}
