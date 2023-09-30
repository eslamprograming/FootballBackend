using DAL.Entities;
using DAL.Models.Match;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IMatchService
    {
        Task<Response<Match>> CreateMatchsAsync(MatchVM MatchsVM);
        Task<Response<Match>> UpdateMatchsAsync(int Id, UpdateMatchVM MatchsVM);
        Task<Response<Match>> DeleteMatchsAsync(int Id);
        Task<Response<Match>> GetMatchsAsync(int Id);
        Task<Response<Match>> GetAllMatchsAsync(int groupCount);
    }
}
