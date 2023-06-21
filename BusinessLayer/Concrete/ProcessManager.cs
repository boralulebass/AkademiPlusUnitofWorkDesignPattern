using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitofWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProcessManager : IProcessService
    {
        private readonly IProcessDal _processDal;
        private readonly IUnitofWork _unitofWork;

        public ProcessManager(IProcessDal processDal, IUnitofWork unitofWork)
        {
            _processDal = processDal;
            _unitofWork = unitofWork;
        }

        public void Delete(Process t)
        {
            _processDal.Delete(t);
            _unitofWork.Save();
        }

        public Process GetByID(int id)
        {
            return _processDal.GetByID(id);
        }

        public List<Process> GetList()
        {
            return _processDal.GetList();
        }

        public void Insert(Process t)
        {
            _processDal.Insert(t);
            _unitofWork.Save();
        }

        public void MultiUpdate(List<Process> t)
        {
            _processDal.MultiUpdate(t);
            _unitofWork.Save();
        }

        public void Update(Process t)
        {
            _processDal.Update(t);
            _unitofWork.Save();
        }
    }
}
