using AutoMapper;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MISA.Core.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class BaseService<Response, Insert, Update, Entity> : IBaseService<Response, Insert, Update, Entity> where Entity : class
    {
        #region Property
        private readonly IBaseRepository<Entity> _baseRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<Entity> baseRepository,
            IMapper mapper)
        {
            this._baseRepository = baseRepository;
            this._mapper = mapper;
        }
        #endregion

        #region Method
        public virtual async Task<BaseResponse<Response>> DeleteAsync(Guid id)
        {
            try
            {
                // Validate Id is existent?
                var entity = await _baseRepository.GetByIdAsync(id);
                if (entity is null)
                    return new BaseResponse<Response>("Đối tượng không tồn tại.");

                // Validate object can deleting?
                if (!CheckDeleteEntity(entity))
                    return new BaseResponse<Response>("Không được phép xoá, do đối tượng mặc định của hệ thống.");

                var tempData = await _baseRepository.DeleteAsync(id);

                return tempData > 0 ? new BaseResponse<Response>(_mapper.Map<Response>(entity))
                    : new BaseResponse<Response>("Lỗi khi thực hiện xoá đối tượng.");
            }
            catch (Exception ex)
            {
                return new BaseResponse<Response>($"Lỗi khi thực hiện xoá đối tượng: {ex.Message}");
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu có được phép xoá hay không?
        /// </summary>
        /// <returns>Giá trị của thuộc tính Important</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        private bool CheckDeleteEntity<T>(T entity)
        {
            // canDelete =  true: được phép xoá, ngược lại là không được xoá.
            bool canDelete = true;

            foreach (var item in entity.GetType().GetProperties())
            {
                if (item.Name == "Important")
                {
                    canDelete = !Convert.ToBoolean(item.GetValue(entity));
                    break;
                }
            }

            return canDelete;
        }

        public virtual async Task<BaseResponse<IEnumerable<Response>>> GetAllAsync()
        {
            try
            {
                var tempEntity = await _baseRepository.GetAllAsync();
                // Mapping Entity to Resource
                var resource = _mapper.Map<IEnumerable<Response>>(tempEntity);

                return new BaseResponse<IEnumerable<Response>>(resource);
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Response>>($"Lỗi khi thực hiện lấy dữ liệu: {ex.Message}");
            }
        }

        public virtual async Task<BaseResponse<Response>> GetByIdAsync(Guid id)
        {
            try
            {
                // Validate Id is existent?
                var tempEntity = await _baseRepository.GetByIdAsync(id);
                if (tempEntity is null)
                    return new BaseResponse<Response>("Đối tượng không tồn tại.");

                return new BaseResponse<Response>(_mapper.Map<Response>(tempEntity));
            }
            catch (Exception ex)
            {
                return new BaseResponse<Response>($"Lỗi khi thực hiện lấy dữ liệu: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy ra thuộc tính [Entity]Name;
        /// </summary>
        /// <returns>Giá trị của thuộc tính [Entity]Name</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        private string GetNameEntity<T>(T resourceObj)
        {
            string name = string.Empty;

            foreach (var item in resourceObj.GetType().GetProperties())
            {
                if (item.Name == $"{typeof(Entity).Name}Name")
                {
                    name = item.GetValue(resourceObj).ToString();
                    break;
                }
            }

            return name;
        }

        public virtual async Task<BaseResponse<Response>> InsertAsync(Insert createEntityResource)
        {
            try
            {
                // Validate Name is existent?
                var isValid = await _baseRepository.ValidateNameAsync(GetNameEntity(createEntityResource));
                if (isValid != null)
                    return new BaseResponse<Response>($"Giá trị thuộc tính {typeof(Entity).Name}Name đã tồn tại trong CSDL.");

                // Mapping Resource to Entity
                var entity = _mapper.Map<Entity>(createEntityResource);

                var tempData = await _baseRepository.InsertAsync(entity);

                return tempData > 0 ? new BaseResponse<Response>(_mapper.Map<Response>(entity))
                    : new BaseResponse<Response>("Lỗi khi thực hiện thêm mới đối tượng.");
            }
            catch (Exception ex)
            {
                return new BaseResponse<Response>($"Lỗi khi thực hiện thêm mới đối tượng: {ex.Message}");
            }
        }

        public virtual async Task<BaseResponse<Response>> UpdateAsync(Guid id, Update updateEntityResource)
        {
            try
            {
                // Validate Id is existent?
                var entity = await _baseRepository.GetByIdAsync(id);
                if (entity is null)
                    return new BaseResponse<Response>("Đối tượng không tồn tại.");

                // Validate Name is existent?
                var isValid = await _baseRepository.ValidateNameAsync(GetNameEntity(updateEntityResource));
                if (isValid != null)
                    return new BaseResponse<Response>($"Giá trị thuộc tính {typeof(Entity).Name}Name đã tồn tại trong CSDL.");

                // Update infomation
                _mapper.Map(updateEntityResource, entity);

                var tempData = await _baseRepository.UpdateAsync(entity);

                return tempData > 0 ? new BaseResponse<Response>(_mapper.Map<Response>(entity))
                    : new BaseResponse<Response>("Lỗi khi thực hiện cập nhật đối tượng.");
            }
            catch (Exception ex)
            {
                return new BaseResponse<Response>($"Lỗi khi thực hiện cập nhật đối tượng: {ex.Message}");
            }
        }
        #endregion
    }
}
