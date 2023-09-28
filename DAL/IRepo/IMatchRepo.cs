using DAL.Entities;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IMatchRepo
    {
        Task<Response<Match>> CreateMatchRepo(Match Match);
        Task<Response<Match>> UpdateMatchRepo(int Id, Match Match);
        Task<Response<Match>> DeleteMatchRepo(int Id);
        Task<Response<Match>> GetMatchRepo(int Id);
        Task<Response<Match>> GetAllMatchRepo();
    }
}
