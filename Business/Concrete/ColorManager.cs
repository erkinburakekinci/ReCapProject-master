using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal  _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccesDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }

        public IDataResult<Color> GetById(int colorid)
        {
            return new SuccesDataResult<Color>(_colorDal.Get(c => c.ColorId == colorid));
        }

    }
}
