using StudentApi.DTOs;
using System.Threading.Tasks;
using StudentApi.Repositories.Interfaces;

public interface IResultService
{
    Task<ClassResultDto> GetClassResultAsync(int classId);
}
