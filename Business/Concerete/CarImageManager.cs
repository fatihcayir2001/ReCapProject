using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concerete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concerete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public ICarDal _carDal;
        private IFileProcess fileProcess;

        public CarImageManager(ICarImageDal carImageDal,ICarDal carDal, IFileProcess fileProcess)
        {
            _carImageDal = carImageDal;
            _carDal = carDal;
            this.fileProcess = fileProcess;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(int id, IFormFile files)
        {
            IResult result = BusinessRules.Run(CheckIfMaxImageLimitExceeded(id), CheckTheCarExists(id));
            if (result != null)
            {
                return new SuccessResult("Operasyon başarılı");
            }

            string FileName = Guid.NewGuid().ToString();
            CarImage carImg = new CarImage
            {
                CarId = id,
                Date = DateTime.UtcNow,
                ImagePath = FileName
            };
            _carImageDal.Add(carImg);
            var fileResult = fileProcess.Upload(FileName, files);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(int id)
        {
            var result = _carImageDal.Get(c => c.Id == id);
            _carImageDal.Delete(result);
            return new SuccessResult(Messages.OperationSuccessful);
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.Id==Id));
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(int id)
        {
            var result = _carImageDal.Get(c => c.Id == id);
            _carImageDal.Update(result);
            return new SuccessResult(Messages.OperationSuccessful);
        }
        [ValidationAspect(typeof(CarImageValidator))]
        private IResult CheckIfMaxImageLimitExceeded(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id).Count;
            if (result>5)
            {
                return new ErrorResult(Messages.ImagesLimitExceeded);
            }
            return new SuccessResult(Messages.ImageAdded);
            

        }

        private IResult CheckIfImageNull()
        {

            var result = _carImageDal.GetAll(c => c.ImagePath==null);
            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }

        public IResult CheckTheCarExists(int id)
        {
            var result = _carDal.Get(c => c.CarId == id);
            if (result != null)
            {
                return new SuccessResult("Araç var");
            }
            return new ErrorResult("araç bulunamadı");
        }

    }

}
