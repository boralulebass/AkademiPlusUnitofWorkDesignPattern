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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IUnitofWork _unitofWork;

        public CustomerManager(ICustomerDal customerDal, IUnitofWork unitofWork)
        {
            _customerDal = customerDal;
            _unitofWork = unitofWork;
        }

        public void Delete(Customer t)
        {
            _customerDal.Delete(t);
            _unitofWork.Save();
        }

        public Customer GetByID(int id)
        {
            return _customerDal.GetByID(id);
        }

        public List<Customer> GetList()
        {
            return _customerDal.GetList();
        }

        public void Insert(Customer t)
        {
            _customerDal.Insert(t);
            _unitofWork.Save();
        }

        public void MultiUpdate(List<Customer> t)
        {
            _customerDal.MultiUpdate(t);
            _unitofWork.Save();
        }

        public void Update(Customer t)
        {
            _customerDal.Update(t);
            _unitofWork.Save();
        }
    }
}
