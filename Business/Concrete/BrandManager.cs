using Business.Abstract;
using Business.Constant;
using Core.Utilities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brand;
        

        public BrandManager(IBrandDal brand) 
        {
            _brand = brand; 
        }

    

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2) 
            {
                _brand.Add(brand);
             
                return new SuccessResult(Messages.BrandAdded);
            }
            else
            {
                //Console.WriteLine("Marka ismini doğru girdiğinizden emin oluç (min 2 karakter)");
                return new ErrorResult(Messages.BrandInvalid);
            }
        }

        public IResult Delete(Brand brand)
        {
            _brand.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brand.GetAll());
        }

        public IDataResult<Brand> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<Brand>(_brand.Get(b => b.Id == id), Messages.BrandListed);
        }

        public IResult Update(Brand brand)
        {
            _brand.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
