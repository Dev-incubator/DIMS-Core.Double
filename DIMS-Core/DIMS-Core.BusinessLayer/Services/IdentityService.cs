using System;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.Identity.Interfaces;
using DIMS_Core.Identity.Services;

namespace DIMS_Core.BusinessLayer.Services
{
    public abstract class IdentityService : IIdentityService
    {
        protected readonly IMapper _mapper;
        protected readonly IIdentityUnitOfWork _unitOfWork;

        protected IdentityService(IIdentityUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Disposable

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            _unitOfWork.Dispose();

            _disposed = true;
        }

        ~IdentityService()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Disposable
    }
}