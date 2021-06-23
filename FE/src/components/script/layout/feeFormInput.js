import Axios from "axios";

export default {
    props: {
        feeProp: Object,
        isCallFunc: Number,
    },
    data: () => ({
        fee: {
            feeName: null,
            feeGroupId: null,
            feeRangeId: null,
            unitFeeId: null,
            turnFee: null,
            discount: false,
            amountOfFee: 0,
            allowExportLicense: false,
            feeRequired: false,
            allowReturn: false,
            allowExportBill: false,
            feePrivate: false,
            typeRegistion: false,
            quality: null,
            follow: false
        },

        feeId: new String,

        isValid: false,
        tempAmount: "",

        tempFeeName: 0,

        isCheckFeeName: true,
        isCheckFeeAmount: true,
        isCheckFeeRange: true,
        isCheckFeeUnit: true,

        tempCheckTurnFee: [],

        isLoading: false,
        messageError: "Đang xử lí...",

        title: "",
        hasSaveAsButton: false,
    }),
    computed: {
        /**
         * Tạo dữ liệu tuỳ chỉnh cho mảng FeeGroup
         * @returns Giá trị Mảng FeeGroup
         */
        feeGroupList() {
            let feeGroupList = this.$store.state.apiFeeGroup.feeGroupList;
            let tempFeeGroupList = [{
                feeGroupId: "-1",
                feeGroupName: "Bỏ trống",
                parentId: "2000637a-2a69-2e7e-a135-f63bd3f197bd",
                createdDate: "2008-07-13T07:52:14",
                createdBy: "NDDONG",
                modifiedDate: "2017-04-21T03:20:55"
            }]
            return tempFeeGroupList.concat(feeGroupList);
        },
        /**
         * Tạo dữ liệu tuỳ chỉnh cho mảng FeeQuality
         * @returns Tạo dữ liệu tuỳ chỉnh cho mảng FeeQuality
         */
        feeQualityList() {
            let feeQualityList = this.$store.state.apiQuality.qualityList;
            let tempFeeQualityList = [{
                id: -1,
                name: "Bỏ trống"
            }]
            return tempFeeQualityList.concat(feeQualityList);
        },
        /**
         * Cập nhật sự thay đổi của mảng FeeRange
         * @returns Gia trị mảng FeeRange
         */
        feeRangeList() {
            return this.$store.state.apiFeeRange.feeRangeList;
        },
        /**
         * Cập nhật sự thay đổi của mảng TurnFee
         * @returns Giá trị mảng TurnFee
         */
        turnFeeList() {
            return this.$store.state.apiTurnFee.turnFeeList;
        },
        /**
         * Cập nhật sự thay đổi của mảng UnitFee
         * @returns Giá trị mảng UnitFee
         */
        unitFeeList() {
            return this.$store.state.apiUnitFee.unitFeeList;
        },
        /**
         * Theo dõi giá trị của FeeName
         */
        trackingFeeName() {
            return this.fee.feeName;
        },
        /**
         * Theo dõi giá trị của Amount
         */
        trackingFeeAmount() {
            return this.fee.amountOfFee;
        },
        /**
         * Theo dõi giá trị của Unit
         */
        trackingFeeUnit() {
            return this.fee.unitFeeId;
        },
        /**
         * Theo dõi giá trị của FeeRange
         */
        trackingFeeRange() {
            return this.fee.feeRangeId;
        },
    },
    methods: {
        /**
         * Thay đổi giá trị cho thuộc tính Follow
         */
        feeFollowChange() {
            this.fee.follow = !this.fee.follow;
        },
        /**
         * Thay đổi giá trị cho thuộc tính Discount
         */
        feeDiscountChange() {
            this.fee.discount = !this.fee.discount;
        },
        /**
         * Thay đổi giá trị cho thuộc tính Required
         */
        feeRequiredChange() {
            this.fee.feeRequired = !this.fee.feeRequired;
        },
        /**
         * Thay đổi giá trị cho thuộc tính AllowExportBill
         */
        feeAllowExportBillChange() {
            this.fee.allowExportBill = !this.fee.allowExportBill;
        },
        /**
         * Thay đổi giá trị cho thuộc tính TypeRegistion
         */
        feeTypeRegistionChange() {
            this.fee.typeRegistion = !this.fee.typeRegistion;
        },
        /**
         * Thay đổi giá trị cho thuộc tính AllowExportLicense
         */
        feeAllowExportLicenseChange() {
            this.fee.allowExportLicense = !this.fee.allowExportLicense;
        },
        /**
         * Thay đổi giá trị cho thuộc tính AllowReturn
         */
        feeAllowReturnChange() {
            this.fee.allowReturn = !this.fee.allowReturn;
        },
        /**
         * Thay đổi giá trị cho thuộc tính Private
         */
        feePrivateChange() {
            this.fee.feePrivate = !this.fee.feePrivate;
        },
        /**
         * Hàm emit "emitShowPopup", giúp ẩn pop-up đang hiện
         */
        hidePopup() {
            this.$emit("emitShowPopup", false);
        },
        /**
         * Kiểm tra dữ liệu nhập vào có đúng yêu cầu
         * @returns Giá trị boolean cho việc validate lưu, lưu mớI
         */
        validateFee() {
            let feeName = this.fee.feeName;
            let feeRange = this.fee.feeRangeId;
            let feeAmount = this.fee.amountOfFee;
            let feeUnit = this.fee.unitFeeId;

            if (!feeName)
                this.isCheckFeeName = false;
            else
                this.isCheckFeeName = true;

            if (!feeRange)
                this.isCheckFeeRange = false;
            else
                this.isCheckFeeRange = true;

            if (feeAmount <= 0)
                this.isCheckFeeAmount = false;
            else
                this.isCheckFeeAmount = true;

            if (!feeUnit)
                this.isCheckFeeUnit = false;
            else
                this.isCheckFeeUnit = true;

            if (!feeName || !feeRange || !feeAmount || !feeUnit) {
                return false;
            }
            return true;
        },
        /**
         * Thực hiện gọi axios post, thêm mới Fee
         */
        async insertFeeRequest() {
            // Add loading animation
            this.isLoading = true;
            this.messageError = "Đang xử lí...";
            try {
                let responseBE = await this.postRequest(this.fee);
                if (responseBE?.status == "201" || responseBE?.status == "200") {
                    this.messageError = "Thêm mới thành công";
                    setTimeout(() => {
                        this.isLoading = false;
                        this.$emit("addMethodFee", responseBE.data.resource);
                    }, 1000);
                } else {
                    setTimeout(() => {
                        this.isLoading = false;
                    }, 2000);
                }
            } catch (error) {
                setTimeout(() => {
                    this.isLoading = false;
                }, 2000);
            }
        },
        /**
         * Thực hiện gọi axios post, lưu và thêm mới Fee
         */
        async saveAsFeeRequest() {
            // Add loading animation
            this.isLoading = true;
            this.messageError = "Đang xử lí...";
            try {
                let responseBE = await this.postRequest(this.fee);
                if (responseBE?.status == "201" || responseBE?.status == "200") {
                    this.messageError = "Thêm mới thành công";
                    setTimeout(() => {
                        this.isLoading = false;
                        this.$emit("saveAsMethodFee", responseBE.data.resource);
                    }, 1000);
                } else {
                    setTimeout(() => {
                        this.isLoading = false;
                    }, 2000);
                }
            } catch (error) {
                setTimeout(() => {
                    this.isLoading = false;
                }, 2000);
            }
        },
        /**
         * Thực hiện gọi axios put, cập nhật Fee đã có
         */
        async updateFeeRequest() {
            // Add loading animation
            this.isLoading = true;
            this.messageError = "Đang xử lí...";
            try {
                let responseBE = await this.putRequest(this.fee);
                if (responseBE?.status == "201" || responseBE?.status == "200") {
                    this.messageError = "Cập nhật thành công";
                    setTimeout(() => {
                        this.isLoading = false;
                        this.$emit("updateMethodFee", responseBE.data.resource);
                    }, 1000);
                } else {
                    setTimeout(() => {
                        this.isLoading = false;
                    }, 2000);
                }
            } catch {
                setTimeout(() => {
                    this.isLoading = false;
                }, 2000);
            }
        },
        /**
         * Chuyển đổi dữ liệu sang null, trước khi gửi request tới BE
         */
        confirmDataBeforeUsing() {
            if (this.fee.feeGroupId == -1)
                this.$set(this.fee, 'feeGroupId', null);
            if (this.fee.quality == -1)
                this.$set(this.fee, 'quality', null);
            if (!this.fee.feeGroupId)
                this.$set(this.fee, 'feeGroupId', null);
        },
        /**
         * Gán lại giá trị mới sau mỗi lần thêm mới Fee
         */
        resetDataBeforeUsing() {
            let tempFee = {
                feeName: "",
                feeGroupId: "",
                feeRangeId: "",
                unitFeeId: "",
                turnFee: 0,
                discount: false,
                amountOfFee: 0,
                allowExportLicense: false,
                feeRequired: false,
                allowReturn: false,
                allowExportBill: false,
                feePrivate: false,
                typeRegistion: false,
                quality: null,
                follow: false
            };
            this.assignFee(tempFee);
            this.assignValidateProperties();
        },
        /**
         * Thực hiện xử lí chức năng cho nút Lưu
         */
        save() { // Nút Lưu
            // Validate data input
            if (this.validateFee()) {
                if (this.isCallFunc < 0) {
                    // Dialog Add
                    this.confirmDataBeforeUsing();
                    this.insertFeeRequest();
                }
                else {
                    // Dialog Update
                    this.confirmDataBeforeUsing();
                    this.updateFeeRequest();
                }
            }
        },
        /**
         * Thực hiện xử lí chức năng cho nút Lưu và thêm mới
         */
        saveAs() { // Nút Lưu thêm mới
            // Validate data input
            if (this.validateFee()) {
                this.confirmDataBeforeUsing();
                this.saveAsFeeRequest();
                this.resetDataBeforeUsing();
            }
        },
        /**
         * Thực hiện kiểm tra click cho TurnFee,
         * sao cho 1 lần chỉ 1 đối tượng được hiển thị
         * @param {Vị trí của phần tử click} index 
         * @param {Giá trị TurnFee} valueItem 
         */
        checkTurnFeeClick(index, valueItem) {
            let count = this.tempCheckTurnFee.length ? this.tempCheckTurnFee.length : 0;
            for (let i = 0; i < count; i++) {
                if (index == i) {
                    this.$set(this.tempCheckTurnFee, i, true);
                    this.fee.turnFee = valueItem?.id;
                }
                else {
                    this.$set(this.tempCheckTurnFee, i, false);
                }
            }
        },
        /**
         * Thực hiện gửi request post dữ liệu tới be server
         * @param {Tham số truyền vào cho request} body 
         * @returns Giá trị trả về của server
         */
        async postRequest(body) {
            try {
                let URI = this.$store.getters.getInsertFee;
                let tempPost = await Axios.post(URI, body);

                return tempPost;
            } catch (error) {
                if (error.response) {
                    console.log(error.response.data);
                    this.messageError = `Lỗi: ${error.response.data.message.toString()}`;
                } else {
                    this.messageError = "Đã xảy ra lỗi, vui lòng thử lại sau."
                }
            }
        },
        /**
         * Thực hiện gửi request put dữ liệu tới be server
         * @param {Tham số truyền vào cho request} body 
         * @returns Giá trị trả về của server
         */
        async putRequest(body) {
            try {
                let URI = `${this.$store.getters.getInsertFee}/${this.feeId}`;

                let tempPut = (await Axios.put(URI, body));

                return tempPut;
            } catch (error) {
                if (error.response) {
                    console.log(error.response.data);
                    this.messageError = `Lỗi: ${error.response.data.message.toString()}`;
                } else {
                    this.messageError = "Đã xảy ra lỗi, vui lòng thử lại sau."
                }
            }
        },
        /**
         * Chuyển đối giá trị kiểu số sang kiểu text 
         * có phân cách bởi dấu chấm giữa phần ngàn đơn vị
         * @param {Giá trị "tiền" cần chuyển đổi} money 
         * @returns Giá trị tiền có phân cách các phần vớI dấu chấm
         */
        formatMoney(money) {
            let tempData = money.toString().replace(/\D/g, '');
            return tempData.toString().replace(/(\d)(?=(\d{3})+(?:\.\d+)?$)/g, "$1.");

        },
        /**
         * Chuyển đổi giá trị từ text -> số
         * điều kiện hợp lệ > 0,
         * ngược lại trả -1
         * @param {Giá trị cần chuyển đổi} value 
         * @returns Giá trị số sau khi chuyển đổi
         */
        moneyToNumber(value) {
            let tempData = value.toString().replace(/\D/g, '');
            if (!isNaN(tempData) && parseInt(tempData) > 0) {
                return parseInt(tempData);
            } else {
                return -1;
            }
        },
        /**
         * Gán dữ liệu mới cho Fee
         * @param {Dữ liệu để gán cho Fee} resource 
         */
        assignFee(resource) {
            // Id using in editing data
            this.feeId = resource.feeId;

            if (!resource.amountOfFee) {
                this.tempAmount = new String;
            } else {
                this.tempAmount = resource.amountOfFee;
            }

            if (!resource.feeGroup) {
                this.$set(this.fee, 'feeGroupId', "");
            } else {
                this.$set(this.fee, 'feeGroupId', resource.feeGroupId);
            }

            if (!resource.feeRange) {
                this.$set(this.fee, 'feeRangeId', "");
            } else {
                this.$set(this.fee, 'feeRangeId', resource.feeRange.feeRangeId);
            }

            if (!resource.unitFee) {
                this.$set(this.fee, 'unitFeeId', "");
            } else {
                this.$set(this.fee, 'unitFeeId', resource.unitFee.unitFeeId);
            }

            this.$set(this.fee, 'feeName', resource.feeName);
            this.$set(this.fee, 'turnFee', resource.turnFee);
            this.$set(this.fee, 'discount', resource.discount);
            this.$set(this.fee, 'amountOfFee', resource.amountOfFee);
            this.$set(this.fee, 'allowExportLicense', resource.allowExportLicense);
            this.$set(this.fee, 'feeRequired', resource.feeRequired);
            this.$set(this.fee, 'allowReturn', resource.allowReturn);
            this.$set(this.fee, 'allowExportBill', resource.allowExportBill);
            this.$set(this.fee, 'feePrivate', resource.feePrivate);
            this.$set(this.fee, 'typeRegistion', resource.typeRegistion);
            this.$set(this.fee, 'quality', resource.quality);
            this.$set(this.fee, 'follow', resource.follow);
        },
        /**
         * Gán lại giá trị cho các biến kiểm tra điều kiện
         */
        assignValidateProperties() {
            this.isCheckFeeName = true;
            this.isCheckFeeAmount = true;
            this.isCheckFeeRange = true;
            this.isCheckFeeUnit = true;
        },
        /**
         * Gán giá trị mặc định cho TurnFee
         * nếu người dùng không lựa chọn lại giá trị
         */
        assignTurnFeeSelected() {
            let turnFee = this.turnFeeList;
            let count = turnFee?.length ? turnFee?.length : 0;
            for (let index = 0; index < count; index++) {
                if (index === 0 && !this.fee.turnFee) {
                    this.$set(this.tempCheckTurnFee, index, true);
                    this.$set(this.fee, 'turnFee', turnFee[index].id);
                }
                else {
                    this.$set(this.tempCheckTurnFee, index, false);
                }

                if (this.fee.turnFee && turnFeeList[index] == this.fee.turnFee)
                    this.$set(this.tempCheckTurnFee, index, true);
            }
        }
    },
    created() {
        this.assignTurnFeeSelected()
    },
    watch: {
        /**
         * Theo dõi giá trị thay đổi của trackingFeeAmount
         * @param {Giá trị thay đổi của trackingFeeAmount} value 
         * @returns 
         */
        trackingFeeAmount: function (value) {
            if(value == "")
                return null;

            if (value) {
                this.isCheckFeeAmount = true;
            } else {
                this.isCheckFeeAmount = false;
            }
        },
        /**
         * Theo dõi giá trị thay đổi của trackingFeeName
         * @param {Giá trị thay đổi của trackingFeeName} value 
         * @returns 
         */
        trackingFeeName: function (value) {
            if(value == "")
                return null;

            if (value) {
                this.isCheckFeeName = true;
            } else {
                this.isCheckFeeName = false;
            }
        },
        /**
         * Theo dõi giá trị thay đổi của trackingFeeUnit
         * @param {Giá trị thay đổi của trackingFeeUnit} value 
         * @returns 
         */
        trackingFeeUnit: function (value) {
            if(value == "")
                return null;

            if (value) {
                this.isCheckFeeUnit = true;
            } else {
                this.isCheckFeeUnit = false;
            }
        },
        /**
         * Theo dõi giá trị thay đổi của trackingFeeRange
         * @param {Giá trị thay đổi của trackingFeeRange} value 
         * @returns 
         */
        trackingFeeRange: function (value) {
            if(value == "")
                return null;

            if (value) {
                this.isCheckFeeRange = true;
            } else {
                this.isCheckFeeRange = false;
            }
        },
        /**
         * Theo dõi giá trị thay đổi của assignTurnFeeSelected
         */
        turnFeeList: function (newVal) {
            this.assignTurnFeeSelected();
        },
        /**
         * Theo dõi giá trị thay đổi của tempData
         * @param {Giá trị thay đổi của tempData} value 
         */
        tempAmount: function (value) {
            this.tempAmount = this.formatMoney(value);

            // Convert money text to money int
            let tempData = this.moneyToNumber(this.tempAmount);
            if (tempData > 0) {
                this.$set(this.fee, 'amountOfFee', tempData);
            }
        },
        /**
         * Theo dõi giá trị thay đổi của is-call-func prop
         * @param {Giá trị thay đổi của is-call-func prop} newVal 
         */
        isCallFunc: function (newVal) {
            if (newVal < 0) {
                // Dialog Add
                this.title = "Thêm khoản thu";
                this.hasSaveAsButton = true;

                if (this.feeProp) {
                    this.assignFee(this.feeProp);
                    this.assignValidateProperties();
                }
                else {
                    this.resetDataBeforeUsing();
                }
            }
            else {
                // Dialog Update
                this.title = "Sửa khoản thu";
                this.hasSaveAsButton = false;
                this.assignValidateProperties();
                this.assignFee(this.feeProp);
            }
        }
    }
};