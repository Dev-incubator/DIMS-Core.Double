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
    public class UserProfileService : Service, IUserProfileService
    {
        public UserProfileService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<UserProfileModel>> GetAll()
        {
            var userProfiles = _unitOfWork.UserProfileRepository.GetAll();

            return await _mapper.ProjectTo<UserProfileModel>(userProfiles)
                                .ToListAsync();
        }

        public async Task<UserProfileModel> GetById(int id)
        {
            var userProfileEntity = await _unitOfWork.UserProfileRepository.GetById(id);

            return _mapper.Map<UserProfileModel>(userProfileEntity);
        }

        public async Task<UserProfileModel> Update(UserProfileModel userProfile)
        {
            var userProfileEntity = await _unitOfWork.UserProfileRepository.GetById(userProfile.UserId);

            var updatedEntity = _unitOfWork.UserProfileRepository.Update(_mapper.Map(userProfile, userProfileEntity));
            await _unitOfWork.SaveChanges();

            return _mapper.Map<UserProfileModel>(updatedEntity);
        }

        public async Task<UserProfileModel> Create(UserProfileModel userProfileModel)
        {
            var userProfileEntity = _mapper.Map<UserProfile>(userProfileModel);

            var createdEntity = await _unitOfWork.UserProfileRepository.Create(userProfileEntity);
            await _unitOfWork.SaveChanges();

            return _mapper.Map<UserProfileModel>(createdEntity);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.UserProfileRepository.Delete(id);
            await _unitOfWork.SaveChanges();
        }

        /// <summary>
        ///     This method check models equality by operator == overloading
        /// </summary>
        /// <param name="userModel1"></param>
        /// <param name="userModel2"></param>
        /// <returns></returns>
        public bool Equal(UserProfileModel userModel1, UserProfileModel userModel2)
        {
            return userModel1 == userModel2;
        }

        /// <summary>
        ///     This method check models inequality by operator != overloading
        /// </summary>
        /// <param name="userModel1"></param>
        /// <param name="userModel2"></param>
        /// <returns></returns>
        public bool NotEqual(UserProfileModel userModel1, UserProfileModel userModel2)
        {
            return userModel1 != userModel2;
        }
    }
}