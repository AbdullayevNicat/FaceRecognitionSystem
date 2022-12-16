using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;
using System.ServiceModel;

namespace SchoolFaceRecognition.API.SOAPServices.Base
{
    [ServiceContract]
    public interface IStudentProvider
    {
        [OperationContract]
        [ServiceKnownType(typeof(SuccessResponse<IEnumerable<StudentDto>>))]
        [ServiceKnownType(typeof(Response))]
        [ServiceKnownType(typeof(ErrorResponse))]
        Task<Response> GetAll();

        [OperationContract]
        Task<Response> Create(StudentDto studentDto);

        [OperationContract]
        Task<Response> Delete(int id);
    }
}
