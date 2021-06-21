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
            options: {
                autoHide: false,
                content: "Xoá tất cả đối tượng đã chọn",
                classes: "tooltip-reload"
            }
        };
    },
    computed: {
    },
    methods: {
        async showFollow() {
            this.isShowFollow = !this.isShowFollow;
            this.$store.commit("changeFeeFollow", this.isShowFollow);
            await this.requestFee();
        },
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
        assignCheckedDelete(i) {
            return (deleteList[i]) ? false : true;
        },
        selectDelete(index) {
            this.$set(this.deleteList, index, !this.deleteList[index])
        },
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
        ConvertUnicodeText(str) {
            let search = str.replace(/[àáảãạâầấẩẫậăằắẳẵặ]/g, 'a')
                .replace(/[èéẻẽẹêềếểễệ]/g, 'e')
                .replace(/[đ]/g, 'd')
                .replace(/[ìíỉĩị]/g, 'i')
                .replace(/[òóỏõọôồốổỗộơờớởỡợ]/g, 'o')
                .replace(/[ùúủũụưừứửữự]/g, 'u')
                .replace(/[ỳýỷỹỵ]/g, 'y')

            return search.toLowerCase().trim();
        },
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
        turnFeeClicking() {
            this.isActiveTurnFee = !this.isActiveTurnFee;
        },
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
        async requestBody() {
            await this.requestFee();
            await this.requestFeeGroup();
            await this.requestFeeRange();
            await this.requestUnitFee();
            await this.requestTurnFee();
            await this.requestQuality();
        },
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
        async requestFeeGroup() {
            let URI = this.$store.getters.getFeeGroup;

            var tempFeeGroup = (await Axios.get(URI)).data.resource;

            // Assign into vuex, sharing data with form-input component
            this.$store.commit("changeFeeGroupList", tempFeeGroup);
        },
        async requestFeeRange() {
            let URI = this.$store.getters.getFeeRange;
            var tempFeeRange = (await Axios.get(URI)).data.resource;

            // Assign into vuex, sharing data with form-input component
            this.$store.commit("changeFeeRangeList", tempFeeRange);
        },
        async requestUnitFee() {
            let URI = this.$store.getters.getUnitFee;
            var tempUnitFee = (await Axios.get(URI)).data.resource;

            // Assign into vuex, sharing data with form-input component
            this.$store.commit("changeUnitFeeList", tempUnitFee);

        },
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
        async requestQuality() {
            let URI = this.$store.getters.getQuality;
            var tempQuality = (await Axios.get(URI)).data.resource;

            // Assign into vuex, sharing data with form-input component
            this.$store.commit("changeQualityList", tempQuality);
        },
        async deleteFeeRequest() {
            // Add loading animation
            this.isShowLoading = true;
            this.messageError = "Đang xử lí...";
            try {
                let URI = `${this.$store.getters.getDeleteFee}/${this.singleDeleteId}`;
                let responseBE = await Axios.delete(URI);

                if (responseBE?.status == "201" || responseBE?.status == "200") {
                    this.messageError = "Xoá thành thành công";
                    setTimeout(() => {
                        this.isShowLoading = false;
                        this.hidePopUpDelete();
                    }, 2000);
                } else {
                    setTimeout(() => {
                        this.isShowLoading = false;
                    }, 3000);
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
                }, 3000);
            }
        },
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
                    setTimeout(() => {
                        this.isShowLoading = false;
                        this.hidePopUpDelete();
                    }, 2000);
                } else {
                    setTimeout(() => {
                        this.isShowLoading = false;
                    }, 3000);
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
                }, 3000);
            }
        },
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
        async deleteAllItem(isConfirm) {
            if (isConfirm) {
                // Xoá chính thức
                this.hidePopUpDelete();
                await this.deleteAllRequest();

                // Reset list delete required
                this.deleteList = new Array();

                await this.requestFee();

            }
            else {
                // Xác nhận có xoá không?
                this.deleteAllChecking();
            }
        },
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
        hidePopUpDelete() {
            this.isShowDelete = false;
            this.isShowImportant = false;
            this.isShowDeleteAll = false;
        },
        responseAddItem(response) {
            if (response) {
                // Add temp item to list
                this.fee.unshift(response);
                let checkSize = this.$store.state.apiFee.responsePagination.pageSize;
                if (this.fee.length > checkSize){
                    this.fee.pop(response);
                }

                this.dialogActive = false;
            } else {
                // Pop-up error is actived

                this.dialogActive = false;
            }
        },
        responseSaveAs(response) {
            if (response) {
                // Add temp item to list
                this.fee.pop(response);
                this.fee.unshift(response);
            }
        },
        responseUpdateItem(response) {
            if (response) {
                // Add temp item to list
                let indexOfUpdateItem = this.fee.findIndex(x => x?.feeId == response?.feeId);
                this.fee[indexOfUpdateItem] = response;
                this.dialogActive = false;
            } else {
                // Pop-up error is actived
                // TODO: Later on
                this.dialogActive = false;
            }
        },
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
        unitFeeIdToText(id) {
            let tempList = this.$store.state.apiUnitFee.unitFeeList;
            return tempList.find(x => x.unitFeeId == id)?.unitFeeName;
        },
        formatMoney(money) {
            if (!isNaN(money)) {
                return money.toString().replace(/(\d)(?=(\d{3})+(?:\.\d+)?$)/g, "$1.");
            } else {
                return money;
            }
        },
        turnFeeIdToText(turnFeeId) {
            let tempList = this.$store.state.apiTurnFee.turnFeeList;
            return tempList.find(x => x.id == turnFeeId)?.name;
        },
    },
    created() {
        this.requestBody()
    },
};