using AutoMapper;
using Microsoft.Extensions.Options;
using MISA.Core.Entities;
using MISA.Core.Extensions;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using MISA.Core.Resources;
using MISA.Core.Resources.Fee;
using MISA.Core.Resources.FeeGroup;
using MISA.Core.Resources.FeeRange;
using MISA.Core.Resources.UnitFee;
using MISA.Core.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class FeeService : BaseService<FeeResource, CreateFeeResource, UpdateFeeResource, Fee>, IFeeService
    {
        #region Property
        private readonly IFeeRepository _feeRepository;
        private readonly IFeeGroupRepository _feeGroupRepository;
        private readonly IFeeRangeRepository _feeRangeRepository;
        private readonly IUnitFeeRepository _unitFeeRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public FeeService(IFeeRepository feeRepository,
            IMapper mapper,
            IFeeGroupRepository feeGroupRepository,
            IFeeRangeRepository feeRangeRepository,
            IUnitFeeRepository unitFeeRepository,
            IOptionsSnapshot<ResponseMessage> responseMessage
            ) : base(feeRepository, mapper, responseMessage)
        {
            this._feeRepository = feeRepository;
            this._feeGroupRepository = feeGroupRepository;
            this._feeRangeRepository = feeRangeRepository;
            this._unitFeeRepository = unitFeeRepository;
            this._mapper = mapper;
        }
        #endregion

        #region Method
        public override async Task<BaseResponse<FeeResource>> GetByIdAsync(Guid id)
        {
            try
            {
                // Validate Id is existent?
                var fee = await _feeRepository.GetByIdAsync(id);
                if (fee is null)
                    return new BaseResponse<FeeResource>(ResponseMessage.Values["NoData"]);

                // Mapping Fee to Resource
                var feeResource = await MappingReference(fee);

                return new BaseResponse<FeeResource>(feeResource);
            }
            catch (Exception ex)
            {
                return new BaseResponse<FeeResource>($"{ResponseMessage.Values["GetError"]} {ex.Message}");
            }
        }

        private async Task<FeeResource> MappingReference(Fee fee)
        {
            // Lấy dữ liệu bảng phụ
            var unitFeeTask = _unitFeeRepository.GetByIdAsync(fee.UnitFeeId);
            var feeGroupTask = _feeGroupRepository.GetByIdAsync(fee?.FeeGroupId);
            var feeRangeTask = _feeRangeRepository.GetByIdAsync(fee?.FeeRangeId);

            await Task.WhenAll(feeGroupTask, feeRangeTask, unitFeeTask);

            var unitFee = await unitFeeTask;
            var feeGroup = await feeGroupTask;
            var feeRange = await feeRangeTask;

            // Mapping Fee to Resource
            var feeResource = _mapper.Map<FeeResource>(fee);

            if (feeGroup.FeeGroupName != null)
                feeResource.FeeGroup = _mapper.Map<FeeGroupResource>(feeGroup);
            else
                feeResource.FeeGroup = null;

            if (feeRange.FeeRangeName != null)
                feeResource.FeeRange = _mapper.Map<FeeRangeResource>(feeRange);
            else
                feeResource.FeeRange = null;

            if (unitFee.UnitFeeName != null)
                feeResource.UnitFee = _mapper.Map<UnitFeeResource>(unitFee);
            else
                feeResource.UnitFee = null;

            return feeResource;
        }

        public async Task<BaseResponse<IEnumerable<FeeResource>>> GetAllPaginationAsync(SearchFeeResource searchResource)
        {
            try
            {
                var responseFeeTask = _feeRepository.GetPaginationAsync(searchResource);
                var responseTotalRecordsTask = _feeRepository.TotalRecordsAsync(searchResource);

                await Task.WhenAll(responseFeeTask, responseTotalRecordsTask);

                List<FeeResource> resourceList = new List<FeeResource>();
                List<Task<FeeResource>> listMappingTask = new List<Task<FeeResource>>();

                // Mapping các dữ liệu tham chiếu
                foreach (var fee in responseFeeTask.Result)
                {
                    // Mapping Fee to Resource
                    listMappingTask.Add(MappingReference(fee));
                }

                await Task.WhenAll(listMappingTask);

                foreach (var item in listMappingTask)
                {
                    resourceList.Add(item.Result);
                }

                var resourceResponse = new PaginationResponse<IEnumerable<FeeResource>>(resourceList);
                // Gán giá trị cho response
                resourceResponse.CreatePaginationResponse(searchResource, responseTotalRecordsTask.Result);

                return resourceResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<FeeResource>>($"{ResponseMessage.Values["GetError"]} {ex.Message}");
            }

        }

        public async Task<DeleteResponse<IEnumerable<DetailDelete>>> DeleteManyAsync(DeleteResource deleteResource)
        {
            List<Task<BaseResponse<FeeResource>>> listTaskDelete = new List<Task<BaseResponse<FeeResource>>>();
            int totalRequest = deleteResource.ListDelete.Count;
            int totalDeleted = 0;
            List<DetailDelete> detailDeleteList = new List<DetailDelete>();

            try
            {
                // Khai báo task
                foreach (var id in deleteResource.ListDelete)
                {
                    listTaskDelete.Add(this.DeleteAsync(id));
                }

                await Task.WhenAll(listTaskDelete);

                // Kiểm tra kết quả
                int countList = listTaskDelete.Count;

                for (int i = 0; i < countList; i++)
                {
                    var result = listTaskDelete[i].Result;

                    if (result.Success)
                        totalDeleted++;
                    else
                        detailDeleteList.Add(new DetailDelete(deleteResource.ListDelete[i], result.Message));
                }

                return new DeleteResponse<IEnumerable<DetailDelete>>(totalRequest, totalDeleted, detailDeleteList);
            }
            catch (Exception ex)
            {
                return new DeleteResponse<IEnumerable<DetailDelete>>($"{ResponseMessage.Values["DeleteError"]} {ex.Message}");
            }
        }

        public override async Task<BaseResponse<FeeResource>> InsertAsync(CreateFeeResource createFeeResource)
        {
            try
            {
                // Validate insert-resource
                var tempResponse = await ValidateValueResource(createFeeResource);
                if (!tempResponse.isSuccess)
                {
                    return new BaseResponse<FeeResource>(tempResponse.message.ConcatenateListString());
                }

                // Mapping Resource to Entity
                var fee = _mapper.Map<Fee>(createFeeResource);

                var insertResponse = await _feeRepository.InsertAsync(fee);
                if (insertResponse <= 0)
                    return new BaseResponse<FeeResource>(ResponseMessage.Values["InsertError"]);

                var feeGet = await _feeRepository.GetByIdAsync(fee.FeeId);

                // Mapping Fee to Resource
                var feeResource = await MappingReference(feeGet);

                return new BaseResponse<FeeResource>(feeResource);
            }
            catch (Exception ex)
            {
                return new BaseResponse<FeeResource>($"{ResponseMessage.Values["InsertError"]} {ex.Message}");
            }
        }

        public override async Task<BaseResponse<FeeResource>> UpdateAsync(Guid id, UpdateFeeResource updateFeeResource)
        {
            try
            {
                // Validate Id is existent?
                var fee = await _feeRepository.GetByIdAsync(id);
                if (fee is null)
                    return new BaseResponse<FeeResource>(ResponseMessage.Values["NoData"]);

                // Validate insert-resource
                var tempResponse = await ValidateValueResource(updateFeeResource, fee.FeeId);
                if (!tempResponse.isSuccess)
                {
                    return new BaseResponse<FeeResource>(tempResponse.message.ConcatenateListString());
                }

                // Update infomation
                _mapper.Map(updateFeeResource, fee);
                var tempData = await _feeRepository.UpdateAsync(fee);

                // Mapping Fee to Resource
                var feeResource = await MappingReference(fee);

                return tempData > 0 ? new BaseResponse<FeeResource>(feeResource)
                    : new BaseResponse<FeeResource>(ResponseMessage.Values["UpdateError"]);
            }
            catch (Exception ex)
            {
                return new BaseResponse<FeeResource>($"{ResponseMessage.Values["UpdateError"]} {ex.Message}");
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu đầu vào của Resource
        /// </summary>
        /// <param name="feeResouce">Đối tượng Resource</param>
        /// <returns>Dữ liệu có hợp lệ hay không?</returns>
        /// CreatedBy: NDDONG (13/06/2021)
        private async Task<(bool isSuccess, List<string> message)> ValidateValueResource<T>(T feeResouce, Guid? isUpdate = null)
        {
            List<string> messages = new List<string>();

            try
            {
                string feeName = string.Empty;
                Guid? feeId = isUpdate;
                Guid unitFeeId = new Guid();
                Guid feeRangeId = new Guid();
                Guid? feeGroupId = null;

                foreach (var item in feeResouce.GetType().GetProperties())
                {
                    if (item.Name.ToLower() == "FeeName".ToLower())
                        feeName = item.GetValue(feeResouce).ToString();
                    if (item.Name.ToLower() == "UnitFeeId".ToLower())
                        unitFeeId = (Guid)(item.GetValue(feeResouce));
                    if (item.Name.ToLower() == "FeeGroupId".ToLower() && item.GetValue(feeResouce) != null)
                        feeGroupId = (Guid?)(item.GetValue(feeResouce));
                    if (item.Name.ToLower() == "FeeRangeId".ToLower() && item.GetValue(feeResouce) != null)
                        feeRangeId = (Guid)(item.GetValue(feeResouce));
                }

                // Validate Name is existent?
                var validateNameTask = _feeRepository.ValidateNameAsync(feeName.RemoveSpaceCharacter());

                // Validate UnitFeeId is existent?
                var unitFeeTask = _unitFeeRepository.GetByIdAsync(unitFeeId);
                // Validate UnitRangeId is existent?
                var feeRangeTask = _feeRangeRepository.GetByIdAsync(feeRangeId);

                await Task.WhenAll(validateNameTask, unitFeeTask, feeRangeTask);

                // Assign isValid
                bool isValidFeeName = false;
                if (feeId is null)
                    isValidFeeName = (validateNameTask.Result is null) ? true : false;
                else
                    isValidFeeName = (validateNameTask.Result is null || validateNameTask.Result.FeeId.Equals(feeId)) ? true : false;

                if (!isValidFeeName || unitFeeTask.Result is null || feeRangeTask.Result is null)
                {
                    if (!isValidFeeName)
                        messages.Add($"FeeName {ResponseMessage.Values["DuplicateError"]}");
                    if (unitFeeTask.Result is null)
                        messages.Add($"{ResponseMessage.Values["NoData"]}: UnitFeeId.");
                    if (feeRangeTask.Result is null)
                        messages.Add($"{ResponseMessage.Values["NoData"]}: FeeRangeId.");

                    return (false, messages);
                }

                // Validate FeeGroupId is existent?
                if (feeGroupId != null)
                {
                    var feeGroupIdResult = await _feeGroupRepository.GetByIdAsync((Guid)feeGroupId);
                    if (feeGroupIdResult is null)
                    {
                        messages.Add($"{ResponseMessage.Values["NoData"]}: FeeGroupId.");
                        return (false, messages);
                    }
                }

                return (messages.Count == 0) ? (true, messages) : (false, messages);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
