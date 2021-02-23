using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.BusinessLayer.Services
{
    public class DirectionService : Service, IDirectionService
    {
        public DirectionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<DirectionModel>> GetAll()
        {
            var directions = _unitOfWork.DirectionRepository.GetAll();

            return await _mapper.ProjectTo<DirectionModel>(directions)
                                .ToListAsync();
        }

        public async Task<DirectionModel> GetById(int id)
        {
            var directionEntity = await _unitOfWork.DirectionRepository.GetById(id);

            return _mapper.Map<DirectionModel>(directionEntity);
        }

        public async Task<DirectionModel> Update(DirectionModel direction)
        {
            var directionEntity = await _unitOfWork.DirectionRepository.GetById(direction.DirectionId);

            var updatedEntity = _unitOfWork.DirectionRepository.Update(directionEntity);
            await _unitOfWork.SaveChanges();

            return _mapper.Map<DirectionModel>(updatedEntity);
        }

        public async Task<DirectionModel> Create(DirectionModel directionModel)
        {
            var directionEntity = _mapper.Map<Direction>(directionModel);

            var createdEntity = await _unitOfWork.DirectionRepository.Create(directionEntity);
            await _unitOfWork.SaveChanges();

            return _mapper.Map<DirectionModel>(createdEntity);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.DirectionRepository.Delete(id);
            await _unitOfWork.SaveChanges();
        }

        /// <summary>
        ///     This method check models equality by operator == overloading
        /// </summary>
        /// <param name="directionModel1"></param>
        /// <param name="directionModel2"></param>
        /// <returns></returns>
        public bool Equal(DirectionModel directionModel1, DirectionModel directionModel2)
        {
            return directionModel1 == directionModel2;
        }

        /// <summary>
        ///     This method check models inequality by operator != overloading
        /// </summary>
        /// <param name="directionModel1"></param>
        /// <param name="directionModel2"></param>
        /// <returns></returns>
        public bool NotEqual(DirectionModel directionModel1, DirectionModel directionModel2)
        {
            return directionModel1 != directionModel2;
        }
    }
}