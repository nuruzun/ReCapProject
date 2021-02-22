using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _color;
        public ColorManager(IColorDal color)
        {
            _color = color;
        }
        public IResult Add(Color color)
        {
            _color.Add(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_color.GetAll());
        }

        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new SuccessResult();
        }

       

        public IDataResult<Color> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<Color>(_color.Get(c => c.Id == colorId));
        }

        public IResult Update(Color color)
        {
            _color.Update(color);
            return new SuccessResult();

        }


    }
}
