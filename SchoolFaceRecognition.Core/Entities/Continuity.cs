using SchoolFaceRecognition.Core.Entities.Base;
using SchoolFaceRecognition.Core.Enums;

namespace SchoolFaceRecognition.Core.Entities
{
    public class Continuity : EntityBase
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Activity Activity { get; set; }

        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}
