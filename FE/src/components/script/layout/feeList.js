import Axios from "axios";

export default {
    data: function () {
        return {
            fee: [],
            feeNameModel: "",
            automaticSearchFeeName: null,
            tempFee: null,

            feeGroupModel: "",
            automaticSearchFeeGroup: null,

            feeAmountModel: "",
            automaticSearchFeeAmount: null,

            feeRangeModel: "",
            automaticSearchFeeRange: null,

            deleteList: [],
            booleanDeleteAll: false,
            deleteMessage: new String,
            singleDeleteId: null,
            isShowDelete: false,
            isShowDeleteAll: false,
            isShowImportant: false,

            isShowFollow: false,

            isShowLoading: false,
            messageError: new String,

            turnFeeList: [],
            isActiveTurnFee: false,
            isSelectedTurnFee: "",

            dialogActive: false,
            isFunc: {
                isAdd: 0,
                isUpdate: 0,
                isChosen: 0
            },
        };
    },
    methods: {
        /**
         * Thực hiện bật/tắt hiển thị khoản thu ngừng theo dõi
         */
        async showFollow() {
            this.isShowFollow = !this.isShowFollow;
            this.$store.commit("changeFeeFollow", this.isShowFollow);
            await this.requestFee();
        },
        /**
         * Thực hiện trả về trạng thái ban đầu
         */
        async reloadFee() {
            // Reset v-model
            this.feeNameModel = "";
            this.feeGroupModel = "";
            this.feeAmountModel = "";
            this.feeRangeModel = "";
            this.isSelectedTurnFee = "";
            this.isShowFollow = false;
            // Reset global
            let reset = {
                page: 1,
                pageSize: 10,
                feeName: null,
                feeGroupId: null,
                feeRangeId: null,
                turnFeeId: null,
                amountOfFee: null,
                follow: false
            }

            this.$store.commit("resetBodyFeePagination", reset);
            await this.requestFee();
        },
        /**
         * Đổi giá trị boolean cho đối tượng được click
         * @param {Vị trí của đối tượng được click} index 
         */
        selectDelete(index) {
            this.$set(this.deleteList, index, !this.deleteList[index])
        },
        /**
         * Bật/tắt tất cả giá trị xoá
         */
        selectDeleteAll() {
            this.booleanDeleteAll = !this.booleanDeleteAll;

            // Assign all child element is true or false
            let count = this.fee.length;
            if (this.booleanDeleteAll) {
                for (let index = 0; index < count; index++) {
                    this.$set(this.deleteList, index, true)
                }
            } else {
                for (let index = 0; index < count; index++) {
                    this.$set(this.deleteList, index, false)
                }
            }
        },
        /**
         * Tự động tìm kiếm FeeName
         */
        invokeSearchFeeName() {
            let timer = this.automaticSearchFeeName = Date.now();
            setTimeout(() => {
                if (timer == this.automaticSearchFeeName) {
                    this.$store.commit("changeFeeNameSearch", this.feeNameModel);
                    this.$store.commit("changePage", 1);
                    this.requestFee();
                }
            }, 600); // Thời gian nghỉ giữa mỗi lần gõ
        },
        /**
         * Tự động tìm kiếm FeeGroup
         */
        invokeSearchFeeGroup() {
            let timer = this.automaticSearchFeeGroup = Date.now();
            setTimeout(() => {
                if (timer == this.automaticSearchFeeGroup) {
                    // Tìm kiếm theo tên => id
                    let tempData = this.$store.state.apiFeeGroup.feeGroupList;

                    let tempIdSearch = tempData.find(x => this.ConvertUnicodeText(x.feeGroupName).includes(this.ConvertUnicodeText(this.feeGroupModel)));
                    let temp = this.feeGroupModel.trim();
                    if (temp === "")
                        this.$set(tempIdSearch, 'feeGroupId', null);
                    
                    this.$store.commit("changeFeeGroupSearch", tempIdSearch?.feeGroupId);
                    this.$store.commit("changePage", 1);
                    this.requestFee();
                }
            }, 600); // Thời gian nghỉ giữa mỗi lần gõ
        },
        /**
         * Chuyển đổi tiếng Việt -> không dấu
         * @param {Giá trị string cần chuyển đổi} str 
         * @returns Giá trị chuyển đổi về dạng ASCII
         */
        ConvertUnicodeText(str) {
            let search = str.toLowerCase().trim()
                .replace(/\s{2,}/g, ' ')
                .replace(/[àáảãạâầấẩẫậăằắẳẵặ]/g, 'a')
                .replace(/[èéẻẽẹêềếểễệ]/g, 'e')
                .replace(/[đ]/g, 'd')
                .replace(/[ìíỉĩị]/g, 'i')
                .replace(/[òóỏõọôồốổỗộơờớởỡợ]/g, 'o')
                .replace(/[ùúủũụưừứửữự]/g, 'u')
                .replace(/[ỳýỷỹỵ]/g, 'y')

            return search;
        },
        /**
         * Tự động tìm kiếm FeeAmount
         */
        invokeSearchFeeAmount() {
            let timer = this.automaticSearchFeeAmount = Date.now();
            setTimeout(() => {
                if (timer == this.automaticSearchFeeAmount) {
                    this.$store.commit("changeFeeAmountSearch", this.feeAmountModel);
                    this.$store.commit("changePage", 1);
                    this.requestFee();
                }
            }, 600); // Thời gian nghỉ giữa mỗi lần gõ
        },
        /**
         * Đổi giá trị boolean cho mục TurnFee filter
         */
        turnFeeClicking() {
            this.isActiveTurnFee = !this.isActiveTurnFee;
        },
        /**
         * Tìm kiếm dựa trên TurnFee
         * @param {Giá trị turn fee} turnFee 
         */
        invokeSearchTurnFee(turnFee) {
            this.isSelectedTurnFee = turnFee.name;
            // Checking get all
            if (parseInt(turnFee.id) === -1) {
                this.$set(turnFee, 'id', null)
            }

            this.$store.commit("changeTurnFeeSearch", turnFee.id);
            this.$store.commit("changePage", 1);
            this.requestFee();
        },
        /**
         * Tự động tìm kiếm FeeRange
         */
        invokeSearchFeeRange() {
            let timer = this.automaticSearchFeeRange = Date.now();
            setTimeout(() => {
                if (timer == this.automaticSearchFeeRange) {
                    // Tìm kiếm theo tên => id
                    let tempData = this.$store.state.apiFeeRange.feeRangeList;

                    let tempIdSearch = tempData.find(x => this.ConvertUnicodeText(x.feeRangeName).includes(this.ConvertUnicodeText(this.feeRangeModel)));
                    let temp = this.feeRangeModel.trim();
                    if (temp === "")
                        this.$set(tempIdSearch, 'feeRangeId', null);

                    this.$store.commit("changeFeeRangeSearch", tempIdSearch?.feeRangeId);
                    this.$store.commit("changePage", 1);
                    this.requestFee();
                }
            }, 600); // Thời gian nghỉ giữa mỗi lần gõ
        },
        /**
         * Khởi tạo giá trị lần đầu
         */
        async requestBody() {
            await this.requestFee();
            await this.requestFeeGroup();
            await this.requestFeeRange();
            await this.requestUnitFee();
            await this.requestTurnFee();
            await this.requestQuality();
        },
        /**
         * Gọi request, lấy ra giá trị Fee
         */
        async requestFee() {
            let URI = this.$store.getters.getPaginationFee;
            let body = this.$store.state.apiFee.bodyPagination;

            let tempPOST = (await Axios.post(URI, body));

            this.fee = tempPOST.data.resource;

            let pagination = {
                page: tempPOST.data.page,
                pageSize: tempPOST.data.pageSize,
                firstPage: tempPOST.data.firstPage,
                lastPage: tempPOST.data.lastPage,
                totalPages: tempPOST.data.totalPages,
                totalRecords: tempPOST.data.totalRecords,
                nextPage: tempPOST.data.nextPage,
                previousPage: tempPOST.data.previousPage
            }

            this.$store.commit("getFeePagination", pagination);
        },
        /**
         * Gọi request, lấy ra giá trị FeeGroup
         */
        async requestFeeGroup() {
            let URI = this.$store.getters.getFeeGroup;

            var tempFeeGroup = (await Axios.get(URI)).data.resource;

            // Assign into vuex, sharing data with form-input component
            this.$store.commit("changeFeeGroupList", tempFeeGroup);
        },
        /**
         * Gọi request, lấy ra giá trị FeeRange
         */
        async requestFeeRange() {
            let URI = this.$store.getters.getFeeRange;
            var tempFeeRange = (await Axios.get(URI)).data.resource;

            // Assign into vuex, sharing data with form-input component
            this.$store.commit("changeFeeRangeList", tempFeeRange);
        },
        /**
         * Gọi request, lấy ra giá trị UnitFee
         */
        async requestUnitFee() {
            let URI = this.$store.getters.getUnitFee;
            var tempUnitFee = (await Axios.get(URI)).data.resource;

            // Assign into vuex, sharing data with form-input component
            this.$store.commit("changeUnitFeeList", tempUnitFee);

        },
        /**
         * Gọi request, lấy ra giá trị TurnFee
         */
        async requestTurnFee() {
            let URI = this.$store.getters.getTurnFee;
            var tempTurnFee = (await Axios.get(URI)).data.resource;

            // Assign into vuex, sharing data with form-input component
            this.$store.commit("changeTurnFeeList", tempTurnFee);

            let tempTurnFeeList = [{
                id: -1,
                name: "Tất cả"
            }]
            this.turnFeeList = tempTurnFeeList.concat(tempTurnFee);
        },
        /**
         * Gọi request, lấy ra giá trị Quality
         */
        async requestQuality() {
            let URI = this.$store.getters.getQuality;
            var tempQuality = (await Axios.get(URI)).data.resource;

            // Assign into vuex, sharing data with form-input component
            this.$store.commit("changeQualityList", tempQuality);
        },
        /**
         * Gọi request, xoá giá trị Fee
         */
        async deleteFeeRequest() {
            // Add loading animation
            this.isShowLoading = true;
            this.messageError = "Đang xử lí...";
            try {
                let URI = `${this.$store.getters.getDeleteFee}/${this.singleDeleteId}`;
                let responseBE = await Axios.delete(URI);

                if (responseBE?.status == "201" || responseBE?.status == "200") {
                    this.messageError = "Xoá thành thành công";
                    this.deleteList = new Array();
                    this.booleanDeleteAll = false;
                    setTimeout(() => {
                        this.isShowLoading = false;
                        this.hidePopUpDelete();
                    }, 1000);
                } else {
                    setTimeout(() => {
                        this.isShowLoading = false;
                    }, 2000);
                }
            } catch (error) {
                if (error.response) {
                    console.log(error.response.data);
                    this.messageError = `Lỗi: ${error.response.data.message.toString()}`;
                } else {
                    this.messageError = "Đã xảy ra lỗi, vui lòng thử lại sau."
                }
                setTimeout(() => {
                    this.isShowLoading = false;
                }, 2000);
            }
        },
        /**
         * Gọi request, xoá nhiều giá trị Fee
         */
        async deleteAllRequest() {
            // Add loading animation
            this.isShowLoading = true;
            this.messageError = "Đang xử lí...";

            let body = {
                listDelete: this.getItemForDelete(),
            }

            try {
                let URI = this.$store.getters.getDeleteAllFee;
                let responseBE = await Axios.post(URI, body);

                if (responseBE?.status == "201" || responseBE?.status == "200") {
                    this.messageError = "Xoá thành thành công";
                    // Reset list delete required
                    this.deleteList = new Array();
                    this.booleanDeleteAll = false;
                    setTimeout(() => {
                        this.isShowLoading = false;
                        this.hidePopUpDelete();
                    }, 1000);
                } else {
                    setTimeout(() => {
                        this.isShowLoading = false;
                    }, 2000);
                }
            } catch (error) {
                if (error.response) {
                    console.log(error.response.data);
                    this.messageError = `Lỗi: ${error.response.data.message.toString()}`;
                } else {
                    this.messageError = "Đã xảy ra lỗi, vui lòng thử lại sau."
                }
                setTimeout(() => {
                    this.isShowLoading = false;
                }, 2000);
            }
        },
        /**
         * Hàm xoá đối tượng Fee
         * @param {Id của đối tượng muốn xoá} id 
         * @param {Xác nhận có chắc chắn xoá không} isConfirm 
         */
        async deleteItem(id, isConfirm) {
            if (isConfirm) {
                // Xoá chính thức
                this.hidePopUpDelete();
                await this.deleteFeeRequest();
                await this.requestFee();
            }
            else {
                // Xác nhận có xoá không?
                // Check value Important
                if (this.fee[id] && !this.fee[id]?.important) {
                    this.deleteMessage = "Bạn có chắc chắn muốn xoá khoản thu đã chọn.";
                    this.isShowImportant = false;
                    this.isShowDelete = true;
                    this.singleDeleteId = this.fee[id].feeId;
                } else {
                    this.deleteMessage = "Bạn không thể xoá dữ liệu của hệ thống.";
                    this.isShowDelete = false;
                    this.isShowImportant = true;
                }
                // Show pop up confirm
            }
        },
        /**
         * Hàm thực hiện cho xoá nhiều đối tượng Fee
         * @param {Xác nhận chắc chắn muốn xoá đối tượng không} isConfirm 
         */
        async deleteAllItem(isConfirm) {
            if (isConfirm) {
                // Xoá chính thức
                this.hidePopUpDelete();
                await this.deleteAllRequest();

                await this.requestFee();

            }
            else {
                // Xác nhận có xoá không?
                this.deleteAllChecking();
            }
        },
        /**
         * Kiểm tra giá trị muốn xoá có hợp lệ?
         * @returns Giá trị null nếu thuộc tính có important: true
         */
        deleteAllChecking() {
            // Block detecting element required
            let countDeleteList = this.deleteList?.length;
            let tempDeleteList = new Array();

            for (let index = 0; index < countDeleteList; index++) {
                if (this.deleteList[index]) {
                    tempDeleteList.push(index);
                }
            }

            // Block checking list required is null
            let isEmpty = tempDeleteList.length ? true : false;
            if (!isEmpty) {
                this.deleteMessage = "Không có dữ liệu nào được chọn.";
                this.isShowDeleteAll = false;
                this.isShowDelete = false;
                this.isShowImportant = true;
                return null;
            }

            // Block checking important property of fee
            let isImportant = false;
            tempDeleteList.forEach(x => {
                if (this.fee[x]?.important == true) {
                    isImportant = true;
                }
            });

            if (isImportant) {
                // Mảng xoá có chứa đối tượng important true
                this.deleteMessage = "Bạn không thể xoá dữ liệu của hệ thống, vui lòng kiểm tra lại.";
                this.isShowDeleteAll = false;
                this.isShowDelete = false;
                this.isShowImportant = true;
            } else {
                // Mảng xoá hợp lệ
                this.deleteMessage = "Bạn có chắc chắn muốn xoá những khoản thu đã chọn.";
                this.isShowDeleteAll = true; // Sử dụng func của xoá tất cả
                this.isShowDelete = false; // Ẩn đi func không cần sử dụng
                this.isShowImportant = false; // Ẩn đi func không cần sử dụng
            }
        },
        /**
         * Lấy ra danh sách các đối tượng mong muốn xoá
         * @returns Danh sách các đối tượng muốn xoá
         */
        getItemForDelete() {
            let tempListReturn = new Array();

            // Block detecting element required
            let countDeleteList = this.deleteList?.length;
            let tempDeleteList = new Array();

            for (let index = 0; index < countDeleteList; index++) {
                if (this.deleteList[index]) {
                    tempDeleteList.push(index);
                }
            }

            tempDeleteList.forEach(x => {
                if (this.fee[x])
                    tempListReturn.push(this.fee[x]?.feeId);
            });

            return tempListReturn;
        },
        /**
         * Ẩn hết pop-up xoá
         */
        hidePopUpDelete() {
            this.isShowDelete = false;
            this.isShowImportant = false;
            this.isShowDeleteAll = false;
        },
        /**
         * Thực hiện hành động sau khi thêm mới giá trị Fee
         * @param {Giá trị Fee xoá khi được thêm mới} response 
         */
        responseAddItem(response) {
            if (response) {
                // Add temp item to list
                this.fee.unshift(response);
                let checkSize = this.$store.state.apiFee.responsePagination.pageSize;
                if (this.fee.length > checkSize) {
                    this.fee.pop(response);
                }
                this.dialogActive = false;
            } else {
                // Pop-up error is actived
                this.dialogActive = false;
            }
        },
        /**
         * Thực hiện hành động sau khi "lưu thêm mới" giá trị Fee
         * @param {Giá trị Fee sau khi được lưu và thêm} response 
         */
        responseSaveAs(response) {
            if (response) {
                // Add temp item to list
                this.fee.unshift(response);
                let checkSize = this.$store.state.apiFee.responsePagination.pageSize;
                if (this.fee.length > checkSize) {
                    this.fee.pop(response);
                }
            }
        },
        /**
         * Thực hiện hành động sau khi cập nhật giá trị Fee
         * @param {Giá trị Fee sau khi cập nhật} response 
         */
        responseUpdateItem(response) {
            if (response) {
                // Add temp item to list
                let indexOfUpdateItem = this.fee.findIndex(x => x?.feeId == response?.feeId);
                this.fee[indexOfUpdateItem] = response;
                this.dialogActive = false;
            } else {
                // Pop-up is actived
                this.dialogActive = false;
            }
        },
        /**
         * Hàm xử lí chức năng Tạo mới, Cập nhật
         */
        callFuncDiaglog(isFunc, tempFee) {
            if (isFunc) {
                // Dialog Update
                this.tempFee = tempFee;
                this.isFunc.isUpdate += 2;
                this.isFunc.isChosen = this.isFunc.isUpdate;
            } else {
                // Dialog Add
                this.tempFee = tempFee;
                this.isFunc.isAdd -= 2;
                this.isFunc.isChosen = this.isFunc.isAdd;
            }
            this.dialogActive = true;
        },
        /**
         * Lấy ra tên của Unit Fee theo Id
         * @param {Id của UnitFee} id 
         * @returns Tên của Unit Fee
         */
        unitFeeIdToText(id) {
            let tempList = this.$store.state.apiUnitFee.unitFeeList;
            return tempList.find(x => x.unitFeeId == id)?.unitFeeName;
        },
        /**
         * Chuyển đổi số -> số phân cách dấu chấm
         * @param {Giá trị tiền tệ} money 
         * @returns Giá trị được định dạng phân cách bớI dấu chấm
         */
        formatMoney(money) {
            if (!isNaN(money)) {
                return money.toString().replace(/(\d)(?=(\d{3})+(?:\.\d+)?$)/g, "$1.");
            } else {
                return money;
            }
        },
        /**
         * Lấy ra tên của Turn Fee dựa theo Id
         * @param {Id của Turn Fee} turnFeeId 
         * @returns Tên của Turn Fee
         */
        turnFeeIdToText(turnFeeId) {
            let tempList = this.$store.state.apiTurnFee.turnFeeList;
            return tempList.find(x => x.id == turnFeeId)?.name;
        },
    },
    created() {
        this.requestBody()
    },
};