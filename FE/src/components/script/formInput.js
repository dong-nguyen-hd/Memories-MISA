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
        tempAmount: " ",

        tempFeeName: 0,

        isCheckFeeName: true,
        isCheckFeeAmount: true,
        isCheckFeeRange: true,
        isCheckFeeUnit: true,

        tempCheckTurnFee: [],

        blockGender: {
            searchText: new String,
            tempGender: [{
                id: 1,
                name: "Nam"
            },
            {
                id: 0,
                name: "Nữ"
            },
            {
                id: 2,
                name: "Khác"
            }
            ],
            arrowCounter: 0,
            results: [],
            isOpen: false,
            showUp: false,
        },
        isLoading: false,
        messageError: "Đang xử lí...",

        title: new String,
        hasSaveAsButton: false,
    }),
    computed: {
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
        feeQualityList() {
            let feeQualityList = this.$store.state.apiQuality.qualityList;
            let tempFeeQualityList = [{
                id: -1,
                name: "Bỏ trống"
            }]
            return tempFeeQualityList.concat(feeQualityList);
        },
        feeRangeList() {
            return this.$store.state.apiFeeRange.feeRangeList;
        },
        turnFeeList() {
            return this.$store.state.apiTurnFee.turnFeeList;
        },
        unitFeeList() {
            return this.$store.state.apiUnitFee.unitFeeList;
        },
        filterResults() {
            this.blockGender.results = this.blockGender.tempGender.filter(item => item.name.toLowerCase().indexOf(this.blockGender.searchText.toLowerCase()) > -1);

            if (this.blockGender.results.length) {
                return '';
            }
            else {
                return 'invalid';
            }
        }
    },
    methods: {
        feeFollowChange() {
            this.fee.follow = !this.fee.follow;
        },
        feeDiscountChange() {
            this.fee.discount = !this.fee.discount;
        },
        feeRequiredChange() {
            this.fee.feeRequired = !this.fee.feeRequired;
        },
        feeAllowExportBillChange() {
            this.fee.allowExportBill = !this.fee.allowExportBill;
        },
        feeTypeRegistionChange() {
            this.fee.typeRegistion = !this.fee.typeRegistion;
        },
        feeAllowExportLicenseChange() {
            this.fee.allowExportLicense = !this.fee.allowExportLicense;
        },
        feeAllowReturnChange() {
            this.fee.allowReturn = !this.fee.allowReturn;
        },
        feePrivateChange() {
            this.fee.feePrivate = !this.fee.feePrivate;
        },
        hidePopup() {
            this.$emit("emitShowPopup", false);
        },
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
                    }, 2000);
                } else {
                    setTimeout(() => {
                        this.isLoading = false;
                    }, 3000);
                }
            } catch (error) {
                setTimeout(() => {
                    this.isLoading = false;
                }, 3000);
            }
        },
        async saveAsFeeRequest() {
            // Add loading animation
            this.isLoading = true;
            this.messageError = "Đang xử lí...";

            let responseBE = await this.postRequest(this.fee);
            if (responseBE?.status == "201" || responseBE?.status == "200") {
                this.messageError = "Thêm mới thành công";
                setTimeout(() => {
                    this.isLoading = false;
                    this.$emit("saveAsMethodFee", responseBE.data.resource);
                }, 2000);
            }
        },
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
                    }, 2000);
                } else {
                    setTimeout(() => {
                        this.isLoading = false;
                    }, 3000);
                }
            } catch {
                setTimeout(() => {
                    this.isLoading = false;
                }, 3000);
            }
        },
        confirmDataBeforeUsing() {
            if (this.fee.feeGroupId == -1)
                this.$set(this.fee, 'feeGroupId', null);
            if (this.fee.quality == -1)
                this.$set(this.fee, 'quality', null);
        },
        resetDataBeforeUsing() {
            let tempFee = {
                feeName: ' ',
                feeGroupId: ' ',
                feeRangeId: ' ',
                unitFeeId: ' ',
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
        saveAs() { // Nút Lưu thêm mới
            // Dialog Add
            this.confirmDataBeforeUsing();
            this.saveAsFeeRequest();
            this.resetDataBeforeUsing();
        },
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
        formatMoney(money) {
            let tempData = money.toString().replace(/\D/g, '');
            return tempData.toString().replace(/(\d)(?=(\d{3})+(?:\.\d+)?$)/g, "$1.");

        },
        moneyToNumber(value) {
            let tempData = value.toString().replace(/\D/g, '');
            if (!isNaN(tempData) && parseInt(tempData) > 0) {
                return parseInt(tempData);
            } else {
                return -1;
            }
        },
        assignFee(resource) {
            // Id using in editing data
            this.feeId = resource.feeId;

            if (!resource.amountOfFee) {
                this.tempAmount = new String;
            } else {
                this.tempAmount = resource.amountOfFee;
            }

            this.$set(this.fee, 'feeName', resource.feeName);
            this.$set(this.fee, 'feeGroupId', resource.feeGroup.feeGroupId);
            this.$set(this.fee, 'feeRangeId', resource.feeRange.feeRangeId);
            this.$set(this.fee, 'unitFeeId', resource.unitFee.unitFeeId);
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
        assignValidateProperties() {
            this.isCheckFeeName = true;
            this.isCheckFeeAmount = true;
            this.isCheckFeeRange = true;
            this.isCheckFeeUnit = true;
        },
        assignAutocompleDropdown(resource) {
            this.blockGender.searchText = this.blockGender.tempGender.filter(x => x.id == resource.gender)[0].name;
            this.fee.gender = resource.gender;
        },
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
        turnFeeList: function (newVal) {
            this.assignTurnFeeSelected();
        },
        tempAmount: function (value) {
            this.tempAmount = this.formatMoney(value);

            // Convert money text to money int
            let tempData = this.moneyToNumber(this.tempAmount);
            if (tempData > 0) {
                this.$set(this.fee, 'amountOfFee', tempData);
            }
        },
        isCallFunc: function (newVal) {
            if (newVal < 0) {
                // Dialog Add
                this.title = "Thêm khoản thu";
                this.hasSaveAsButton = true;

                let tempFee = {
                    feeName: ' ',
                    feeGroupId: ' ',
                    feeRangeId: ' ',
                    unitFeeId: ' ',
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
                if (this.feeProp) {
                    this.assignFee(this.feeProp);
                    this.assignValidateProperties();
                }
                else {
                    this.assignFee(tempFee);
                    this.assignValidateProperties();
                }
            }
            else {
                // Dialog Update
                this.title = "Sửa khoản thu";
                this.hasSaveAsButton = false;
                this.assignValidateProperties();
                this.assignFee(this.feeProp);
                //this.assignAutocompleDropdown(this.feeProp)
            }
        }
    }
};