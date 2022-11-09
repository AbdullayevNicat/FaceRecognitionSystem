using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Enums;

namespace SchoolFaceRecognition.Core.Entities
{
    public class Continuity : IEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Activity Activity { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
