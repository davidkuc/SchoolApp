using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp_EFCore.Repositories
{
    public class RepoPack
    {
        private readonly AccRepository _accRepo;
        private readonly TeaRepository _teaRepo;
        private readonly StudRepository _studRepo;

        public AccRepository AccRepo => _accRepo;
        public TeaRepository TeaRepo => _teaRepo;
        public StudRepository StudRepo => _studRepo;

        public RepoPack(AccRepository accRepo,
                        TeaRepository teaRepo,
                        StudRepository studRepo)
        {
            _accRepo = accRepo;
            _teaRepo = teaRepo;
            _studRepo = studRepo;
        }
    }
}
